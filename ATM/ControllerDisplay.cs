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
        private IFilterFlightLimits _filterFlightLimits;
        private ITrack _track;
        private ITransponderDataFactory _factory;
        private IWrite _write;


        public ControllerDisplay(ITransponderReceiver receiver, IFilterFlightLimits filterLimit, ITrack track, ITransponderDataFactory factory, IWrite write)
        {
            _transponderreceiver = receiver;
            _filterFlightLimits = filterLimit;
            _track = track;
            _factory = factory;
            _write = write;
            _transponderreceiver.TransponderDataReady += MyReciever_transponderDataReady;
        }

        public void MyReciever_transponderDataReady(object sender, RawTransponderDataEventArgs e)
        {

            var mylist = e.TransponderData;

            var trackObjectList = new List<TrackDTO>();


            foreach (var track in mylist)
            {

                var trackObject = _factory.CreateFlight(track);
                if (_filterFlightLimits.State == true)
                {
                    trackObjectList.Add(trackObject);
                    _write.WriteFlight(trackObject);
                }
                
                Console.WriteLine(trackObjectList);

            }
        }

    }
}   

