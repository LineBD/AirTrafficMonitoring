using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    [TestFixture]
    public class IntegrationTest1new
    {
        //Forbindelse mellem ControllerDisplay og DLL
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

            parseTracks = Substitute.For<ITrackParsing>();
            write = Substitute.For<IWrite>();
            filter = Substitute.For<IFilterFlightLimits>();
            collision = Substitute.For<CheckCollision>();
            conflictingtracks = Substitute.For<IConflictingTracks>();
            _controller = new ControllerDisplay(receiver, filter, write, collision, conflictingtracks, parseTracks);

        }
        [Test]
        public void CreateFlightFromDLL_OneFlightCreated_IsCorrect()
        {
            _controller.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { "TRK042;1234;5678;13000;20180403100622937" }));
            parseTracks.Received().CreateFlight("TRK042;1234;5678;13000;20180403100622937");
        }


    }
}

