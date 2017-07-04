using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CrewAthlete
    {
        public int CrewAthleteId { get; set; }
        public int Position { get; set; }
        public Crew Crew { get; set; }
        public Athlete Athlete { get; set; }
    }
}
