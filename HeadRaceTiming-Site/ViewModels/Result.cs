using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class Result
    {
        public int CrewId { get; set; }
        public int StartNumber { get; set; }
        public string Name { get; set; }
        public TimeSpan? OverallTime { get; set; }
        public TimeSpan? FirstIntermediateTime { get; set; }
        public TimeSpan? SecondIntermediateTime { get; set; }
        public int? Rank { get; set; }
        public int? FirstIntermediateRank { get; set; }
        public int? SecondIntermediateRank { get; set; }
    }
}
