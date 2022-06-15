using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal class PlateQueue
    {
        private Queue<Nameplate> QueuedPlates { get; set; }

        private ListView queuedPlatesList;

        public int Count
        {
            get
            {
                return QueuedPlates.Count;
            }
        }

        public PlateQueue(ListView queuedPlatesList)
        {
            QueuedPlates = new Queue<Nameplate>();

            this.queuedPlatesList = queuedPlatesList;
        }

        public void Enqueue(Nameplate plateToAdd)
        {
            QueuedPlates.Enqueue(plateToAdd);

            UpdateListView();
        }

        public Nameplate Dequeue()
        {
            // This is needed because we want to dequeue the plate, and then update the ListView
            // with the plate removed
            Nameplate dequeuedPlate = QueuedPlates.Dequeue();

            UpdateListView();

            return dequeuedPlate;
        }

        private void UpdateListView()
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
