using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    class ConvertDLL
    {
        public string TransponderData { set; get; }
        public void FlightObject()
        {
            var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            myReciever.TransponderDataReady += MyReciever_TransponderDataReady;
        }

        private static void MyReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var mylist = e.TransponderData;
        }
    }
}
