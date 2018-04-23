using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Test.Unit
{
    [TestFixture]
    class ConflictingTracksTest
    {
        private ConflictingTracks uut;

        [SetUp]
        public void SetUp()
        {
            uut = new ConflictingTracks();

        }
        
        [TestCase("ABD", "ABC", 0)]
        [TestCase("ABC", "ABD", 0)]
        [TestCase("ABC", "ABC", 1)]

        public void ConflicingTracks_CheckTags_IsCorrect(string tag1, string tag2, int count)
        {
            ITrack track1 = new Track();
            track1.Tag = tag1;
            track1.XCoordinate = 12000;
            track1.YCoordinate = 12000;

            ITrack track2 = new Track();
            track2.Tag = tag2;
            track2.XCoordinate = 13000;
            track2.YCoordinate = 13000;

            List<ITrack> listOfTracks = new List<ITrack>();
            listOfTracks.Add(track1);
            listOfTracks.Add(track2);

            uut.UpdateTracks(listOfTracks);

            Assert.That(uut.ComparedTracks.Count, Is.EqualTo(count));
        }

    }


    }