using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FilterFlightLimits : IFilterFlightLimits
    {   
        public bool State { get; set; }
        private IConflictingTracks _ct;

        public FilterFlightLimits(IConflictingTracks ct)
        {
            _ct = ct;
        }

        public bool Filtering(ITrack track)
        {
           
            if(track.XCoordinate >= 10000 && track.XCoordinate <= 90000 && track.YCoordinate >= 10000 &&
               track.YCoordinate <= 90000)
            {
                State = true;
            }
            else
            {
                State = false;
            }

            return State;
        }

    }
}
