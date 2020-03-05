using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class CsvCrewViewModel
    {
        public string Name { get; set; }
        [Name("Start Number")]
        public int StartNumber { get; set; }
        [Name("CRI")]
        public int Cri { get; set; }
        [Name("CRI Max")]
        public int CriMax { get; set; }
        [Name("Barnes")]
        public TimeSpan? BarnesTime { get; set; }
        [Name("Hammersmith")]
        public TimeSpan? HammersmithTime { get; set; }
        [Name("Overall Time")]
        public TimeSpan? OverallTime { get; set; }
    }
}
