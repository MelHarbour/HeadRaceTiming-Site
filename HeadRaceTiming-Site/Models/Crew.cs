﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Crew
    {
        public int CrewId { get; set; }
        public string Name { get; set; }
        public int StartNumber { get; set; }
        /// <summary>
        /// This is the three letter code from British Rowing for the crew's club.
        /// </summary>
        public string ClubCode { get; set; }
        /// <summary>
        /// This is the Crew ID as used by BROE
        /// </summary>
        public int? BroeCrewId { get; set; }

        public TimeSpan? OverallTime
        {
            get
            {
                return RunTime(this.Competition.TimingPoints[0], this.Competition.TimingPoints.Last());
            }
        }

        public TimeSpan? RunTime(int startPointId, int finishPointId)
        {
            if (Results == null)
                return null;

            Result start = Results.First(r => r.TimingPointId == startPointId);
            Result finish = Results.First(r => r.TimingPointId == finishPointId);

            if (start != null && finish != null)
                return TimeSpan.FromSeconds(Math.Round((finish.TimeOfDay - start.TimeOfDay).TotalSeconds, 1));
            else
                return null;
        }

        public TimeSpan? RunTime(TimingPoint startPoint, TimingPoint finishPoint)
        {
            if (Results == null)
                return null;

            return RunTime(startPoint.TimingPointId, finishPoint.TimingPointId);
        }

        public TimingPoint StartPoint
        {
            get
            {
                return this.Competition.TimingPoints.First();
            }
        }

        public string Rank(IEnumerable<Crew> results, TimingPoint finishTimingPoint)
        {
            return Rank(results, StartPoint, finishTimingPoint);
        }

        public string Rank(IEnumerable<Crew> results, TimingPoint startTimingPoint, TimingPoint finishTimingPoint)
        {
            int i = 1;

            Crew previous = null;
            string returnString = String.Empty;
            bool equalTime = false;

            foreach (Crew result in results)
            {
                if (previous != null && previous.RunTime(startTimingPoint, finishTimingPoint) != result.RunTime(startTimingPoint, finishTimingPoint))
                    i++;
                if (result == this)
                {
                    returnString = i.ToString();
                }
                else
                {
                    if (result.RunTime(startTimingPoint, finishTimingPoint) == this.RunTime(startTimingPoint, finishTimingPoint))
                        equalTime = true;
                }
                previous = result;
            }
            return returnString + (equalTime ? "=" : String.Empty);
        }

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public List<CrewAthlete> Athletes { get; set; }
    }
}
