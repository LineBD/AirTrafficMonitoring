using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConflictingTracks
    {

        //Skal trackinfo i gennem trackparsing og controller 2 x - så vi får returneret to lister vi kan sammenligne?? HVORDAN gør vi det
       
        private Track _Track;
        private List<ITrack> _currenttracks;
        private List<ITrack> _newtrack;
        private VelocityCalc _velocity;
        private CourseCalc _course;

        public ConflictingTracks()
        {
            _currenttracks = new List<ITrack>();
            
            _velocity = new VelocityCalc();
            _course = new CourseCalc();
           
        }
        public void UpdateTracks(List<ITrack> newTrack)
        {
            foreach (var newtracks in newTrack)
            {
                foreach (var oldtracks in _currenttracks)
                {
                    if (newtracks.Tag == oldtracks.Tag)
                    {
                        newtracks.Velocity = _velocity.CalculateVelocity(newtracks, oldtracks);
                        newtracks.Course = _course.CalculateCourse(newtracks, oldtracks);   
                    }
                }
            }
            _currenttracks = newTrack;
            //Udskriv!
        }
    }
}
