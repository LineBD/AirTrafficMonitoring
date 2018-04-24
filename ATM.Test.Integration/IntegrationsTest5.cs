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
    class IntegrationsTest5
    {
        private MainReceiver _reciever;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private IConflictingTracks _conflictingtracks;
        private CheckCollision _collision;
        private IWrite _write;
        private ITransponderReceiver _receiver;
        private IVelocityCalc _velocityCalc;
        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _write = Substitute.For<IWrite>();
            _filter = new FilterFlightLimits();
            _collision = Substitute.For<CheckCollision>();
            _conflictingtracks = new CompareTracks();
            _velocityCalc = Substitute.For<IVelocityCalc>();
            _reciever = new MainReceiver(_receiver, _filter, _write, _collision, _conflictingtracks, _parseTracks);

        }

        [Test]
        public void etellerandet_etellerandet_noget()
        {
            // der laves et fly som vi ved er indenfor luftrummet
            Track _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            Track _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12001,
                Altitude = 19987,

            };

            List<ITrack> _newTracks = new List<ITrack>
            {
                _flight1
            };

            List<ITrack> _oldTracks = new List<ITrack>
            {
                _flight2
            };

            _filter.Filtering(_track);
            _velocityCalc.Received().CalculateVelocity(_newTracks,_oldTracks);
        }
    }
}
