using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConflictingTracks : IConflictingTracks
    {

        //Skal trackinfo i gennem trackparsing og controller 2 x - så vi får returneret to lister vi kan sammenligne?? HVORDAN gør vi det


        private List<ITrack> currentTracks;
        private List<ITrack> oldTracks;
        private VelocityCalc _velocity;
        private CourseCalc _course;
        private IWrite _write;
        private CheckCollision _compare;

        public ConflictingTracks()
        {
            currentTracks = new List<ITrack>();
            oldTracks = new List<ITrack>();
            _velocity = new VelocityCalc();
            _course = new CourseCalc();
            _write = new WriteToConsole();
            _compare = new CheckCollision();

        }
        public void UpdateTracks(List<ITrack> newTracks)
        {

            foreach (var newtracks in newTracks)
            {
                if (!currentTracks.Exists(x => x.Tag == newtracks.Tag))
                {
                    currentTracks.Add(newtracks);
                }

                else
                {
                    if (!oldTracks.Exists(x => x.Tag == newtracks.Tag))
                    {
                        var track = currentTracks.Find(x => x.Tag == newtracks.Tag);
                        var index = currentTracks.IndexOf(track);
                        oldTracks.Add(track);
                        currentTracks[index] = newtracks;

                    }
                    else
                    {
                        var oldtrack = oldTracks.Find(x => x.Tag == newtracks.Tag);
                        var indexInOldTrack = oldTracks.IndexOf(oldtrack);


                        var track = currentTracks.Find(x => x.Tag == newtracks.Tag);
                        var index = currentTracks.IndexOf(track);


                        oldTracks[indexInOldTrack] = track;
                        currentTracks[index] = newtracks;
                    }
                }
            }
            foreach (var oldtrack in oldTracks)
            {
                foreach (var currenttrack in currentTracks)
                {
                    if (oldtrack.Tag == currenttrack.Tag)
                    {
                        _velocity.CalculateVelocity(oldTracks,currentTracks);
                        _course.CalculateCourse(oldTracks, currentTracks);
                    }
                }

            }
            
            //Konflikthåndtering (Kun for currenttracks)

            // udskrivning
            _write.Write(currentTracks);
                       //Udskriv!
        }
       

       }
}
