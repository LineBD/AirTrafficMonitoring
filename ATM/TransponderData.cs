using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class TransponderData
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public int Timestamp { get; set; }

        public void FlightObject()
        {
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            myReciever.TransponderDataReady += MyReciever_TransponderDataReady;
        }

        private static void MyReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var mylist = e.TransponderData;

            foreach (var track in mylist)
            {
                Console.WriteLine(track);
            }
        } 
    }
}
