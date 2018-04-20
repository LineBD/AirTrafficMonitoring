using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ICourseCalc
    {
        void CalculateCourse(List<ITrack> currentTracks, List<ITrack> oldtracks);
    }
}
