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

            _flightList = new List<ITrack>()
            {
                _flight1,
                _flight2
            }

            [Test];
            public void CourseCalc_Course_Correct()
            {

            }

        }
    }
}
