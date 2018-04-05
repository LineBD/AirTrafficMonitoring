using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class TransponderDataFactoryTest
    {
        private TransponderDataFactory _uut; 
        [SetUp]
        public void SetUp()
        {
            _uut = new TransponderDataFactory();
        }

        [TestCase("AIM500;40000;50000;60000;20161011221035800","AIM500")]

        public void CreateFlight_CreatesFlightWithTag_TagIsCorrect(string trackTag,string expectedTag )
        {
            Assert.That(_uut.CreateFlight(trackTag).Tag, Is.EqualTo(expectedTag));
        }

        [TestCase("AIM500;40000;50000;60000;20161011221035800", 40000)]

        public void CreateFlight_CreatesFlightWithXCoordinate_XIsCorrect(string trackX, int expectedX)
        {
            Assert.That(_uut.CreateFlight(trackX)., Is.EqualTo(expectedX));
        }

        [TestCase("AIM500;40000;50000;60000;20161011221035800", 50000)]

        public void CreateFlight_CreatesFlightWithYCoordinate_YIsCorrect(string trackY, int expectedY)
        {
            Assert.That(_uut.CreateFlight(trackY)., Is.EqualTo(expectedY));
        }

        [TestCase("AIM500;40000;50000;60000;20161011221035800", 60000)]

        public void CreateFlight_CreatesFlightWithAltitude_AltitudeIsCorrect(string trackAltitude, int expectedAltitude)
        {
            Assert.That(_uut.CreateFlight(trackAltitude)., Is.EqualTo(expectedAltitude));
        }

        [TestCase("AIM500;40000;50000;60000;20161011221035800", 2016,10,11,22,10,35,800)]

        public void CreateFlight_CreatesFlightWithDateTime_DateTimeIsCorrect(string trackData, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSeconds, int expectedMiliseconds)
        {
            DateTime DT = new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSeconds, expectedMiliseconds);
            Assert.That(_uut.CreateFlight(trackData)., Is.EqualTo(DT));
        }
    }
}
