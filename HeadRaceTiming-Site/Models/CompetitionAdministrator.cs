using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CompetitionAdministrator
    {
        public int CompetitionAdministratorId { get; set; }
        public string NameIdentifier { get; set; }

        public ICollection<CompCompAdmin> Competitions { get; set; }
    }
}
