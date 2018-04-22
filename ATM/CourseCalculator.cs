using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalculator : ICourseCalc
    {
        private double courseDegrees;
        public void CalculateCourse(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
                foreach (var track in newTracks)
            {
                //track.Course = 200;
                for (int i = 0; i < currentTracks.Count; i++)
                {
                    if (track.Tag == currentTracks[i].Tag)
                    {
                        double xCoordinate = (double)(track.XCoordinate - currentTracks[i].XCoordinate);
                        double yCoordinate = (double)(track.YCoordinate - currentTracks[i].YCoordinate);

                        double theta = Math.Atan2(xCoordinate, yCoordinate);
                        courseDegrees = theta * (180 / Math.PI);
                        track.Course = courseDegrees;

                    }
                }

            }

        }
    }
}
