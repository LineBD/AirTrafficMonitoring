using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class WriteToConsole : IWrite
    {
        public void WriteFlight(ITrack track)
        {
            Console.WriteLine(track.ToString());
        }
    }
}
