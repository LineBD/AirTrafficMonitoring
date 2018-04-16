using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class CourseCalc
    {

        public double CalculateCourse(int xCoordinate, int yCoordinate)
        {
            // https://en.wikipedia.org/wiki/Polar_coordinate_system

            double theta = Math.Atan2(xCoordinate, yCoordinate);

            double CourseDegrees = theta * (180 / Math.PI);

            return CourseDegrees;
        }
    }
}
