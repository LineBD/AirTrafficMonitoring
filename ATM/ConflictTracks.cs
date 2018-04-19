using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConflictTracks : ConflictTracksSubject
    {
        public void Separate(ITrack track1, ITrack track2)
        {
            if (Math.Abs(track2.XCoordinate - track1.XCoordinate) < 400 && Math.Abs(track2.YCoordinate - track1.YCoordinate) < 400 && Math.Abs(track2.Altitude - track1.Altitude) < 4000)
            {
                Notify(track1, track2);
            }
        }
    }
}
