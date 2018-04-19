//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using NUnit.Framework.Internal;
//using TransponderReceiver;
//using NSubstitute;

//namespace ATM.Test.Unit
//{
//    [TestFixture()]
//    class DisplayTest
//    {
//        private ControllerDisplay _uut;
//        private ITransponderReceiver _fakeTransponderReceiver;
//        private TrackParsing _fakeTrackParsing;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
//            _fakeTrackParsing = Substitute.For<TrackParsing>();
//            _uut = new ControllerDisplay(_fakeTransponderReceiver);
//        }

//        [Test]
//        public void TransponderDataRecived_CallCreateFlight_FlightIsCreated()
//        {
//            _uut.DisplayTrack();
//            _fakeTransponderReceiver.Received().TransponderDataReady += _uut.MyReciever_transponderDataReady;

//        }

//        [Test]
//        public void TransponderDataReady_Called_IsTrue()
//        {
//            var flightList = new List<string>() { "AIM500;40000;50000;60000;20161011221035800" };
//            _uut.MyReciever_transponderDataReady(this, new RawTransponderDataEventArgs(flightList));
//            _fakeFactory.Received().CreateFlight("AIM500;40000;50000;60000;20161011221035800");
//        }

//    }
//}
