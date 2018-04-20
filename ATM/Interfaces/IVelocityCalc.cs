using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IVelocityCalc
    {
       double CalculateVelocity(List<ITrack> track1, List<ITrack> track2);
    }
}
