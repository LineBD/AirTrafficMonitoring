using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class CourseCalc: ICourseCalc

    {

    public void CalculateCourse(int x1Coordinate, int x2Coordinate, int y1Coordinate, int y2Coordinate)
    {
        double xCoordinate = x2Coordinate - x1Coordinate;
        double yCoordinate = y2Coordinate - y1Coordinate;

        // https://en.wikipedia.org/wiki/Polar_coordinate_system

        double theta = Math.Atan2(xCoordinate, yCoordinate);

        double CourseDegrees = theta * (180 / Math.PI);

    }
    }
}
