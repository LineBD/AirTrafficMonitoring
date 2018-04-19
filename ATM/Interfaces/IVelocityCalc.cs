using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IVelocityCalc
    {
        double CalculateVelocity(ITrack track1, ITrack track2);
    }
}
