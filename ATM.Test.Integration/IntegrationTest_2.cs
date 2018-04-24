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
    public class IntegrationTest_2
    {
        //Tester forbindelsen mellem controller display og trackparsing

        private MainReceiver _mainreceiver;
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
            write = Substitute.For<WriteToConsole>();
            filter = new FilterFlightLimits();
            collision = Substitute.For<CheckCollision>();
            comparetracks = Substitute.For<ICompareTracks>();
            _mainreceiver = new MainReceiver(receiver, filter, write, collision, conflictingtracks, parseTracks);

        [Test]
        public void CompareTracks_UpdateTracks


    }
}