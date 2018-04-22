using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalc: ICourseCalc
    {

        public double courseDegrees { get; set; }
        public void CalculateCourse(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
             foreach (var track in newTracks)
            {
                for (int i = 0; i < currentTracks.Count; i++)
                {
                    if (track.Tag == currentTracks[i].Tag)
                    {
                        int dx = track.XCoordinate - currentTracks[i].XCoordinate;
                        int dy = track.YCoordinate - currentTracks[i].YCoordinate;
                        int dz = track.YCoordinate-90000;

                        double a = 90000 - currentTracks[i].YCoordinate;
                        double b = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                        double c = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dz, 2));

                        double courserad = Math.Acos((Math.Pow(a,2)+Math.Pow(b,2)-Math.Pow(c,2))/(2*a*b));
                        courseDegrees = courserad * 180 / Math.PI;
                        track.Course = courseDegrees;
                   }
                }
                
            }
           
        }

       
    }
}
