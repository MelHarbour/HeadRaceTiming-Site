using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }

        public List<Section> Sections { get; set; }
        public List<Crew> Crews { get; set; }
    }
}
