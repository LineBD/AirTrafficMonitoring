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
            Track track = new Track();
            ITrackParsing factory = new TrackParsing(track);
            IFilterFlightLimits filterlimits = new FilterFlightLimits();
            IWrite writer = new WriteToConsole();
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            var myDisplay = new ControllerDisplay(myReciever,filterlimits,factory,writer);
            Console.ReadKey();
        }
    }
}
