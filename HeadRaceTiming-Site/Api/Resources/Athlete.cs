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
        /// The unique id for the athlete
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The first name of the athlete
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the athlete
        /// </summary>
        public string LastName { get; set; }
    }
}
