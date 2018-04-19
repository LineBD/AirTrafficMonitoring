using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ITrackParsing
    {
        Track CreateFlight(string trackInfo);
        string ToString();
    }
}
