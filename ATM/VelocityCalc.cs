using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
   public class VelocityCalc : IVelocityCalc
    {
        public double Velocity_ { get; set; }
        public void CalculateVelocity(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
            foreach (var track in newTracks)
            {
                // track.Velocity = 100;
                for (int i = 0; i < currentTracks.Count; i++)
                {
                    if (track.Tag == currentTracks[i].Tag)
                    {
                        TimeSpan TimeDifference = track.Timestamp - currentTracks[i].Timestamp;
                        var Distance = Math.Sqrt(Math.Pow((track.XCoordinate - currentTracks[i].XCoordinate), 2) + Math.Pow((track.YCoordinate - currentTracks[i].YCoordinate), 2));
                        Velocity_ = Distance / Math.Abs(TimeDifference.TotalMilliseconds/1000);//https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c

                        track.Velocity = Velocity_;
                    }
                }

            }

        }
    }
}

