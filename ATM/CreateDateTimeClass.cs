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


           public DateTime CreateDateTime(string input)
        {
            
            var _datetime = DateTime.ParseExact(input, "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);
            return _datetime;



        }

    }
}
