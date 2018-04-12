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
        private ITransponderReceiver _transponderreceiver;
        public Display(ITransponderReceiver receiver)
        {
            _transponderreceiver = receiver;
        }


        public void DisplayTrack()
        {
            {
                _transponderreceiver.TransponderDataReady += MyReciever_transponderDataReady;
                
            }
        }

        public void MyReciever_transponderDataReady(object sender, RawTransponderDataEventArgs e)
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

