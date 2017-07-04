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

        public int Placing(TimingPoint point)
        {
            return Competition.Crews.OrderBy(x => x.RunTime(this.Competition.TimingPoints.OrderBy(t => t.Order).First(), point)).ToList().IndexOf(this) + 1;
        }

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public List<CrewAthlete> Athletes { get; set; }
    }
}
