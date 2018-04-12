using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class TransponderDataConsole
    {
        private ITrack track;
        public override string ToString()
        {
            return "Tag: " + track.Tag + "\nX Coordinate: " + track.XCoordinate + "\nY Coordinate: " +
                   track.YCoordinate + "\nAltitude: " + track.Altitude + "\nTimestamp: " +
                   track.Timestamp + "\n";
        }
    }
}
