using HeadRaceTimingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels.Api
{
    public class Result
    {
        public int CrewId { get; set; }
        public int StartNumber { get; set; }
        public int CriMax { get; set; }
        public string Name { get; set; }
        public TimeSpan? OverallTime { get; set; }
        public TimeSpan? FirstIntermediateTime { get; set; }
        public TimeSpan? SecondIntermediateTime { get; set; }
        public string Rank { get; set; }
        public string FirstIntermediateRank { get; set; }
        public string SecondIntermediateRank { get; set; }
        public HeadRaceTimingSite.Models.Crew.ResultStatus Status { get; set; }
        public bool IsStarted { get; set; }
        public bool IsTimeOnly { get; set; }
        public bool IsFinished { get; set; }
    }
}
