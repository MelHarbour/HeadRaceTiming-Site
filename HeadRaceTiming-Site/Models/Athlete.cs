using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Athlete
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// PRI as extracted from British Rowing
        /// </summary>
        public int Pri { get; set; }
        /// <summary>
        /// PRI Max as extracted from British Rowing
        /// </summary>
        public int PriMax { get; set; }

        public List<CrewAthlete> Crews { get; set; }
    }
}
