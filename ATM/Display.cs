using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class Display
    {
        public void DisplayTrack()
        {
                {
                    var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
                    myReciever.TransponderDataReady += MyReciever_TransponderDataReady;
                    Console.ReadKey();
                }
            }
            private static void MyReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
            {

                var tFactory = new TransponderDataFactory();

                var mylist = e.TransponderData;

                foreach (var track in mylist)
                {
                    Console.Write(mylist);
                    var resultat = tFactory.CreateFlight(track);
                    //Console.WriteLine("Tag: " + resultat.Tag + "\nX Coordinate: " + resultat.XCoordinate + "\nY Coordinate: " +
                    //                  resultat.YCoordinate + "\nAltitude: " + resultat.Altitude + "\nTimestamp: " +
                    //                  resultat.Timestamp);
                    Console.WriteLine(resultat);
                    Console.WriteLine(tFactory.ToString());
                    //Console.WriteLine(result);

                }
            }
        }
    }
    

