using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TransponderDataFactory
    {
        public TrackDTO CreateFlight(string trackInfo)
        {
            TrackDTO track = new TrackDTO();

            string[] array = trackInfo.Split(';');
            track.Tag = array[0];
            track.XCoordinate = Convert.ToInt32(array[1]);
            track.YCoordinate = Convert.ToInt32(array[2]);
            track.Altitude = Convert.ToInt32(array[3]);
            track.Timestamp = CreateDateTime(array[4]);

            return track;
        }

        private DateTime CreateDateTime(string trackInfo)
        {
            DateTime
        }

            

        }

    }
}
