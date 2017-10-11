﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class CrewResult
    {
        public string TimingPoint { get; set; }
        public TimeSpan? TimeOfDay { get; set; }
        public TimeSpan? SectionTime { get; set; }
        public TimeSpan? RunTime { get; set; }
        public string Rank { get; set; }
    }
}