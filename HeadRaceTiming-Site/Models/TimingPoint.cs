using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class TimingPoint
    {
        private List<Result> _results;

        public int TimingPointId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public TimingPoint()
        {

        }

        public TimingPoint(int timingPointId)
        {
            TimingPointId = timingPointId;
        }
        
        public List<Result> Results
        {
            get { return _results ?? (_results = new List<Result>()); }
        }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
