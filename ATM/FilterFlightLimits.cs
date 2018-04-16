using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FilterFlightLimits 
    {
        TransponderDataFactory tdf = new TransponderDataFactory();
      



        public FilterFlightLimits(TrackDTO trackDTO, int altitude, int xcoordinate, int ycoordinate)
        {
            tdf.CreateFlight() = trackDTO;
            trackDTO.Altitude = altitude;
            trackDTO.XCoordinate = xcoordinate;
            trackDTO.YCoordinate = ycoordinate;
        
        }
        
        TrackDTO track;
        public bool State { get; set; }
        private List<ITrack> FlightList = new List<ITrack>(); // Skal bestemme os for list eller array 
        public void Filtering(bool State)
        {
            if (track.Altitude >= 500 && track.Altitude <= 20000 && track.XCoordinate >= 10000 && track.XCoordinate <= 90000 && track.YCoordinate >= 10000 && track.YCoordinate <= 90000) //Regner den i meter?
            {
                State = true;
            }
            else
            {
                State = false;
            }
            
           
        }

    }
}
