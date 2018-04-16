using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class VelocityCalc
    {
        private List<TrackDTO> _tracklist = new List<TrackDTO>();

        public void VelocityCalculator(TrackDTO track)
        {

            _tracklist.Add(track);

            if (_tracklist.Count == 2 && track.Tag[1] == track.Tag[2])
            {
                int x1 = _tracklist[1].XCoordinate;
                int x2 = _tracklist[2].XCoordinate;
                int y1 = _tracklist[1].YCoordinate;
                int y2 = _tracklist[2].YCoordinate;

                double distanceBetweenTags = Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(y2 - y1,2));

                TimeSpan timeDiffernece = _tracklist[2].Timestamp - _tracklist[1].Timestamp;
                double timeBetweenTags = timeDiffernece.TotalSeconds; //https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c

                double velocity = distanceBetweenTags / timeBetweenTags;

                _tracklist.Clear();

                // tænker at listen bør tømmes et sted, jeg ved bare ikke helt hvor. måske der^?

            }

        }
    }
}
