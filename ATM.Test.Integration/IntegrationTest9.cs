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
    class IntegrationTest9
    {
        private MainReceiver _reciever;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private ICompareTracks _comparetracks;
        private CheckCollision _collision;
        private IWrite _write;
        private IWrite _writeConsole;
        private IWrite _logToFile;
        private ITransponderReceiver _receiver;
        private ConflictAlarm _alarm;


        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _writeConsole = Substitute.For<WriteToConsole>();
            _logToFile = Substitute.For<LogToFile>();
            _filter = new FilterFlightLimits();
            _collision = new CheckCollision();
            _comparetracks = new CompareTracks();
            _alarm = new ConflictAlarm();
            _reciever = new MainReceiver(_receiver, _filter, _write, _collision, _comparetracks, _parseTracks);

        }
        [Test]
        public void nej_nej_nej()
        {
            Track _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12001,
                Altitude = 19987,

            };

            List<ITrack> _newTracks = new List<ITrack>
            {
                _flight2
            };

            _collision.TrackComparison(_newTracks);
            _alarm.Received().Write(_newTracks); //hvad gør vi her?
        }
    }
}
