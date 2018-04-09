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
                myReciever.TransponderDataReady += MyReciever_transponderDataReady;
                Console.ReadKey();
            }
        }

        public static void MyReciever_transponderDataReady(object sender, RawTransponderDataEventArgs e)
        {

            var tFactory = new TransponderDataFactory();

            var mylist = e.TransponderData;

            foreach (var track in mylist)
            {

                tFactory.CreateFlight(track);
                Console.WriteLine(tFactory.ToString());

            }
        }

    }
}   

