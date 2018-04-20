using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalc: ICourseCalc
    {
       // Mangler at få listen med...
        public double CalculateCourse(ITrack oldtrack, ITrack newtrack)
        {
            int x1coordinate = oldtrack.XCoordinate;
            int x2coordinate = newtrack.XCoordinate;
            int y1coordinate = oldtrack.YCoordinate;
            int y2coordinate = newtrack.YCoordinate;

            int xCoordinate = x2coordinate - x1coordinate;
            int yCoordinate = y2coordinate - y1coordinate;

            double theta = Convert.ToDouble(Math.Atan2(yCoordinate,xCoordinate) - Math.Atan2(90000, 0)); 
            double CourseDegrees = theta * (180 / Math.PI);
            return CourseDegrees;

        }
        //private List<ITrack> _tracklist;
        //public double CalculateCourses(List<ITrack> _tracklist)
        //{
        //    int x1coordinate = _tracklist[1].XCoordinate;
        //    int x2coordinate = _tracklist[2].XCoordinate;
        //    int y1coordinate = _tracklist[1].YCoordinate;
        //    int y2coordinate = _tracklist[2].YCoordinate;

        //    int xCoordinate = x2coordinate - x1coordinate;
        //    int yCoordinate = y2coordinate - y1coordinate;

        //    double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
        //    double CourseDegrees = theta * (180 / Math.PI);
        //    return CourseDegrees;
        //}
        //public void CalculateCourse(int x1Coordinate, int x2Coordinate, int y1Coordinate, int y2Coordinate)
        //{
        //    double xCoordinate = x2Coordinate - x1Coordinate;
        //    double yCoordinate = y2Coordinate - y1Coordinate;

        //    // https://en.wikipedia.org/wiki/Polar_coordinate_system

        //    double theta = Math.Atan2(xCoordinate, yCoordinate);

        //    double CourseDegrees = theta * (180 / Math.PI);

        //}
    }
}
