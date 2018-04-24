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
    class MainRecieverTest
    {
        private MainReceiver _uut;
        private ITransponderReceiver _transponderReceiver;
        private IFilterFlightLimits _filter;
        private IWrite _write;
        private CheckCollision _compare;
        private ITrackParsing _parseTrack;
        private ICompareTracks _conflict;
        private ITrack _track;
        private List<ITrack> _trackObjectList;
        private string track;

        [SetUp]
        public void SetUp()
        {

            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _parseTrack = Substitute.For<ITrackParsing>();
            _filter = Substitute.For<IFilterFlightLimits>();
            _write = Substitute.For<IWrite>();
            _trackObjectList = Substitute.For<List<ITrack>>();
            _track = Substitute.For<ITrack>();
            _uut = new MainReceiver(_transponderReceiver, _filter, _write, _compare, _conflict, _parseTrack);

            var track = "AIM500;40000;50000;60000;20161011221035800";
            var trackliste = new List<string>();
            trackliste.Add(track);

        }

        [Test]
        public void TransponderDataRecived_CallCreateFlight_FlightIsCreated()
        {

            _transponderReceiver.Received().TransponderDataReady += _uut.MyReceiver_TransponderDataReady;
        }

        //[Test]
        //public void TransponderDataReady_Called_IsTrue()
        //{
        //   // _uut.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<String> { track }));
        //    //Assert.That(_parseTrack.CreateFlight(track),Is.EqualTo("AIM500;40000;50000;60000;20161011221035800"));
        //    _parseTrack.Received().CreateFlight(Arg.Is<string>(s => s == "AIM500;40000;50000;60000;20161011221035800"));
        //} Virker ikke..

        [Test]
        public void TrackObjectCreated_FilterReturnsTrue_TrackObjectAddedToList()
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