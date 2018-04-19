using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalc: ICourseCalc

    {
        private List<ITrack> _tracklist;

        public double CalculateCourse(ITrack track1, ITrack track2)
        {
            int x1coordinate = track1.XCoordinate;
            int x2coordinate = track2.XCoordinate;
            int y1coordinate = track1.YCoordinate;
            int y2coordinate = track2.YCoordinate;

            int xCoordinate = x2coordinate - x1coordinate;
            int yCoordinate = y2coordinate - y1coordinate;

            double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
            double CourseDegrees = theta * (180 / Math.PI);
            return CourseDegrees;

        }
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
