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
    class IntegrationTest2
    {
        //Tester forbindelsen mellem controller display og trackparsing
        
        private ControllerDisplay _controller;
        private ITrackParsing parseTracks;
        private ITrack track;
        private IFilterFlightLimits filter;
        private IConflictingTracks conflictingtracks;
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
            filter = Substitute.For<IFilterFlightLimits>();
            collision = Substitute.For<CheckCollision>();
            conflictingtracks = Substitute.For<IConflictingTracks>();
            _controller = new ControllerDisplay(receiver, filter, write, collision, conflictingtracks, parseTracks);

            
        }
    }
}
