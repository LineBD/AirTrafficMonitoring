using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class DetectConflict :IConflictObserver
    {
        private CheckCollision _checkcollision;
        private IWrite _alarm;
        private IWrite _log;

        public DetectConflict(CheckCollision checkcollision, IWrite alarm, IWrite log)
        {
            _alarm = alarm;
            _log = log;
            _checkcollision = checkcollision;
            _checkcollision.Attach(this);
        }
        public void Update()
        {
            List<ITrack> conflictingTracks = _checkcollision.ConflictingFlights;
            _alarm.Write(conflictingTracks);
            _log.Write(conflictingTracks);
        }
    }
}
