using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class CourseCalcTest
    {
        private ICourseCalc _uut;
        private List<ITrack> _newTracks;
        private List<ITrack> _oldTracks;
        private ITrack _flight1;
        private ITrack _flight2;

        [SetUp]
        public void SetUp()
        {
            _uut = new CourseCalc();

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
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12001,
                Altitude = 19987,
                Timestamp = dateTime2
            };

            _newTracks = new List<ITrack>
            {
                _flight1
            };

            _oldTracks = new List<ITrack>
            {
                _flight2
            };

        }
        [Test]
        public void CalculateCourse_Course_IsCorrect()
        {

            _uut.CalculateCourse(_newTracks, _oldTracks);
            Assert.That(_uut.courseDegrees, Is.EqualTo(0));

        }
    }
}
