using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class DetectConflict :IConflictObserver
    {
        private CheckCollision _checkcollision;
        LogToFile log = new LogToFile();

        public DetectConflict(CheckCollision checkcollision)
        {
            _checkcollision = checkcollision;
            _checkcollision.Attach(this);
        }
        public void Update()
        {
            List<ITrack> conflictingTracks = _checkcollision.ConflictingFlights;
            Console.WriteLine("ALARM - Conflicting flights! Flight: " + conflictingTracks[0].Tag + "and flight :" + conflictingTracks[1].Tag + "are in conflict." +
                "\nTime of Occurence: " + conflictingTracks[0].Timestamp.Year + "/" + conflictingTracks[0].Timestamp.Month + "/" + conflictingTracks[0].Timestamp.Day +
                                 ", at " + conflictingTracks[0].Timestamp.Hour + ":" + conflictingTracks[0].Timestamp.Minute + ":" +
                                 conflictingTracks[0].Timestamp.Second + ":" + conflictingTracks[0].Timestamp.Millisecond);
            log.Log(conflictingTracks);
        }
    }
}
