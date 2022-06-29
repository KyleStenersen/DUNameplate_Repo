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
        private static ConcurrentQueue<Nameplate> QueuedPlates { get; set; }

        private static ListView queuedPlatesListView;

        //private delegate void SafeUpdateListDelegate();

        public static int Count
        {
            get
            {
                return QueuedPlates.Count;
            }
        }

        //public PlateQueue(ListView queuedPlatesListView)
        //{
        //    QueuedPlates = new ConcurrentQueue<Nameplate>();

        //    this.queuedPlatesListView = queuedPlatesListView;
        //}

        static PlateQueue()
        {
            QueuedPlates = new ConcurrentQueue<Nameplate>();
        }

        public static void SetListView(ListView queuedPlatesListView)
        {
            PlateQueue.queuedPlatesListView = queuedPlatesListView;
        }

        public static void Clear()
        {
            QueuedPlates = new ConcurrentQueue<Nameplate>();

            UpdateListView();
        }

        public static void Enqueue(Nameplate plateToAdd)
        {
            QueuedPlates.Enqueue(plateToAdd);

            UpdateListView();
        }

        public static bool TryDequeue(out Nameplate outputDequeuedPlate)
        {
            // With a ConcurrentQueue, you have to TryDequeue, and it will return a true if it succeeds, or false if there's nothing left to dequeue,
            // or if it fails.
            if (QueuedPlates.TryDequeue(out Nameplate dequeuedPlate))
            {
                outputDequeuedPlate = dequeuedPlate;

                UpdateListView();

                return true;
            }
            else
            {
                outputDequeuedPlate = null;
                return false;
            }

        }

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
