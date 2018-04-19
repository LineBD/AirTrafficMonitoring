﻿using System;
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
        private ITrackParsing _trackparsing;
        private IWrite _write;
        

        public ControllerDisplay(ITransponderReceiver receiver, IFilterFlightLimits filterLimit, ITrackParsing trackparsing, IWrite write)
        {
            _transponderreceiver = receiver;
            _filterFlightLimits = filterLimit;
            _trackparsing = trackparsing;
            _write = write;
            _transponderreceiver.TransponderDataReady += MyReciever_transponderDataReady;
        }

        public void MyReciever_transponderDataReady(object sender, RawTransponderDataEventArgs e)
        {

            var mylist = e.TransponderData;

            var trackObjectList = new List<Track>();


            foreach (var track in mylist)
            {

                Track trackObject = _trackparsing.CreateFlight(track);
                if (_filterFlightLimits.Filtering(trackObject) == true)
                {
                    trackObjectList.Add(trackObject);
                    _write.WriteFlight(trackObject);
                }
                                
                //Console.WriteLine(trackObjectList);

            }
        }

    }
}   

