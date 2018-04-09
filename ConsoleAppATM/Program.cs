using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ConsoleAppATM
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var myReciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
                myReciever.TransponderDataReady += MyReciever_TransponderDataReady;
                Console.ReadKey();
            }
        }     
                private static void MyReciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
                {
                    var TDF = new TransponderReceiverFactory();
                    var mylist = e.TransponderData;

                    foreach (var track in mylist)
                    {
                        var result
                        Console.WriteLine(track);
                    }
                }
            }
        }
