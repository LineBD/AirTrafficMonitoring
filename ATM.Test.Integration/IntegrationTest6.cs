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
        private ControllerDisplay _controller;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private IConflictingTracks _conflictingtracks;
        private CheckCollision _collision;
        private IWrite _write;
        private IWrite _writeToConsole;
        private ITransponderReceiver _receiver;
        private IVelocityCalc _velocityCalc;
        private ICourseCalc _courseCalc;

        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _writeToConsole = Substitute.For<WriteToConsole>();
            _filter = new FilterFlightLimits();
            _collision = Substitute.For<CheckCollision>();
            _conflictingtracks = new ConflictingTracks();
            _velocityCalc = new VelocityCalc();
            _courseCalc = new CourseCalc();
            _controller = new ControllerDisplay(_receiver, _filter, _write, _collision, _conflictingtracks, _parseTracks);

        }

        [Test]
        public void noget_nogte_nogetmere()
        {
            _filter.Filtering(_track);
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
            _writeToConsole.Received().Write(_newTracks);
        }
    }
}
