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
        private List<ITrack> _newTracks;
        private List<ITrack> _oldtTracks;
        private Track _flight1;
        private Track _flight2;

        [SetUp]

        public void SetUp()
        {
            _uut = new VelocityCalc();

            DateTime dateTime1 = new DateTime(2018, 06, 10, 10, 18, 20);
            DateTime dateTime2 = new DateTime(2018, 06, 10, 10, 18, 18);

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

            _newTracks = new List<ITrack>
            {
                _flight1
            };

            _oldtTracks = new List<ITrack>
            {
                _flight2
            };

        }

        [Test]
        public void VelocityCalc_CorrectVelocity_VelocityIsEqualTo31point623()
        {

            _uut.CalculateVelocity(_oldtTracks, _newTracks);
            
            //Assert.That(_uut.Returns(),Is.EqualTo(31.623));


        }

    }
}
