using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CompetitionAdministrator
    {
        private ICollection<CompCompAdmin> _competitions;
        public int CompetitionAdministratorId { get; set; }
        public string NameIdentifier { get; set; }

        public ICollection<CompCompAdmin> Competitions
        {
            get { return _competitions ?? (_competitions = new List<CompCompAdmin>()); }
        }
    }
}
