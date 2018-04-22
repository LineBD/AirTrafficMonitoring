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
        private List<ITrack> _flightList;
        private ITrack _flight1;
        private ITrack _flight2;

        [SetUp]
        public void setup()
        {
            _uut = new CourseCalc();

        }
        [Test]
        public void CalculateCourse_Course_IsCorrect()
        {

            ITrack track1 = new Track();
            track1.Tag = "KLA";
            track1.XCoordinate = 12000;
            track1.YCoordinate = 12000;

            ITrack track2 = new Track();
            track2.Tag = "KLA";
            track2.XCoordinate = 12000;
            track2.YCoordinate = 12001;

            List<ITrack> currentList = new List<ITrack>();
            currentList.Add(track1);
            List<ITrack> newList = new List<ITrack>();
            newList.Add(track2);

            List<ITrack> CourseList = _uut.CalculateCourse(currentList, newList); //hvorfor???????????
            Assert.That(CourseList[0].Course, Is.EqualTo(90));

         

        }
    }
}
