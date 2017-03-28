using System;
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
                return finish.TimeOfDay - start.TimeOfDay;
            else
                return null;
        }

        public TimeSpan? RunTime(TimingPoint startPoint, TimingPoint finishPoint)
        {
            if (Results == null)
                return null;

            return RunTime(startPoint.TimingPointId, finishPoint.TimingPointId);
        }

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
