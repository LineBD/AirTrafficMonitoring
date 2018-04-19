using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
  abstract  class ConflictTracksSubject
    {
        private List<IConflictTracks> _conflictList = new List<IConflictTracks>();
        public void Attach(IConflictTracks conflicts)
        {

        }
        public void Detach()
        {

        }
        public void Notify()
        {

        }
    }
}
