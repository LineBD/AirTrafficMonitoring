using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace ATM.Test.Unit
{
    [TestFixture]
    class DetectConflictTest
    {
        private DetectConflict uut;
        private CheckCollision checkcollision;
        private IWrite alarm;
        //private ILog log;
        [SetUp]

        public void SetUp()
        {
            // log = Substitute.For<ILog>();
            checkcollision = Substitute.For<CheckCollision>();
            alarm = Substitute.For<IWrite>();
            uut = new DetectConflict(checkcollision);

            //opretter to tracks med forskellig tag for at sammenligne de
            ITrack track1 = new Track();
            track1.Tag = "KLA";

            ITrack track2 = new Track();
            track2.Tag = "RIH";
            //Tilføjer de til liste
            checkcollision.ConflictingFlights.Add(track1);
            checkcollision.ConflictingFlights.Add(track2);
            //Opdaterer
            uut.Update();
        }

            [Test]

            public void UpdateList_WriteTrackOne_CorrectPrint()
        {
            alarm.Received().Write(Arg.Is<List<ITrack>>(trackList => trackList[0].Tag.Contains("KLA")));
        }
        public void UpdateList_WriteTrackTwo_CorrectPrint()
        {
            alarm.Received().Write(Arg.Is<List<ITrack>>(trackList => trackList[1].Tag.Contains("RIH")));
        }

    }
    }
}
