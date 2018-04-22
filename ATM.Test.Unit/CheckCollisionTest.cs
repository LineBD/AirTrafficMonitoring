using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class CheckCollisionTest
    {
        private CheckCollision uut;
        [SetUp]
        public void Setup()
        {
            uut = new CheckCollision();
        }
        [TestCase(60000, 65000, 70000, 75000, 7000, 7300, 0)]
        //[TestCase(60000, 65000, 7300, 6999, 0)]
        //[TestCase(60000, 65000, 7300, 7000, 0)]
        //[TestCase(60000, 65000, 7300, 7000, 0)]
        //[TestCase(60000, 65000, 7300, 7000, 0)]
        public void CheckCollision_CompareTracks_DetectCollison(int xcoord1, int xcoord2, int ycoord1, int ycoord2, int verticaldistance1, int verticaldistance2, int count)
        {
            ITrack track1 = new Track();
            track1.XCoordinate = xcoord1;
            track1.YCoordinate = ycoord1;
            track1.Altitude = verticaldistance1;

            ITrack track2 = new Track();
            track2.XCoordinate = xcoord2;
            track2.YCoordinate = ycoord2;
            track2.Altitude = verticaldistance2;

            List<ITrack> listOfTracks = new List<ITrack>();
            listOfTracks.Add(track1);
            listOfTracks.Add(track2);

            uut.TrackComparison(listOfTracks);
            Assert.That(uut.ConflictingFlights.Count, Is.EqualTo(count));
        }
    } }
    
}
