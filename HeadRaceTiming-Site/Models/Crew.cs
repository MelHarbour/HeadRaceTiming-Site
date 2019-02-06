using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Crew
    {
        private List<Result> _results;
        private List<CrewAthlete> _athletes;
        private List<CrewAward> _awards;
        private List<Penalty> _penalties;

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

        /// <summary>
        /// Overall time from start to finish. Includes any penalties that have been applied to the crew.
        /// </summary>
        public TimeSpan? OverallTime
        {
            get
            {
                if (Competition.TimingPoints.Count == 0)
                    return null;

                TimeSpan? runTime = RunTime(Competition.TimingPoints[0], Competition.TimingPoints.Last());
                if (runTime.HasValue)
                {
                    foreach (Penalty penalty in Penalties)
                    {
                        runTime += penalty.Value;
                    }
                }
                return runTime;
            }
        }

        /// <summary>
        /// Run time between two timing points. Does not include any penalties that have been applied.
        /// </summary>
        /// <param name="startPointId">A timing point id marking the start of the section.</param>
        /// <param name="finishPointId">A timing point id marking the end of the section.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Run time between two timing points. Does not include any penalties that have been applied.
        /// </summary>
        /// <param name="startPoint">Timing point marking the start of the section.</param>
        /// <param name="finishPoint">Timing point marking the end of the section.</param>
        /// <returns></returns>
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

        public double AverageAge
        {
            get
            {
                return Athletes.Select(x => x.Age).Average();
            }
        }

        public MastersCategory MastersCategory {
            get
            {
                if (Athletes.Any(x => x.Age < 27))
                    return MastersCategory.None;
                else
                {
                    double averageAge = AverageAge;
                    if (averageAge >= 85)
                        return MastersCategory.K;
                    if (averageAge >= 80)
                        return MastersCategory.J;
                    if (averageAge >= 75)
                        return MastersCategory.I;
                    if (averageAge >= 70)
                        return MastersCategory.H;
                    if (averageAge >= 65)
                        return MastersCategory.G;
                    if (averageAge >= 60)
                        return MastersCategory.F;
                    if (averageAge >= 55)
                        return MastersCategory.E;
                    if (averageAge >= 50)
                        return MastersCategory.D;
                    if (averageAge >= 43)
                        return MastersCategory.C;
                    if (averageAge >= 36)
                        return MastersCategory.B;
                    if (averageAge >= 27)
                        return MastersCategory.A;
                    else
                        return MastersCategory.None; // Should never reach this
                }
            }
        }

        public int CalculateMastersHandicap()
        {
            if (MastersCategory == MastersCategory.None)
                throw new InvalidOperationException();

            foreach (CrewAward award in Awards)
            {
                if (award.Award.IsMasters)
                {
                    return 0;
                }
            }
            throw new InvalidOperationException();
        }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public List<Result> Results
        {
            get { return _results ?? (_results = new List<Result>()); }
        }
        public List<CrewAthlete> Athletes
        {
            get { return _athletes ?? (_athletes = new List<CrewAthlete>()); }
        }
        public List<CrewAward> Awards
        {
            get { return _awards ?? (_awards = new List<CrewAward>()); }
        }
        public List<Penalty> Penalties
        {
            get { return _penalties ?? (_penalties = new List<Penalty>()); }
        }

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
    public enum MastersCategory
    {
        None,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K
    }
}
