using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IVelocityCalc
    {
        void CalculateVelocity(List<ITrack> currentTracks, List<ITrack> newTracks);
        double Velocity_ { get; set; }
    }
}
