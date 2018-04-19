using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface ICourseCalc
    {
        double CalculateCourse(ITrack track1, ITrack track2);
    }
}
