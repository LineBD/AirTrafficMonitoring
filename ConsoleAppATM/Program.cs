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
                      
           IWrite writer = new WriteToConsole();
           CheckCollision compare = new CheckCollision();
           ITrack track = new Track();
           ITrackParsing parseTracks = new TrackParsing(track);
           IConflictingTracks conflict = new CompareTracks();
            IFilterFlightLimits filter = new FilterFlightLimits();
            var myReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            

            var receiver = new MainReceiver(myReceiver,filter,writer,compare,conflict,parseTracks);
          
            Console.ReadKey();
           
    }
    }
}
