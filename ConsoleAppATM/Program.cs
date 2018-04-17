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
            var track = new TrackDTO();
            ITransponderDataFactory factory = new TransponderDataFactory(track);
            IFilterFlightLimits filterlimits = new FilterFlightLimits();
            IWrite writer = new WriteToConsole();
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();

            var myDisplay = new ControllerDisplay(myReciever,filterlimits,track,factory,writer);
            Console.ReadKey();
        }
    }
}
