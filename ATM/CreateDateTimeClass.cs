using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ATM
{
   public class CreateDateTimeClass
    {
        private DateTime _datetime;
        public DateTime CreateDateTime(string input)
        {
            int yearsub = Convert.ToInt32(input.Substring(0, 4));
            int monthsub = Convert.ToInt32(input.Substring(4, 6));
            int datesub = Convert.ToInt32(input.Substring(6, 8));
            int hoursub = Convert.ToInt32(input.Substring(8, 10));
            int minutesub = Convert.ToInt32(input.Substring(10, 12));
            int secondsub = Convert.ToInt32(input.Substring(12, 14));
            int millisecsub = Convert.ToInt32(input.Substring(14, 16));

            _datetime = DateTime.ParseExact($"{yearsub}/{monthsub}/{datesub} {hoursub}:{minutesub}:{secondsub}:{millisecsub}", "yyyy/mm/dd hh:mm:ss:fff", CultureInfo.InvariantCulture);
            return _datetime;



        }

    }
}
