using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CrewAward
    {
        public int CrewAwardId { get; set; }
        public Crew Crew { get; set; }
        public Award Award { get; set; }
    }
}
