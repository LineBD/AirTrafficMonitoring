using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class WriteToConsole : IWrite
    {
        public void WriteFlight(ITrack track , IConflictingTracks conflictingtrack)
        {
            Console.WriteLine(track.ToString());
            Console.WriteLine(conflictingtrack.ToString());
        }
    }
}
