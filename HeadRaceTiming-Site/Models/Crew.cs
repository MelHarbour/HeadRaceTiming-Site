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

        public TimeSpan? RunTime(TimingPoint startPoint, TimingPoint finishPoint)
        {
            Result start = Results.First(r => r.TimingPointId == startPoint.TimingPointId);
            Result finish = Results.First(r => r.TimingPointId == finishPoint.TimingPointId);

            if (start != null && finish != null)
                return finish.TimeOfDay - start.TimeOfDay;
            else
                return null;
        }

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
