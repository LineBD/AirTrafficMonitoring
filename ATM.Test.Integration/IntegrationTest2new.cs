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
   public class IntegrationTest2new
    {
        //Tester forbindelsen mellem controller display og trackparsing

        private Receiver _maincontroller;
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
            write = Substitute.For<IWrite>();
            filter = Substitute.For<IFilterFlightLimits>();
            collision = Substitute.For<CheckCollision>();
            conflictingtracks = Substitute.For<IConflictingTracks>();
            _maincontroller = new Receiver(receiver, filter, write, collision, conflictingtracks, parseTracks);

        }
        //[TestCase(9999, 9999,false)]
        //[TestCase(10000, 9999, false)]
        //[TestCase(10000,10000,true)]
        //[TestCase(90000, 90000, true)]
        //[TestCase(12500,12500,true)]
        //[TestCase(90001, 90000, false)]
        //[TestCase(90001, 90001, false)]
        [Test]
    
        public void FilterCreatedFlight_FromDLL_FilteredCorrect(int XCoordinate, int YCoordinate, bool State)
        {
            //_controller.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { "TRK042;1234;5678;13000;20180403100622937" }));
            var track = parseTracks.CreateFlight("TRK042;12000;12008;13000;20180403100622937");
            filter.Received().Filtering(track);
            Assert.That(filter.State, Is.EqualTo(true));
        }
    }
}
