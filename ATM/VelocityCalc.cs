using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    class VelocityCalc: IVelocityCalc
    {
        private List<Track> _tracklist = new List<Track>();
        private List<ITrack> _currentTracks = new List<ITrack>();
        private List<ITrack> _newTracks = new List<ITrack>();


        public double CalculateVelocity(ITrack track1, ITrack track2)
        {
            var TimeDifference = track2.Timestamp.Subtract(track1.Timestamp);
            var Distance = Math.Sqrt(Math.Pow((track2.XCoordinate - track1.XCoordinate), 2) + Math.Pow((track2.YCoordinate - track1.YCoordinate), 2));
            var Velocity = Distance / Math.Abs(Convert.ToDouble(TimeDifference));
            return Velocity;
        }

        //_tracklist.Add(track);

        //if (_tracklist.Count == 2 && track.Tag[1] == track.Tag[2])
        //{
        //    int x1 = _tracklist[1].XCoordinate;
        //    int x2 = _tracklist[2].XCoordinate;
        //    int y1 = _tracklist[1].YCoordinate;
        //    int y2 = _tracklist[2].YCoordinate;

        //    double distanceBetweenTags = Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(y2 - y1,2));

        //    TimeSpan timeDiffernece = _tracklist[2].Timestamp - _tracklist[1].Timestamp;
        //    double timeBetweenTags = timeDiffernece.TotalSeconds; //https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c

        //    double velocity = distanceBetweenTags / timeBetweenTags;

        //    _tracklist.Clear();

        //    // tænker at listen bør tømmes et sted, jeg ved bare ikke helt hvor. måske der^?

        //}

        //public void CalculateVelocityy(List<ITrack> _tracklist)
        //{
        //    double TimeDifference = _tracklist[1].Timestamp.Subtract(_tracklist[0].Timestamp).TotalSeconds;
        //    double AltitudeDifference = Math.Abs(_tracklist[1].Altitude - _tracklist[0].Altitude);
        //    double XCoordinateDifference = Math.Abs(_tracklist[1].XCoordinate - _tracklist[0].XCoordinate);
        //    double YCoordinateDifference = Math.Abs(_tracklist[1].YCoordinate - _tracklist[0].YCoordinate);

        //    double HorizontalVelocity = AltitudeDifference / TimeDifference;
        //    double VerticalVelocity = (XCoordinateDifference + YCoordinateDifference) / TimeDifference;

        //    _tracklist[1].Velocity = Convert.ToInt32(Math.Sqrt(Math.Pow(HorizontalVelocity, 2) + Math.Pow(VerticalVelocity, 2)));

        //}

    }
}
}
