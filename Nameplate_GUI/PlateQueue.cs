using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUNameplateGUI
{
    internal class PlateQueue
    {
        public Queue<Nameplate> QueuedPlates { get; set; }

        public PlateQueue ()
        {
            QueuedPlates = new Queue<Nameplate>();
        }
    }
}
