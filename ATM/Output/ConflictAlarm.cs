using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public  class ConflictAlarm : IWrite
    {
        public void Write(List<ITrack> conflictingTracks)
        {
            Console.WriteLine("ALARM - Conflicting flights! Flight: " + conflictingTracks[0].Tag + "and flight :" + conflictingTracks[1].Tag + "are in conflict." +
                "\nTime of Occurence: " + conflictingTracks[0].Timestamp.Year + "/" + conflictingTracks[0].Timestamp.Month + "/" + conflictingTracks[0].Timestamp.Day +
                                 ", at " + conflictingTracks[0].Timestamp.Hour + ":" + conflictingTracks[0].Timestamp.Minute + ":" +
                                 conflictingTracks[0].Timestamp.Second + ":" + conflictingTracks[0].Timestamp.Millisecond);
        }
    }
}
