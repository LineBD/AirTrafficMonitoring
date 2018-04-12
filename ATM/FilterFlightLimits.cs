using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FilterFlightLimits 
    {
        public FilterFlightLimits()
        {

        }
        
        ITrack track;
        private List<ITrack> FlightList = new List<ITrack>(); // Skal bestemme os for list eller array 
        public void Filtering()
        {
            if (track.Altitude >= 500 && track.Altitude <= 20000 && track.XCoordinate >= 10000 && track.XCoordinate <= 90000 && track.YCoordinate >= 10000 && track.YCoordinate <= 90000) //Regner den i meter?
            {
                FlightList.Add(track);
                Console.WriteLine(FlightList);
            }
            
            // Tilstand om flyet er indenfor eller udenfor
            //Lave en if-metode
        }

    }
}
