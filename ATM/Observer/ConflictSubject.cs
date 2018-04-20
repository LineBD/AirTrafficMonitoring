using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public abstract class ConflictSubject
    {
        private List<IConflictObserver> ListOfConflictingTracks = new List<IConflictObserver>();
        public void Attach(IConflictObserver observer)
        {
            ListOfConflictingTracks.Add(observer);
        }
        public void Detach(IConflictObserver observer)
        {
            ListOfConflictingTracks.Remove(observer);
        }
        public void Notify()
        {
            foreach (var conflictingTracks in ListOfConflictingTracks)
            {
                conflictingTracks.Update();
            }
        }
    }
}
