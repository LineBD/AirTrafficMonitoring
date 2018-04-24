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
    class IntegrationTest6
    {
        private MainReceiver _mainreciever;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private ICompareTracks _comparetracks;
        private CheckCollision _collision;
        private IWrite _write;
        private IWrite _writeToConsole;
        private ITransponderReceiver _receiver;
        private ConflictAlarm _alarm;


        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _filter = new FilterFlightLimits();
            _collision = new CheckCollision();
            _comparetracks = new CompareTracks();
            _writeToConsole = Substitute.For<WriteToConsole>();
            _alarm = Substitute.For<ConflictAlarm>();
            _mainreciever =
                new MainReceiver(_receiver, _filter, _write, _collision, _comparetracks, _parseTracks);

        }

        [Test]
        public void nu_nu_nu()
        {
            //DateTime dateTime1 = new DateTime(2018, 06, 10, 10, 18, 18);
            //DateTime dateTime2 = new DateTime(2018, 06, 10, 10, 18, 20);

            //Track _flight2 = new Track
            //{
            //    Tag = "HEJMEDDIG",
            //    XCoordinate = 12000,
            //    YCoordinate = 12001,
            //    Altitude = 19987,
            //    Timestamp = dateTime1

            //};

            //List<ITrack> _newTracks = new List<ITrack>
            //{
            //    _flight2
            //};


            List<ITrack> list = new List<ITrack>();
            string _flight1 = "TRK042;13000;13000;13000;20180403100622937";
            string _flight2 = "TTG065;13001;13001;13001;20180403100622937";
            _mainreciever.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { _flight1 }));
            _mainreciever.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string>{_flight2}));
            ITrack track1 = _parseTracks.CreateFlight(_flight1);
            ITrack track2 = _parseTracks.CreateFlight(_flight2);
            list.Add(track1);
            list.Add(track2);

            _collision.TrackComparison(list);
            _alarm.Received().Write(list);
        }
    }
}
