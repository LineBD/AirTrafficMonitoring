using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    [TestFixture]
   public class IntegrationTest_1
    {
        //Tester forbindelsen mellem controller display og trackparsing

        private MainReceiver _mainreceiver;
        private ITrackParsing parseTracks;
        private ITrack track;
        private IFilterFlightLimits filter;
        private ICompareTracks comparetracks;
        private CheckCollision collision;
        private IWrite write;
        private ITransponderReceiver receiver;
        [SetUp]
        public void SetUp()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            track = new Track();
            parseTracks = new TrackParsing(track);
            write = Substitute.For<WriteToConsole>();
            filter = Substitute.For<IFilterFlightLimits>();
            collision = Substitute.For<CheckCollision>();
            comparetracks = Substitute.For<ICompareTracks>();
            _mainreceiver= new MainReceiver(receiver, filter, write, collision, comparetracks, parseTracks);

        }
       
        [Test]
    
        public void FilterCreatedFlight_FromString_Correct()
        {
            string _flight = "TRK042;13000;130000;13000;20180403100622937";
            _mainreceiver.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { _flight }));

            ITrack track = parseTracks.CreateFlight(_flight);
            filter.Received().Filtering(track);
        }
    }
}
