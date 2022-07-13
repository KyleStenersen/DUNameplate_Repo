using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    // Not quite sure if this should be static, maybe it should be contained inside MachineControl instead?
    internal static class PlateQueue
    {
        private static List<Nameplate> QueuedPlates { get; set; }

        private static ListView queuedPlatesListView;

        public static int Count
        {
            get
            {
                return QueuedPlates.Count;
            }
        }

        static PlateQueue()
        {
            QueuedPlates = new List<Nameplate>();
        }

        public static void SetListView(ListView queuedPlatesListView)
        {
            PlateQueue.queuedPlatesListView = queuedPlatesListView;
        }

        public static void Clear()
        {
            QueuedPlates = new List<Nameplate>();

            UpdateListView();
        }

        // This function just adds the plate passed into the function into our QueuedPlates list
        public static void Enqueue(Nameplate plateToAdd)
        {
            //QueuedPlates.Enqueue(plateToAdd);
            QueuedPlates.Add(plateToAdd);

            UpdateListView();
        }

        // This function gets the top plate from the queue, but does not remove it
        // It is the only way that the MachineControl class is getting Nameplates
        public static Nameplate Peek()
        {
            return QueuedPlates[0];
        }

        // This function subtracts one from the quantity of the plate at the top of the queue (which is being printed
        // when this function is called)
        // It also will automatically call Dequeue if the Quantity is changed to zero.
        public static void DecrementTopPlateQuantity()
        {
            Nameplate topPlate = QueuedPlates[0];

            topPlate.Quantity -= 1;

            if (topPlate.Quantity == 0) {
                Dequeue();
            }

            UpdateListView();
        }

        // This function removes the plate from the top of the queue
        private static void Dequeue()
        {
            QueuedPlates.RemoveAt(0);

            UpdateListView();
        }

        //// TryDequeue will be run when the current nameplate is fully completed printing, so it will be removed from the queue,
        //// and from the queue list view in the UI
        //public static bool TryDequeue(out Nameplate outputDequeuedPlate)
        //{
        //    // With a ConcurrentQueue, you have to TryDequeue, and it will return a true if it succeeds, or false if there's nothing left to dequeue,
        //    // or if it fails.
        //    if (QueuedPlates.TryDequeue(out Nameplate dequeuedPlate))
        //    {
        //        outputDequeuedPlate = dequeuedPlate;

        //        UpdateListView();

        //        return true;
        //    }
        //    else
        //    {
        //        outputDequeuedPlate = null;
        //        return false;
        //    }
        //}

        //// TryPeek will be used to grab the plate from the top of the queue, without removing it from the queue. The
        //// plate returned from this function will be used in the printing functions, and then TryDequeue will be run
        //// after the plate has been fully printed
        //public static bool TryPeek(out Nameplate outputPeekedPlate)
        //{
        //    if (QueuedPlates.TryPeek(out Nameplate peekedPlate))
        //    {
        //        outputPeekedPlate = peekedPlate;

        //        return true;
        //    }
        //    else
        //    {
        //        outputPeekedPlate = null;
        //        return false;
        //    }
        //}

        // See here to explain the reason for the InvokeRequired:
        // https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8
        private static void UpdateListView()
        {
            if (queuedPlatesListView.InvokeRequired)
            {
                queuedPlatesListView.Invoke(new Action(UpdateListView));
            }
            else
            {
                // A bit inefficient, but the list should never be big enough for this to be a problem
                queuedPlatesListView.Items.Clear();

                foreach (Nameplate plate in QueuedPlates)
                {
                    // Create a new ListViewItem to add to the list, with the lines of the nameplate concatenated together
                    // with a space between as the text under the Tag Contents column
                    ListViewItem listItem = new ListViewItem(String.Join(" ", plate.Lines));

                    // Add the quantity under the Quantity column of the item
                    listItem.SubItems.Add(plate.Quantity.ToString());

                    // Add the new listItem to the list
                    queuedPlatesListView.Items.Add(listItem);
                }
            }
        }
    }
}
