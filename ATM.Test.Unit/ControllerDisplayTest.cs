using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TransponderReceiver;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class ControllerDisplayTest
    {
        private ControllerDisplay _uut;
        private ITransponderReceiver _transponderReceiver;
        private IFilterFlightLimits _filter;
        private IWrite _write;
        private CheckCollision _compare;
        private ITrackParsing _parseTrack;
        private IConflictingTracks _conflict;
        private ITrack _track;
        private List<ITrack> _trackObjectList;

        [SetUp]
        public void SetUp()
        {

            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _parseTrack = Substitute.For<ITrackParsing>();
            _filter = Substitute.For<IFilterFlightLimits>();
            _write = Substitute.For<IWrite>();
            _trackObjectList = Substitute.For<List<ITrack>>();
            _track = Substitute.For<ITrack>();
            _uut = new ControllerDisplay(_transponderReceiver, _filter, _write, _compare, _conflict, _parseTrack);

            var track = "AIM500;40000;50000;60000;20161011221035800";
            var trackliste = new List<string>();
            trackliste.Add(track);
            var transponderevent = new RawTransponderDataEventArgs(trackliste);
        }//

        [Test]
        public void TransponderDataRecived_CallCreateFlight_FlightIsCreated()
        {

            _transponderReceiver.Received().TransponderDataReady += _uut.MyReceiver_TransponderDataReady;
        }

        [Test]
        public void TransponderDataReady_Called_IsTrue()
        {
            _parseTrack.Received().CreateFlight("AIM500;40000;50000;60000;20161011221035800");
        }

        [Test]
        public void TrackObjectCreated_FilterReturnsTrue_TrackObjectAddedToList()
        {
            _filter.Filtering(Arg.Any<ITrack>()).Returns(false);
            _trackObjectList.Received().Add(Arg.Any<ITrack>());
        }
        [Test]
        public void TrackObjectCreated_TrackObjectIsFalse_TrackObjectNotAddedToList()
        {
            _filter.Filtering(Arg.Any<ITrack>()).Returns(false);
            _trackObjectList.DidNotReceive().Add(Arg.Any<ITrack>());
        }
    }
}