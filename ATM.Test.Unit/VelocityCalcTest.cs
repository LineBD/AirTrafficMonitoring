using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Test.Unit
{
    [TestFixture()]
    class VelocityCalcTest
    {
        private IVelocityCalc _uut;
        private List<ITrack> _flightList;
        private Track _flight1;
        private Track _flight2;

        [SetUp]

        public void SetUp()
        {
            _uut=new VelocityCalc();

            DateTime dateTime1 = new DateTime(2018, 06, 10, 25, 18, 18);
            DateTime dateTime2 = new DateTime(2018, 06, 10, 25, 18, 20);

            _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Altitude = 19987,
                Timestamp = dateTime1
            };

            _flight2 = new Track
            {
                Tag = "HALLIHALLO",
                XCoordinate = 13000,
                YCoordinate = 13000,
                Altitude = 19987,
                Timestamp = dateTime2
            };

            _flightList = new List<ITrack>()
            {
                _flight1,
                _flight2
            };
        }

        [Test]
        public void VelocityCalc_CorrectVelocity_VelocityIsEqualTo31point623()
        {
            _uut.CalculateVelocity(_flightList);
            Assert.That((_flightList[1].Velocity),Is.EqualTo(31.623));
        }

    }
}
