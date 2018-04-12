using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TransponderDataFactory
    {
        private ITrack track;
        public ITrack CreateFlight(string trackInfo)
        {
            
            track = new TrackDTO();

            string[] array = trackInfo.Split(';');
            track.Tag = array[0];
            track.XCoordinate = Convert.ToInt32(array[1]);
            track.YCoordinate = Convert.ToInt32(array[2]);
            track.Altitude = Convert.ToInt32(array[3]);
            track.Timestamp = DateTime.ParseExact(array[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);

            return track;
        }

        public override string ToString()
        {
            return "Tag: " + track.Tag + "\nX Coordinate: " + track.XCoordinate + "\nY Coordinate: " +
                   track.YCoordinate + "\nAltitude: " + track.Altitude + "\nTimestamp: " +
                   track.Timestamp + "\n";
        }
        }
    }

