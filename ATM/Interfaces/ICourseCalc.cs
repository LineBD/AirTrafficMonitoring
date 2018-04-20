using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ICourseCalc
    {
        double CalculateCourse(List<ITrack> track, List<ITrack> traack);
    }
}
