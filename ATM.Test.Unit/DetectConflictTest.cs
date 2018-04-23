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
        private IWrite log;
        private List<ITrack> tracklList1;
        private List<ITrack> tracklList2;
        [SetUp]

        public void SetUp()
        {
            // log = Substitute.For<ILog>();
            //checkcollision = Substitute.For<CheckCollision>();
            //alarm = Substitute.For<IWrite>();
            //uut = new DetectConflict(checkcollision);

            ////opretter to tracks med forskellig tag for at sammenligne de
            //ITrack track1 = new Track();
            //track1.Tag = "KLA";

            //ITrack track2 = new Track();
            //track2.Tag = "RIH";
            ////Tilføjer de til liste
            //checkcollision.ConflictingFlights.Add(track1);
            //checkcollision.ConflictingFlights.Add(track2);
            ////Opdaterer
            //uut.Update();
            log = Substitute.For<IWrite>();
            alarm = Substitute.For<IWrite>();
            checkcollision = Substitute.For<CheckCollision>();
            uut = new DetectConflict(checkcollision);
            //opretter to tracks med forskellig tag for at sammenligne de

            DateTime dateTime1 = new DateTime(2018, 06, 10, 10, 18, 18);
            DateTime dateTime2 = new DateTime(2018, 06, 10, 10, 18, 20);

            ITrack track1 = new Track();
            track1.Tag = "KLA123";
            track1.Timestamp = dateTime1;
                

            ITrack track2 = new Track();
            track2.Tag = "RIH456";
            track1.Timestamp = dateTime2;

            tracklList1.Add(track1);

            tracklList2.Add(track2);
        }

        //[Test]
        //public void WriteToFile_WriteBothTracks_Correct()
        //{
        //    uut.Received().Wri
        //}

            [Test]

        public void UpdateList_WriteTrackOne_CorrectPrint()
        {
            alarm.Received().Write(tracklList1[0].Tag.Contains("KLA"));
        }
        [Test]
        public void UpdateList_WriteTrackTwo_CorrectPrint()
        {
            alarm.Received().Write(Arg.Is<List<ITrack>>(trackList => trackList[1].Tag.Contains("RIH")));
        }
        [Test]
        public void Update_TimeStamp_CorrectYear()
        {
            var timeStamp = checkcollision.ConflictingFlights[0].Timestamp;
            alarm.Received().Write(Arg.Is<List<ITrack>>(tracklist => tracklist[0].Timestamp.Equals(timeStamp)));
        }

    }

   }