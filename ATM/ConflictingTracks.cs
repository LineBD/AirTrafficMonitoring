using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConflictingTracks: IConflictingTracks
    {

        //Skal trackinfo i gennem trackparsing og controller 2 x - så vi får returneret to lister vi kan sammenligne?? HVORDAN gør vi det
       
        
        private List<ITrack> currentTracks;
        private VelocityCalc _velocity;
        private CourseCalc _course;

        public ConflictingTracks()
        {
            currentTracks = new List<ITrack>();
            
            _velocity = new VelocityCalc();
            _course = new CourseCalc();
           
        }
        public void UpdateTracks(List<ITrack> newTracks, List<ITrack> currentTracks)
        {
            foreach (var newtracks in newTracks)
            {
                foreach (var oldtracks in currentTracks)
                {
                    if (newtracks.Tag == oldtracks.Tag)
                    {
                        newtracks.Velocity = _velocity.CalculateVelocity(currentTracks,newTracks);
                        newtracks.Course = _course.CalculateCourse(currentTracks,newTracks);   
                    }
                }
            }
            currentTracks = newTracks;
            
           
            //Udskriv!
        }
        public override string ToString()
        {
            return "\nVelocity: " +_velocity + "\nCourse: "+_course;

        }
    }
}
