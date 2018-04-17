using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TransponderDataFactory: ITransponderDataFactory
    {
        private TrackDTO _track;

        public TransponderDataFactory(TrackDTO track)
        {
            _track = track;
        }
        public TrackDTO CreateFlight(string trackInfo)
        {
            
            TrackDTO track = new TrackDTO();

            var info = trackInfo.Split(';');
            track.Tag = info[0];
            track.XCoordinate = Convert.ToInt32(info[1]);
            track.YCoordinate = Convert.ToInt32(info[2]);
            track.Altitude = Convert.ToInt32(info[3]);
            track.Timestamp = DateTime.ParseExact(info[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            track.Velocity = 0;
            track.Course = 0;

            return track;
        }

        }
    }

