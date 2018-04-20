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
            //IConflictingTracks _ct = new ConflictingTracks();
            //ITrack track = new Track();
            //ITrackParsing factory = new TrackParsing(track);
            //IFilterFlightLimits filterlimits = new FilterFlightLimits(_ct);
            //IWrite writer = new WriteToConsole();
            //List<ITrack> trackobjectlist = new List<ITrack>();
            //var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            //writer.WriteFlight(track,_ct);

            //var myDisplay = new ControllerDisplay(myReciever,filterlimits,factory,writer, trackobjectlist);
            //Console.ReadKey();
           
           IWrite writer = new WriteToConsole();
           CheckCollision compare = new CheckCollision();
           //List<ITrack> TrackList = new List<ITrack>();
            ITrack track = new Track();
           ITrackParsing parseTracks = new TrackParsing(track);
           IConflictingTracks conflict = new ConflictingTracks();
            IFilterFlightLimits filter = new FilterFlightLimits();
            var myReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            //writer.WriteFlight();//, conflict);

            var Display = new Forsøg(myReceiver,filter,writer,compare,conflict,parseTracks);
            //writer.WriteFlight(track);
            Console.ReadKey();
           
    }
    }
}
