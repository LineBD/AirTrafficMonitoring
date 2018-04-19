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
            _conflictList.Add(conflicts);
        }
        public void Detach(IConflictTracks conflicts)
        {
            _conflictList.Remove(conflicts);
        }
        public void Notify()
        {
            foreach (var observer in observerlist)
            {
                observer.
            }
        }
    }
}
