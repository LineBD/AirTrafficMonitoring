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
        public void setup()
        {
            _uut = new CourseCalc();


            _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,

            };

            _flight2 = new Track
            {
                Tag = "HALLIHALLO",
                XCoordinate = 13000,
                YCoordinate = 13000,

            };

            _newTracks = new List<ITrack>()
            {
                _flight2
            };

            _oldTracks = new List<ITrack>
            {
                _flight1
            };
        }


        [Test]
            public void CourseCalc_Course_Correct()
            {
                _uut.CalculateCourse(_oldTracks,_newTracks);
                Assert.That(_uut.courseDegrees,Is.EqualTo());
            }

        }
    }
}
