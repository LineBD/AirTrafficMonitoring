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

           

        }
        [Test]
        public void CalculateCourse_Course0_IsCorrect()
        {
            _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12001,
                Altitude = 19987,

            };

            _newTracks = new List<ITrack>
            {
                _flight1
            };

            _oldTracks = new List<ITrack>
            {
                _flight2
            };

            _uut.CalculateCourse(_newTracks, _oldTracks);
            Assert.That(_flight2.Course, Is.EqualTo(0));

        }

        [Test]
        public void CalculateCourse_Course225_IsCorrect()
        {
            _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 11000,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            _newTracks = new List<ITrack>
            {
                _flight1
            };

            _oldTracks = new List<ITrack>
            {
                _flight2
            };

            _uut.CalculateCourse(_newTracks, _oldTracks);
            Assert.That(_flight2.Course, Is.EqualTo(270));

        }

        [Test]
        public void CalculateCourse_Course90_IsCorrect()
        {
            _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12001,
                YCoordinate = 12000,
                Altitude = 19987,

            };

            _newTracks = new List<ITrack>
            {
                _flight1
            };

            _oldTracks = new List<ITrack>
            {
                _flight2
            };

            _uut.CalculateCourse(_newTracks, _oldTracks);
            Assert.That(Math.Round(_flight2.Course,2), Is.EqualTo(90));

        }

    }
}
