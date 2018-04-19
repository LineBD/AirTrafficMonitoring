using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TrackParsing: ITrackParsing
    {
        private Track _track;

        public TrackParsing(Track track)
        {
            _track = track;
        }
        public Track CreateFlight(string trackInfo)
        {
            
            Track track = new Track();

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

