using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface ILog
    {
        void Log(List<ITrack> tracks);
    }
}
