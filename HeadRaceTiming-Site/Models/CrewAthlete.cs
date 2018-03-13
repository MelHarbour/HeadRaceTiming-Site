using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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
                if (Crew.BoatClass == BoatClass.SingleScull)
                    return "Sculler";
                if (Position == 1)
                    return "Bow";
                if ((Crew.BoatClass == BoatClass.Eight && Position == 8)
                    || ((Crew.BoatClass == BoatClass.CoxedFour || Crew.BoatClass == BoatClass.CoxlessFour || Crew.BoatClass == BoatClass.QuadScull) && Position == 4)
                    || ((Crew.BoatClass == BoatClass.CoxedPair || Crew.BoatClass == BoatClass.CoxlessPair || Crew.BoatClass == BoatClass.DoubleScull) && Position == 2))
                    return "Stroke";
                if ((Crew.BoatClass == BoatClass.Eight && Position == 9)
                    || (Crew.BoatClass == BoatClass.CoxedFour && Position == 5)
                    || (Crew.BoatClass == BoatClass.CoxedPair && Position == 3))
                    return "Cox";
                else
                    return string.Format(CultureInfo.CurrentCulture, "{0}", Position);
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
