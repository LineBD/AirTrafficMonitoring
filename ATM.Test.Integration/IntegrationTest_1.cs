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
        private IConflictingTracks conflictingtracks;
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
            conflictingtracks = Substitute.For<IConflictingTracks>();
            _mainreceiver= new MainReceiver(receiver, filter, write, collision, conflictingtracks, parseTracks);

        }
        //[TestCase(9999, 9999,false)]
        //[TestCase(10000, 9999, false)]
        //[TestCase(10000,10000,true)]
        //[TestCase(90000, 90000, true)]
        //[TestCase(12500,12500,true)]
        //[TestCase(90001, 90000, false)]
        //[TestCase(90001, 90001, false)]
        [Test]
    
        public void FilterCreatedFlight_FromString_Correct(int XCoordinate, int YCoordinate, bool State)
        {
            var _flight = "TRK042;1234;5678;13000;20180403100622937";
            parseTracks.Received().CreateFlight(_flight);
        }
    }
}
