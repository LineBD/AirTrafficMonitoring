﻿using System;
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
            IConflictingTracks _ct = new ConflictingTracks();
            ITrack track = new Track();
            ITrackParsing factory = new TrackParsing(track);
            IFilterFlightLimits filterlimits = new FilterFlightLimits(_ct);
            IWrite writer = new WriteToConsole();
            List<ITrack> trackobjectlist = new List<ITrack>();
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            writer.WriteFlight(track,_ct);

            var myDisplay = new ControllerDisplay(myReciever,filterlimits,factory,writer, trackobjectlist);
            Console.ReadKey();
        }
    }
}
