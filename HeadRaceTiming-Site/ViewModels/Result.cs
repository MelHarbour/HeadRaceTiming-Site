using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class Result
    {
        public int StartNumber { get; set; }
        public string Name { get; set; }
        public TimeSpan? OverallTime { get; set; }
    }
}
