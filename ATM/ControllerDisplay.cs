using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ControllerDisplay
    {
        private ITransponderReceiver _transponderreceiver;
        public ControllerDisplay(ITransponderReceiver receiver)
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
            var ffl = new FilterFlightLimits();
          

            var mylist = e.TransponderData;

            var trackObjectList = new List<TrackDTO>();
            
            foreach (var track in mylist)
            {

                var trackObject = tFactory.CreateFlight(track);
                if (ffl.State == true)
                {
                    trackObjectList.Add(trackObject);
                }
                Console.WriteLine(tFactory.ToString());

            }
        }

    }
}   

