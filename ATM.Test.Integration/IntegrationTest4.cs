using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Integration
   
{ //Mellem conflictingTracks og Velocity
    [TestFixture]
    class IntegrationTest4
    {
        private ControllerDisplay _controller;
        private ITrackParsing parseTracks;
        private ITrack track;
        private IFilterFlightLimits filter;
        private IConflictingTracks conflictingtracks;
        private IVelocityCalc velocalc;
        private ICourseCalc coursecalc;
        private CheckCollision collision;
        private IWrite write;
        private ITransponderReceiver receiver;
        private List<ITrack> list;
        [SetUp]
        public void SetUp()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            track = new Track();
            parseTracks = new TrackParsing(track);
            filter = new FilterFlightLimits();
            conflictingtracks = new ConflictingTracks();
            velocalc = Substitute.For<IVelocityCalc>();
            coursecalc = Substitute.For<ICourseCalc>();
            collision = Substitute.For<CheckCollision>();
            write = Substitute.For<IWrite>();
            _controller = new ControllerDisplay(receiver, filter, write, collision, conflictingtracks, parseTracks);
            velocalc = Substitute.For<IVelocityCalc>();
            coursecalc = Substitute.For<ICourseCalc>();

            var track_ = parseTracks.CreateFlight("TRK042;12000;13000;13000;20180403100622937");

            list = new List<ITrack>();
            list.Add(track_);

        }
        [Test]
        public void TracksUpdated_FromFilteredList_Correct()
        {
            //_controller.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { "TRK042;1234;5678;13000;20180403100622937" }));
            var track_ = parseTracks.CreateFlight("TRK042;12000;13000;13000;20180403100622937");
            conflictingtracks.UpdateTracks(list);
            velocalc.Received().CalculateVelocity();            

        }
    }
}
