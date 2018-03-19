using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels.Api
{
    public class CrewResult
    {
        public string TimingPoint { get; set; }
        public string TimeOfDay { get; set; }
        public string SectionTime { get; set; }
        public string RunTime { get; set; }
        public string Rank { get; set; }
    }
}
