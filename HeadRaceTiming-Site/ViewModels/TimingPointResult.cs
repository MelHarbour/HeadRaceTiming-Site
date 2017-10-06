using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class TimingPointResult
    {
        public int StartNumber { get; set; }
        public string Name { get; set; }
        public TimeSpan? RunTime { get; set; }
        public string Rank { get; set; }
    }
}
