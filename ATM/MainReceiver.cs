﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class MainReceiver
    {
        private IFilterFlightLimits filter;
        private IWrite writer;
        private CheckCollision checkcollision;
        private ITrackParsing parseTracks;
        private ICompareTracks comparetracks;
        private List<ITrack> filteredTracks = new List<ITrack>();



        public MainReceiver(ITransponderReceiver transponderReceiver, IFilterFlightLimits _filter, IWrite _writer, CheckCollision _checkcollision, ICompareTracks _comparetracks, ITrackParsing _parseTracks)
        {
            transponderReceiver.TransponderDataReady += MyReceiver_TransponderDataReady;
            writer = _writer;
            filter = _filter;
            checkcollision = _checkcollision;
            parseTracks = _parseTracks;
            comparetracks = _comparetracks;
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

            comparetracks.UpdateTracks(filteredTracks);
            if (filteredTracks.Count > 1)
            {
                checkcollision.TrackComparison(filteredTracks);
            }

        }
    }
}
