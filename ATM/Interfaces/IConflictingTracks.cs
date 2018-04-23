﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IConflictingTracks
    {
        void UpdateTracks(List<ITrack> newTracks);
        List<ITrack> ComparedTracks { get; set; }
        //string ToString();

    }
}
