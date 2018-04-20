using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    public class LogToFile : ILog
    {
        
        public void Log(List<ITrack> conflictingTracks)
        {
            FileStream filestream = new FileStream("FileLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(filestream);
            writer.WriteLine("ALARM - Conflicting flights! Flight: " + conflictingTracks[0].Tag + "and flight :" + conflictingTracks[1].Tag + "are in conflict." +
                "\nTime of Occurence: " + conflictingTracks[0].Timestamp.Year + "/" + conflictingTracks[0].Timestamp.Month + "/" + conflictingTracks[0].Timestamp.Day +
                                 ", at " + conflictingTracks[0].Timestamp.Hour + ":" + conflictingTracks[0].Timestamp.Minute + ":" +
                                 conflictingTracks[0].Timestamp.Second + ":" + conflictingTracks[0].Timestamp.Millisecond); 
        }
    }
}
