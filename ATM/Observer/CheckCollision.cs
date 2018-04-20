using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CheckCollision : ConflictSubject
    {
         public List<ITrack> ConflictingFlights { get; set; }
        public void TrackComparison(List<ITrack> trackliste)
        {
            double verticalDistance;
            double horisontalDistance;

            for (int i = 0; i < trackliste.Count; i++)
            {
                for (int j = i+1; j < trackliste.Count; j++)
                {
                    int X1 = trackliste[i].XCoordinate;
                    int Y1 = trackliste[i].YCoordinate;
                    int X2 = trackliste[j].XCoordinate;
                    int Y2 = trackliste[j].YCoordinate;

                    if (X1 != X2 || Y1 != Y2)
                    {
                        double altitude1 = trackliste[i].Altitude;
                        double altitude2 = trackliste[j].Altitude;

                        verticalDistance = altitude2 - altitude1;

                        if (verticalDistance<300)
                        {
                            horisontalDistance = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2- Y1), 2));

                            if (horisontalDistance < 5000)
                            {
                                ConflictingFlights = new List<ITrack>();
                                ConflictingFlights.Add(trackliste[i]);
                                ConflictingFlights.Add(trackliste[j]);
                                Notify();
                            }
                            
                        }
                    }
                }
            }
            
        }
    }
}
