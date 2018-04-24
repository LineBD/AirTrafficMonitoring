﻿using System;
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
        private ICompareTracks comparetracks;
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
            _mainreceiver = new MainReceiver(receiver, filter, write, collision, comparetracks, parseTracks);
        }

        [Test]
        public void CompareTracks_UpdateTracks_Correct()
        {
            List<ITrack> list = new List<ITrack>();
            string _flight1 = "TRK042;13000;13000;13000;20180403100622937";
            string _flight2 = "TTG065;13001;13001;13001;20180403100622937";
            _mainreceiver.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { _flight1 }));
            _mainreceiver.MyReceiver_TransponderDataReady(this, new RawTransponderDataEventArgs(new List<string> { _flight2 }));
            ITrack track1 = parseTracks.CreateFlight(_flight1);
            ITrack track2 = parseTracks.CreateFlight(_flight2);
            list.Add(track1);
            list.Add(track2);

            comparetracks.UpdateTracks(list);
            write.Received().Write(list);
        }


    }
}