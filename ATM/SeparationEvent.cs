using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class SeparationEvent
    {
        public event EventHandler Separation;
        public void Separate()
        {
            Separation?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
