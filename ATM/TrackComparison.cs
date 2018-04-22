using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TrackComparison : ITrackComparison
    {
        
        public void HandleTrack(List<Track> _oldTracks, List<Track> _newTracks, Track track)
        {

        }
        //{
        //    if (_newTracks.Exists(x => x.Tag == track.Tag))
        //    {
        //        var newOldTrack = _newTracks.First(x => x.Tag == track.Tag);
        //        if (_oldTracks.Exists(x => x.Tag == track.Tag))
        //        {
        //            var oldTrack = _oldTracks.First(x => x.Tag == track.Tag);
        //            var indexOldTracks = _oldTracks.IndexOf(oldTrack);
        //            _oldTracks[indexOldTracks] = newOldTrack;
        //        }
        //        else
        //        {
        //            _oldTracks.Add(newOldTrack);
        //        }
        //        var indexNewTracks = _newTracks.IndexOf(newOldTrack);
        //        _newTracks[indexNewTracks] = track;
        //    }
        //    else
        //    {
        //        _newTracks.Add(track);
        //    }
            
        //}

    }
}
