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
    class IntegrationTest7
    {
        private MainReceiver _reciever;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private ICompareTracks _comparetracks;
        private CheckCollision _collision;
        private IWrite _write;
        private IWrite _writeToConsole;
        private ITransponderReceiver _receiver;


        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _filter = new FilterFlightLimits();
            _collision = Substitute.For<CheckCollision>();
            _comparetracks = new CompareTracks();
            _writeToConsole = Substitute.For<WriteToConsole>();
            _reciever =
                new MainReceiver(_receiver, _filter, _write, _collision, _comparetracks, _parseTracks);

        }

        [Test]
        public void nu_nu_nu()
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

            _comparetracks.UpdateTracks(_newTracks);
            _writeToConsole.Received().Write(_newTracks);
        }
    }
}
