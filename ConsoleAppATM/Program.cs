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

            var myDisplay = new Display(TransponderReceiverFactory.CreateTransponderDataReceiver());
            myDisplay.DisplayTrack();
            Console.ReadKey();
        }
    }
}
