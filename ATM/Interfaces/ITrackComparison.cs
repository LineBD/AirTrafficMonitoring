using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface ITrackComparison
    {
        List<Track> _compareList { get; }
        List<Track> HandleTrack(List<Track> _oldTracks, List<Track> _newTracks, Track track);
    }
}
