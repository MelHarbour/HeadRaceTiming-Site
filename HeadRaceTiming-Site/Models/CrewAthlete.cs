using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class CrewAthlete
    {
        public int CrewAthleteId { get; set; }
        public int Position { get; set; }
        public Crew Crew { get; set; }
        public Athlete Athlete { get; set; }
        public string PositionDescription {
            get
            {
                if (Position == 1)
                    return "Bow";
                if (Position == 8)
                    return "Stroke";
                if (Position == 9)
                    return "Cox";
                else
                    return Position.ToString();
            }
        }
        /// <summary>
        /// PRI as extracted from British Rowing
        /// </summary>
        public int Pri { get; set; }
        /// <summary>
        /// PRI Max as extracted from British Rowing
        /// </summary>
        public int PriMax { get; set; }
    }
}
