using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalc: ICourseCalc

    {
        private double CourseDegrees;
        public double CalculateCourse(List<ITrack> currentTracks, List<ITrack> newTracks)
        {
            List<ITrack> courseList = new List<ITrack>();
            foreach (var track in newTracks)
            {
                for (int i = 0; i < currentTracks.Count; i++)
                {
                    if (track.Tag == currentTracks[i].Tag)
                    {
                        int xCoordinate = track.XCoordinate - currentTracks[i].XCoordinate;
                        int yCoordinate = track.YCoordinate - currentTracks[i].YCoordinate;

                        double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
                        double CourseDegrees = theta * (180 / Math.PI);
                        track.Course = CourseDegrees;


                    }
                }
                courseList.Add(track);
            }
            return CourseDegrees;
        }
    }
}
//public double CalculateCourses(List<ITrack> _tracklist)
//{
//    int x1coordinate = _tracklist[1].XCoordinate;
//    int x2coordinate = _tracklist[2].XCoordinate;
//    int y1coordinate = _tracklist[1].YCoordinate;
//    int y2coordinate = _tracklist[2].YCoordinate;

//    int xCoordinate = x2coordinate - x1coordinate;
//    int yCoordinate = y2coordinate - y1coordinate;

//    double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
//    double CourseDegrees = theta * (180 / Math.PI);
//    return CourseDegrees;
//}
//public void CalculateCourse(int x1Coordinate, int x2Coordinate, int y1Coordinate, int y2Coordinate)
//{
//    double xCoordinate = x2Coordinate - x1Coordinate;
//    double yCoordinate = y2Coordinate - y1Coordinate;

//    // https://en.wikipedia.org/wiki/Polar_coordinate_system

//    double theta = Math.Atan2(xCoordinate, yCoordinate);

//    double CourseDegrees = theta * (180 / Math.PI);


//}
//public class CourseCalc : ICourseCalc
//{
//    // Mangler at få listen med...
//    public double CalculateCourse(ITrack oldtrack, ITrack newtrack)
//    {
//        int x1coordinate = oldtrack.XCoordinate;
//        int x2coordinate = newtrack.XCoordinate;
//        int y1coordinate = oldtrack.YCoordinate;
//        int y2coordinate = newtrack.YCoordinate;

//        int xCoordinate = x2coordinate - x1coordinate;
//        int yCoordinate = y2coordinate - y1coordinate;

//        double theta = Convert.ToDouble(Math.Atan2(yCoordinate, xCoordinate) - Math.Atan2(90000, 0));
//        double CourseDegrees = theta * (180 / Math.PI);
//        return CourseDegrees;
//public double CalculateCourse(ITrack track1, ITrack track2)
//{
//    int x1coordinate = track1.XCoordinate;
//    int x2coordinate = track2.XCoordinate;
//    int y1coordinate = track1.YCoordinate;
//    int y2coordinate = track2.YCoordinate;

//    int xCoordinate = x2coordinate - x1coordinate;
//    int yCoordinate = y2coordinate - y1coordinate;

//    double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
//    double CourseDegrees = theta * (180 / Math.PI);
//    return CourseDegrees;


//public double CalculateCourse(ITrack track)
//{
//    int xCoordinate = track.XCoordinate;
//    int yCoordinate = track.YCoordinate;
//    double theta = Convert.ToDouble(Math.Atan2(xCoordinate, yCoordinate));
//    double CourseDegrees = theta * (180 / Math.PI);

//return CourseDegrees;



//    }

