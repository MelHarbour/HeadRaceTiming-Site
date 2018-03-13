using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Penalty
    {
        public int PenaltyId { get; set; }
        public TimeSpan Value { get; set; }
        public string Reason { get; set; }
        public Crew Crew { get; set; }
    }
}
