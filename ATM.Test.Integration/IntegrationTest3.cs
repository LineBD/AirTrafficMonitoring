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
    [TestFixture]
        public class IntegrationTest3
    {
        private MainReceiver _reciever;
        private ITrackParsing parseTracks;
        private ITrack track;
        private IFilterFlightLimits filter;
        private IConflictingTracks _compare;
        private CheckCollision collision;
        private IWrite write;
        private ITransponderReceiver receiver;
        [SetUp]
        public void SetUp()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            track = new Track();
            parseTracks = new TrackParsing(track);
            write = Substitute.For<IWrite>();
            filter = new FilterFlightLimits();
            collision = Substitute.For<CheckCollision>();
            _compare = new CompareTracks();
            _reciever = new MainReceiver(receiver, filter, write, collision, _compare, parseTracks);

        }
        [Test]
        public void FilterTracks_Tracksfiltered_Correct()
        {
            Track _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,

            };

            List<ITrack> _flightList = new List<ITrack>
            {
                _flight1
            };


            _compare.UpdateTracks(_flightList);
            collision.Received().TrackComparison(_flightList);

        }

    }
}
