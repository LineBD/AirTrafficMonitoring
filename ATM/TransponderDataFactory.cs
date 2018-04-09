using System;
using System.Collections.Generic;
using System.Globalization;
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
    
        private DateTime _datetime;
        private DateTime CreateDateTime(string input)
        {
            int yearsub = Convert.ToInt32(input.Substring(0, 4));
            int monthsub = Convert.ToInt32(input.Substring(4, 6));
            int datesub = Convert.ToInt32(input.Substring(6, 8));
            int hoursub = Convert.ToInt32(input.Substring(8, 10));
            int minutesub = Convert.ToInt32(input.Substring(10, 12));
            int secondsub = Convert.ToInt32(input.Substring(12, 14));
            int millisecsub = Convert.ToInt32(input.Substring(14, 16));

            _datetime = new DateTime(yearsub,monthsub,datesub,hoursub,minutesub,secondsub,millisecsub);
            _datetime = DateTime.ParseExact(
                $"{yearsub}/{monthsub}/{datesub} {hoursub}:{minutesub}:{secondsub};{millisecsub}",
                "yyyy/mm/dd hh:mm:ss:fff", CultureInfo.InvariantCulture);
            return _datetime;

         
            
        }

            

        }

    }

