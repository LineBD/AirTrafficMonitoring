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

        public void Setup()
        {
            uut = new ConflictingTracks();

        }
        [Test]
        [TestCase("ABD", "ABC", 0)]
        [TestCase("ABC", "ABD", 0)]
        [TestCase("ABC", "ABC", 2)]

        public void ConflicingTracks_CheckTags_IsCorrect(string tag1, string tag2, int count)
        {
            ITrack track1 = new Track();
            track1.Tag = tag1;

            ITrack track2 = new Track();
            track2.Tag = tag2;

           List<ITrack> listOfTracks = new List<ITrack>();
            listOfTracks.Add(track1);
            listOfTracks.Add(track2);

            List<ITrack> list = uut.UpdateTracks(listOfTracks);
            Assert.That(list.Count, Is.EqualTo(count));
        }

    }


    }
}
