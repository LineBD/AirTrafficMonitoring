using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ICompareTracks
    {
        void UpdateTracks(List<ITrack> newTracks);
        List<ITrack> ComparedTracks { get; set; }
    }
}
