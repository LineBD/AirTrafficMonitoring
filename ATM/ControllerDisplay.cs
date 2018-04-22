using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ControllerDisplay
    {
       // private ITransponderReceiver _receiver;
        private IFilterFlightLimits filter;
        // private List<ITrack> filteredTracks;
        private IWrite writer;
        private CheckCollision compare;
        private ITrackParsing parseTracks;
        private IConflictingTracks conflict;
        private List<ITrack> filteredTracks = new List<ITrack>();



        public ControllerDisplay(ITransponderReceiver transponderReceiver, IFilterFlightLimits _filter, IWrite _writer, CheckCollision _compare, IConflictingTracks _conflict, ITrackParsing _parseTracks)
        {
            transponderReceiver.TransponderDataReady += MyReceiver_TransponderDataReady;
            writer = _writer;
            filter = _filter;
            compare = _compare;
            parseTracks = _parseTracks;
            conflict = _conflict;
        }

        private void MyReceiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;
            // List<ITrack> currentTracks = new List<ITrack>();            
            filteredTracks = new List<ITrack>();

            foreach (var track in myList)
            {
                ITrack trackObject = parseTracks.CreateFlight(track);
                if (filter.Filtering(trackObject) == true)
                {
                    // Tilføjer filtrerede track-objekter til filtreret-liste
                    filteredTracks.Add(trackObject);
                }
            }

            conflict.UpdateTracks(filteredTracks);
            if(filteredTracks.Count > 1)
            {
                compare.TrackComparison(filteredTracks);
            }
            
            // Udregner hastighed og kurs, samt laver en liste med disse objekter. Har dermed en liste med filtrerede objekter med dertilhørende hastighed og kurs.
            //   

            //foreach (var trackwithCourseAndVelocity in filteredTracks)
            //{
            //    comparedTracks.Add(trackwithCourseAndVelocity);
            //        if (comparedTracks.Count > 1)
            //        {
            //            compare.TrackComparison(comparedTracks);
            //            writer.WriteFlight(comparedTracks);
            //        }

            //    }

            //udskriv - velocity og kurs udskrives ikke! men det andre gør. 


            //if (comparedTracks.Count > 1)
            //{
            //    compare.TrackComparison(comparedTracks);
            //    writer.WriteFlight(t,conflict);
            //}
        }
    }
}

