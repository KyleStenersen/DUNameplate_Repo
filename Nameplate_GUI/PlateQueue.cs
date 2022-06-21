using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal class PlateQueue
    {
        private ConcurrentQueue<Nameplate> QueuedPlates { get; set; }

        private ListView queuedPlatesList;

        private delegate void SafeUpdateListDelegate();

        public int Count
        {
            get
            {
                return QueuedPlates.Count;
            }
        }

        public PlateQueue(ListView queuedPlatesList)
        {
            QueuedPlates = new ConcurrentQueue<Nameplate>();

            this.queuedPlatesList = queuedPlatesList;
        }

        public void Enqueue(Nameplate plateToAdd)
        {
            QueuedPlates.Enqueue(plateToAdd);

            UpdateListView();
        }

        public bool TryDequeue(out Nameplate outputDequeuedPlate)
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
        private void UpdateListView()
        {
            if (queuedPlatesList.InvokeRequired)
            {
                queuedPlatesList.Invoke(new SafeUpdateListDelegate(UpdateListView));
            }
            else
            {
                // A bit inefficient, but the list should never be big enough for this to be a problem
                queuedPlatesList.Items.Clear();

                foreach (Nameplate plate in QueuedPlates)
                {
                    // Create a new ListViewItem to add to the list, with the lines of the nameplate concatenated together
                    // with a space between as the text under the Tag Contents column
                    ListViewItem listItem = new ListViewItem(String.Join(" ", plate.Lines));

                    // Add the quantity under the Quantity column of the item
                    listItem.SubItems.Add(plate.Quantity.ToString());

                    // Add the new listItem to the list
                    queuedPlatesList.Items.Add(listItem);
                }
            }
        }
    }
}
