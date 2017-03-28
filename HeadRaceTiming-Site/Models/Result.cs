﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Result
    {
        public Result() { }

        public Result(TimingPoint timingPoint, Crew crew, TimeSpan timeOfDay)
        {
            TimingPoint = timingPoint;
            TimingPointId = TimingPoint.TimingPointId;
            Crew = crew;
            CrewId = Crew.CrewId;
            TimeOfDay = timeOfDay;
        }

        public int ResultId { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        
        public int CrewId { get; set; }
        public Crew Crew { get; set; }

        public int TimingPointId { get; set; }
        public TimingPoint TimingPoint { get; set; }
    }
}