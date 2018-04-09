using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using TransponderReceiver;

namespace ConsoleAppATM
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("Tag: " + resultat.Tag + "\nX Coordinate: " + resultat.XCoordinate + "\nY Coordinate: " +
                                  resultat.YCoordinate + "\nAltitude: " + resultat.Altitude + "\nTimestamp: " +
                                  resultat.Timestamp);
                     //var result = tFactory.ToString();
                     //Console.WriteLine(result);
                 }
                }
            }
        }
