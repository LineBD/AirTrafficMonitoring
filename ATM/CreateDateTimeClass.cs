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

        //https://stackoverflow.com/questions/5366285/parse-string-to-datetime-in-c-sharp


        private DateTime _datetime;
        public DateTime CreateDateTime(string input)
        {
            //string s = "yyyyMMddhhmmssfff";
            DateTime _datetime = DateTime.ParseExact(input, "yyyy-MM-dd hh:mm:ss:fff", CultureInfo.InvariantCulture);
            //var yearsub = Convert.ToInt32(input.Substring(0, 4));
            //var monthsub = Convert.ToInt32(input.Substring(4, 2));
            //int datesub = Convert.ToInt32(input.Substring(6, 2));
            //int hoursub = Convert.ToInt32(input.Substring(8, 2));
            //int minutesub = Convert.ToInt32(input.Substring(10, 2));
            //int secondsub = Convert.ToInt32(input.Substring(12, 2));
            //int millisecsub = Convert.ToInt32(input.Substring(14, 3));

            //DateTime _datetime = DateTime.ParseExact($"{yearsub}-{monthsub}-{datesub} {hoursub}:{minutesub}:{secondsub}:{millisecsub}", "yyyy-mm-dd hh:MM:ss:fff", CultureInfo.InvariantCulture);
            return _datetime;



        }

    }
}
