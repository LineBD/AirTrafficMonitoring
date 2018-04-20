using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    class VelocityCalc : IVelocityCalc
    {
        private double velocity;
        public void CalculateVelocity(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
            //List<ITrack> velocityList = new List<ITrack>();
            foreach (var track in newTracks)
            {
                track.Velocity = 100;
                //for (int i = 0; i < currentTracks.Count; i++)
                //{
                //    if (track.Tag == currentTracks[i].Tag)
                //    {
                //        TimeSpan TimeDifference = track.Timestamp - currentTracks[i].Timestamp;
                //        var Distance = Math.Sqrt(Math.Pow((track.XCoordinate - currentTracks[i].XCoordinate), 2) + Math.Pow((track.YCoordinate - currentTracks[i].YCoordinate), 2));
                //        velocity = Distance / Math.Abs(TimeDifference.TotalSeconds);//https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c

                //        track.Velocity = velocity;
                //    }
                //}
                //velocityList.Add(track);

            }


            //    public double CalculateVelocity(List<ITrack> trackList, List<ITrack> )
            //{
            //    TimeSpan TimeDifference = trackList[1].Timestamp -(trackList[0].Timestamp);
            //    var Distance = Math.Sqrt(Math.Pow((trackList[1].XCoordinate - trackList[0].XCoordinate), 2) + Math.Pow((trackList[1].YCoordinate - trackList[0].YCoordinate), 2));
            //    double _velocity = Distance / Math.Abs(TimeDifference.TotalSeconds);
            //    trackList[1].Velocity = _velocity;
            //    return _velocity;
            //}
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
            //private List<Track> _tracklist = new List<ITrack>();
            //private List<ITrack> _currentTracks = new List<ITrack>();
            //private List<ITrack> _newTracks = new List<ITrack>();
            //public double CalculateVelocity(ITrack track1, ITrack track2)
            //{
            //    TimeSpan TimeDifference = track1.Timestamp.Subtract(track2.Timestamp);
            //    var Distance = Math.Sqrt(Math.Pow((track1.XCoordinate - track2.XCoordinate), 2) + Math.Pow((track1.YCoordinate - track2.YCoordinate), 2));
            //    var Velocity = Distance / Math.Abs(TimeDifference.TotalSeconds);//https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c
            //    return Velocity;
            //}

        }
    }
}

