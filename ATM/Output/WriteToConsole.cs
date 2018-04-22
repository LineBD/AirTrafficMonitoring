using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class WriteToConsole : IWrite
    {
        public void Write(List<ITrack> trackList)
        {
            if(trackList.Count  != 0)
            {
                Console.WriteLine("- - - - - - ");
                foreach (var track in trackList)
                {
                    Console.WriteLine(
                        "Tag: " + track.Tag + "\nX Coordinate: " + track.XCoordinate + "\nY Coordinate: " +
                   track.YCoordinate + "\nAltitude: " + track.Altitude + "\nTimestamp: " +
                   track.Timestamp + "\n" + "Hastighed: " + track.Velocity + "\n" + "Course: " + track.Course);
                }
            }
                    
            
        }
    }

}
