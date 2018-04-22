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
        private IWrite alarm;
        LogToFile log = new LogToFile();

        public DetectConflict(CheckCollision checkcollision)
        {
            alarm = new ConflictAlarm();
            _checkcollision = checkcollision;
            _checkcollision.Attach(this);
        }
        public void Update()
        {
            List<ITrack> conflictingTracks = _checkcollision.ConflictingFlights;
            alarm.Write(conflictingTracks);
            log.Write(conflictingTracks);
        }
    }
}
