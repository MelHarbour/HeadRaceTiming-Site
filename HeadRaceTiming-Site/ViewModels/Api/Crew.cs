using HeadRaceTimingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels.Api
{
    /// <summary>
    /// A crew entered in a race
    /// </summary>
    public class Crew
    {
        /// <summary>
        /// The BROE ID for the crew
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the crew
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The start number of the crew
        /// </summary>
        public int StartNumber { get; set; }
        /// <summary>
        /// The three letter code for the club of the crew
        /// </summary>
        public string ClubCode { get; set; }
        /// <summary>
        /// The status of the crew's result (for example DNF)
        /// </summary>
        public Models.Crew.ResultStatus Status { get;set; }
        /// <summary>
        /// Whether the crew is Time Only
        /// </summary>
        public bool IsTimeOnly { get; set; }
        /// <summary>
        /// The boat class of the crew
        /// </summary>
        public Models.BoatClass BoatClass { get; set; }
    }
}
