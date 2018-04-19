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

        [SetUp]
        public void Setup()
        {
            _filter = Substitute.For<IFilterFlightLimits>();
            _receiver = Substitute.For<ITransponderReceiver>();
            _trackparsing = Substitute.For<ITrackParsing>();
            _writer = Substitute.For<IWrite>();
            _uut = new ControllerDisplay(_receiver,_filter, _trackparsing,_writer);
            _track = Substitute.For<ITrack>();


        }
        [Test]
        [TestCase(true)]
        public  void TrackObjectCreated_TrackObjectIsTrue_TrackObjectAddedToList(FilterFlightLimits filter)
        {
            
           // var fligtlist = new List<string>() { "AIM500;40000;50000;60000;20161011221035800" };
            //teste om true eller false returneres - også se om et objekt tilføjes i listen
            _uut.MyReciever_transponderDataReady(this, new RawTransponderDataEventArgs();

            Assert.That(_uut.MyReciever_transponderDataReady(this, new RawTransponderDataEventArgs(fligtlist)), Is.EqualTo(false));
        }
        [Test]
        public void TrackObjectCreated_TrackObjectIsFalse_TrackObjectNotAddedToList()
        {

        }
    }
}
