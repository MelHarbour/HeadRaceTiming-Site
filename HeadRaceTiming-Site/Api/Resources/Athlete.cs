using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Api.Resources
{
    /// <summary>
    /// An athlete rowing in a crew
    /// </summary>
    public class Athlete
    {
        /// <summary>
        /// The first name of the athlete
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the athlete
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The British Rowing membership number of the athlete
        /// </summary>
        public string MembershipNumber { get; set; }
        /// <summary>
        /// The position within a crew that the athlete occupies
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The PRI of the athlete in the crew
        /// </summary>
        public int Pri { get; set; }
        /// <summary>
        /// The PRI Max of the athlete in the crew
        /// </summary>
        public int PriMax { get; set; }
    }
}
