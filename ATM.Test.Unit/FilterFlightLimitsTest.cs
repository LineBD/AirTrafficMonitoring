using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TransponderReceiver;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class FilterFlightLimitsTest
    {
        private IFilterFlightLimits _uut;
        private ITrackParsing _trackparsing;
       // private Track trackob;
        private string trackinfo;
        private Track trackob;
        [SetUp]
       public void SetUp()
        {
            _uut = new FilterFlightLimits();
            _trackparsing = new TrackParsing(trackob);
            trackob = _trackparsing.CreateFlight(trackinfo);
           
        }
        [Test]

        [TestCase("AIM500;80000;80000;1;20161011221035800", false)]
        public void SetsState_FlightIsTrue_FilteredCorrect(string trackinfo, bool expectedState)
         
        {
            Assert.That(_uut.Filtering(trackob), Is.EqualTo(expectedState));
        }

    }


}
