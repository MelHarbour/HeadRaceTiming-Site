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

        public List<Result> Results { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
