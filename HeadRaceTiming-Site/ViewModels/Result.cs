using HeadRaceTimingSite.Models;
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
        public int CriMax { get; set; }
        public string Name { get; set; }
        public string OverallTime { get; set; }
        public string FirstIntermediateTime { get; set; }
        public string SecondIntermediateTime { get; set; }
        public string Rank { get; set; }
        public string FirstIntermediateRank { get; set; }
        public string SecondIntermediateRank { get; set; }
        public Crew.ResultStatus Status { get; set; }
        public bool IsStarted { get; set; }
    }
}
