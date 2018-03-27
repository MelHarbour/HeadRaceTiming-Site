using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CompCompAdmin
    {
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int CompetitionAdministratorId { get; set; }
        public CompetitionAdministrator CompetitionAdministrator { get; set; }
    }
}
