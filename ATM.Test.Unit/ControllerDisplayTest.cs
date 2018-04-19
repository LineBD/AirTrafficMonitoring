﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TransponderReceiver;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture()]
    class ControllerDisplayTest
    {
        private ControllerDisplay _uut;
        private IFilterFlightLimits _filter;
        private ITransponderReceiver _receiver;
        private ITransponderDataFactory _factory;
        private IWrite _writer;

        [SetUp]
        public void Setup()
        {
            _filter = Substitute.For<IFilterFlightLimits>();
            _receiver = Substitute.For<ITransponderReceiver>();
            _factory = Substitute.For<ITransponderDataFactory>();
            _writer = Substitute.For<IWrite>();
            _uut = new ControllerDisplay(_receiver,_filter, _factory,_writer);


        }
        [Test]
        public  void TrackObjectCreated_TrackObjectIsTrue_TrackObjectAddedToList()
        {
            //teste om true eller false returneres - også se om et objekt tilføjes i listen
           
        }
        [Test]
        public void TrackObjectCreated_TrackObjectIsFalse_TrackObjectNotAddedToList()
        {

        }
    }
}