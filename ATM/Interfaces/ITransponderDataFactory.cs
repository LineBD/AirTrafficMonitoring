using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ITransponderDataFactory
    {
        TrackDTO CreateFlight(string trackInfo);
        string ToString();
    }
}
