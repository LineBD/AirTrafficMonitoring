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
    [TestFixture()]
    class ControllerDisplayTest
    {
        private ControllerDisplay _uut;
        private IFilterFlightLimits _filter;
        private ITransponderReceiver _receiver;
        private ITrackParsing _trackparsing;
        private IWrite _writer;
        private ITrack _track;
        private List<ITrack> _trackObjectList;

        [SetUp]
        public void Setup()
        {
            _filter = Substitute.For<IFilterFlightLimits>();
            _receiver = Substitute.For<ITransponderReceiver>();
            _trackparsing = Substitute.For<ITrackParsing>();
            _writer = Substitute.For<IWrite>();
            _trackObjectList = Substitute.For<List<ITrack>>();
            _uut = new ControllerDisplay(_receiver,_filter, _trackparsing,_writer, _trackObjectList);
            _track = Substitute.For<ITrack>();

            var track = "AIM500;40000;50000;60000;20161011221035800";
            var trackliste = new List<string>();
            trackliste.Add(track);

            var transponderevent = new RawTransponderDataEventArgs(trackliste);
        }

        [Test]
        public void TransponderDataRecived_CallCreateFlight_FlightIsCreated()
        {
          
            _receiver.Received().TransponderDataReady += _uut.MyReciever_transponderDataReady;
        }

        [Test]
        public void TransponderDataReady_Called_IsTrue()
        {
            _trackparsing.Received().CreateFlight("AIM500;40000;50000;60000;20161011221035800");
        }

        [Test]
        public  void TrackObjectCreated_FilterReturnsTrue_TrackObjectAddedToList()
        {
            _filter.Filtering(Arg.Any<ITrack>()).Returns(true);
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
