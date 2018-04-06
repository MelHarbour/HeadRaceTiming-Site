using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Athlete
    {
        private List<CrewAthlete> _crews;

        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipNumber { get; set; }

        public List<CrewAthlete> Crews
        {
            get { return _crews ?? (_crews = new List<CrewAthlete>()); }
        }
    }
}
