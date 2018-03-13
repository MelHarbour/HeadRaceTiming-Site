﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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
        /// <summary>
        /// The status of the crew's result. Defaults to Ok
        /// </summary>
        public ResultStatus Status { get; set; }
        public bool IsTimeOnly { get; set; }
        public BoatClass BoatClass { get; set; }

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

            Result start = Results.FirstOrDefault(r => r.TimingPointId == startPointId);
            Result finish = Results.FirstOrDefault(r => r.TimingPointId == finishPointId);

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

        /// <summary>
        /// Returns the rank of the crew within a set of crews, based on a start and finish timing point.
        /// </summary>
        /// <param name="results">The list of crews to rank within. Required to contain the crew, and to be pre-sorted into order by whichever timing point is being used.</param>
        /// <param name="startTimingPoint">The start timing point.</param>
        /// <param name="finishTimingPoint">The finish timing point.</param>
        /// <returns></returns>
        public string Rank(IList<Crew> results, TimingPoint startTimingPoint, TimingPoint finishTimingPoint)
        {
            string returnString = String.Empty;
            int rank = 1;

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].IsTimeOnly)
                    continue;

                if (results[i] == this)
                {
                    if (i == 0)
                        if (results.Count > 1)
                        {
                            return rank.ToString(CultureInfo.CurrentCulture) +
                                (results[i + 1].RunTime(startTimingPoint, finishTimingPoint) == results[i].RunTime(startTimingPoint, finishTimingPoint) ? "=" : String.Empty);
                        }
                        else
                        {
                            return rank.ToString(CultureInfo.CurrentCulture);
                        }
                    else if (results[i - 1].RunTime(startTimingPoint, finishTimingPoint) == results[i].RunTime(startTimingPoint, finishTimingPoint))
                        return rank.ToString(CultureInfo.CurrentCulture) + "=";
                    else
                    {
                        rank++;
                        if (i < results.Count - 1)
                            return rank.ToString(CultureInfo.CurrentCulture) +
                                (results[i + 1].RunTime(startTimingPoint, finishTimingPoint) == results[i].RunTime(startTimingPoint, finishTimingPoint) ? "=" : String.Empty);
                        else
                            return rank.ToString(CultureInfo.CurrentCulture);
                    }
                }
                if (i == 0 || (results[i - 1].RunTime(startTimingPoint, finishTimingPoint) == results[i].RunTime(startTimingPoint, finishTimingPoint)))
                    continue;
                else
                    rank++;
            }
            return String.Empty;
        }

        /// <summary>
        /// CRI, calculated as the sum of the PRI of the athletes
        /// </summary>
        public int Cri
        {
            get { return Athletes != null ? Athletes.Where(x => x.PositionDescription != "Cox").Select(x => x.Pri).Sum() : 0; }
        }

        /// <summary>
        /// CRI Max, calculated as the sum of the PRI Max of the athletes
        /// </summary>
        public int CriMax
        {
            get { return Athletes != null ? Athletes.Where(x => x.PositionDescription != "Cox").Select(x => x.PriMax).Sum() : 0; }
        }

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public List<CrewAthlete> Athletes { get; set; }
        public List<CrewAward> Awards { get; set; }
        public List<Penalty> Penalties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "Not a plural")]
        public enum ResultStatus
        {
            /// <summary>
            /// Result is normal
            /// </summary>
            Ok,
            /// <summary>
            /// Result is missing
            /// </summary>
            Missing,
            /// <summary>
            /// Did not finish
            /// </summary>
            Dnf,
            /// <summary>
            /// Disqualified
            /// </summary>
            Dsq,
            /// <summary>
            /// Did not start
            /// </summary>
            Dns
        }
    }
}
