using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Integration
{
    class IntegrationTest6
    {
        private MainReceiver _reciever;
        private ITrackParsing _parseTracks;
        private ITrack _track;
        private IFilterFlightLimits _filter;
        private IConflictingTracks _compare;
        private CheckCollision _collision;
        private IWrite _write;
        private IWrite _writeToConsole;
        private ITransponderReceiver _receiver;
        private IVelocityCalc _velocityCalc;
        private ICourseCalc _courseCalc;

        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _track = new Track();
            _parseTracks = new TrackParsing(_track);
            _writeToConsole = Substitute.For<WriteToConsole>();
            _filter = new FilterFlightLimits();
            _collision = Substitute.For<CheckCollision>();
            _compare = new CompareTracks();
            _velocityCalc = new VelocityCalc();
            _courseCalc = new CourseCalc();
            _reciever = new MainReceiver(_receiver, _filter, _write, _collision, _compare, _parseTracks);

        }

        [Test]
        public void CheckCollision_VelocityAndCourseAt0Degrees50metersPrSecond_IsCorrect()
        {
            DateTime dateTime1 = new DateTime(2018, 06, 10, 10, 18, 18);
            DateTime dateTime2 = new DateTime(2018, 06, 10, 10, 18, 20);

// der er valgt fly som ligger indenfor flyverummet
            Track _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Timestamp = dateTime1


            };

            List<ITrack> _old = new List<ITrack>
            {
                _flight1
            };

            Track _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12100,
                Altitude = 19987,
                Timestamp = dateTime2

            };

            List<ITrack> _new = new List<ITrack>
            {
                _flight2
            };

            _velocityCalc.CalculateVelocity(_old,_new);
            _courseCalc.CalculateCourse(_old,_new);
            _collision.Received().TrackComparison(_new);
            
        }

        [Test]
        public void CheckCollision_VelocityAndCourseAt90Degrees100metersPrSecond_IsCorrect()
        {
            DateTime dateTime1 = new DateTime(2018, 06, 10, 10, 18, 19);
            DateTime dateTime2 = new DateTime(2018, 06, 10, 10, 18, 20);

           // der er valgt fly som ligger indenfor flyverummet
            Track _flight1 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12000,
                YCoordinate = 12000,
                Timestamp = dateTime1


            };

            List<ITrack> _old = new List<ITrack>
            {
                _flight1
            };

            Track _flight2 = new Track
            {
                Tag = "HEJMEDDIG",
                XCoordinate = 12100,
                YCoordinate = 12000,
                Altitude = 19987,
                Timestamp = dateTime2

            };

            List<ITrack> _new = new List<ITrack>
            {
                _flight2
            };

            _velocityCalc.CalculateVelocity(_old, _new);
            _courseCalc.CalculateCourse(_old, _new);
            _collision.Received().TrackComparison(_old);


        }

    }
}
