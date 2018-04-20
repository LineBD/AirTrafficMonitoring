using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalculator : ICourseCalc
    { 
        private double CourseDegrees;
        public double CalculateCourse(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
            List<ITrack> courseList = new List<ITrack>();
            foreach (var track in newTracks)
            {
                for (int i = 0; i < currentTracks.Count; i++)
                {
                    if (track.Tag == currentTracks[i].Tag)
                    {
                        int xCoordinate = track.XCoordinate - currentTracks[i].XCoordinate;
                        int yCoordinate = track.YCoordinate - currentTracks[i].YCoordinate;



                        double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
                        double CourseDegrees = theta * (180 / Math.PI);
                        track.Course = CourseDegrees;

                    }
                }
                courseList.Add(track);
            }
            return CourseDegrees;
        }
    }
}
