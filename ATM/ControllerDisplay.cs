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
        private IFilterFlightLimits filter;
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

       public void MyReceiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var myList = e.TransponderData;     
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
            
        }
    }
}

