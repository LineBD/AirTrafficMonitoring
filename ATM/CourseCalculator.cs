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
        public void CalculateCourse(List<ITrack> currentTracks, List<ITrack> oldtracks)
        {
           // List<ITrack> courseList = new List<ITrack>();
            foreach (var track in currentTracks)
            {
                track.Course = 200;
                //for (int i = 0; i < currentTracks.Count; i++)
                //{
                //    if (track.Tag == currentTracks[i].Tag)
                //    {
                //        double xCoordinate = (double)(track.XCoordinate - currentTracks[i].XCoordinate);
                //        double yCoordinate = (double)(track.YCoordinate - currentTracks[i].YCoordinate);
                        
                //        double theta = Math.Atan2(xCoordinate, yCoordinate);
                //        double CourseDegrees = theta * (180 / Math.PI);
                //        track.Course = CourseDegrees;

                //    }
                //}
                //courseList.Add(track);
            }
           
        }
    }
}
