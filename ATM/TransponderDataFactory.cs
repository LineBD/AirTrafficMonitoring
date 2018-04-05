using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TransponderDataFactory
    {
        public TrackDTO CreateFlight(string trackInfo)
        {
            TrackDTO track = new TrackDTO();

            string[] array = trackInfo.Split(';');
            track.Tag = array[0];
            track.XCoordinate = Convert.ToInt32(array[1]);
            track.YCoordinate = Convert.ToInt32(array[2]);
            track.Altitude = Convert.ToInt32(array[3]);
            track.Timestamp = CreateDateTime(array[4]);

            return track;
        }

        private DateTime CreateDateTime()
        {
            string input = "yyyymmddhhmmssfff";
            string yearsub = input.Substring(0, 4);
            string monthsub = input.Substring(4, 6);
            string datesub = input.Substring(6, 8);
            string hoursub = input.Substring(8, 10);
            string minutesub = input.Substring(10, 12);
            string secondsub = input.Substring(12, 14);
            string millisecsub = input.Substring(14, 16);

            Console.WriteLine("Year:{0}", yearsub + " Month:{1}", monthsub +" Date:{2}", datesub + " Hour:{3}",hoursub +" Minutes:{4}", minutesub + " Seconds:{5}", secondsub +" Milliseconds:{6}", millisecsub);
            // Hvordan kreere datetime objekt. skal returnere datetime objekt, kan være vi skal lave strengene om til integer
            
           
            
        }

            

        }

    }
}
