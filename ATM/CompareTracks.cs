using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CompareTracks : ICompareTracks
    {

        public List<ITrack> ComparedTracks { get; set; }
        private List<ITrack> currentTracks;
        private List<ITrack> oldTracks;
        private IVelocityCalc _velocity;
        private ICourseCalc _course;
        private IWrite _write;
        public CompareTracks()
        {
            ComparedTracks = new List<ITrack>();
            currentTracks = new List<ITrack>();
            oldTracks = new List<ITrack>();
            _velocity = new VelocityCalc();
            _course = new CourseCalc();
            _write = new WriteToConsole();
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
                        ComparedTracks.Add(currenttrack);
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
