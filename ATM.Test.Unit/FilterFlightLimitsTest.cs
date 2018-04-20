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
        private ConflictingTracks _ct;
        [SetUp]
       public void SetUp()
        {
            _uut = new FilterFlightLimits();
            _trackparsing = Substitute.For<ITrackParsing>();


        }
        // vi er opmærksomme på at ikke ALLE grænseværdier er testet. Det bliver gjort hvis vi har god tid til sidst
        //nedre venstre hjørne
        [TestCase(9999,9999,false)]
        [TestCase(10000, 10000, true)]
        [TestCase(10001, 10001, true)]
        //øvre venstre hjørne
       [TestCase(9999, 90001, false)]
        [TestCase(10000, 90000, true)]
        [TestCase(10001, 89999, true)]
        // nedre højre hjørne
        [TestCase(90001, 9999, false)]
        [TestCase(90000, 10000, true)]
        [TestCase(89999, 10001, true)]
        //øvre højre hjørne
        [TestCase(90001, 90001, false)]
        [TestCase(90000, 90000, true)]
        [TestCase(89999, 89999, true)]
        public void SetsState_FlightStateAsExcepted_FilteredCorrect(int x, int y, bool expectedState)
        {
            Track t = new Track() {XCoordinate = x, YCoordinate = y};
            Assert.That(_uut.Filtering(t), Is.EqualTo(expectedState));
        }

    }


}
