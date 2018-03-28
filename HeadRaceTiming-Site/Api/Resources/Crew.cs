using HeadRaceTimingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Api.Resources
{
    /// <summary>
    /// A crew entered in a race
    /// </summary>
    public class Crew
    {
        /// <summary>
        /// Constructor for the class
        /// </summary>
        public Crew()
        {
            Results = new List<Result>();
        }
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
        /// <summary>
        /// The overall time of the crew. Calculated from the individual results for that crew, for convenience
        /// </summary>
        public TimeSpan? OverallTime { get; set; }
        /// <summary>
        /// Whether the crew has started or not
        /// </summary>
        public bool IsStarted { get; set; }
        /// <summary>
        /// Whether the crew has finished or not
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// The CRI of the crew
        /// </summary>
        public int Cri { get; set; }
        /// <summary>
        /// The CRI Max of the crew
        /// </summary>
        public int CriMax { get; set; }
        /// <summary>
        /// The overall rank of the crew
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// List of the results for the crew
        /// </summary>
        public List<Result> Results { get; private set; }
        /// <summary>
        /// The time of the last update to the crew's times
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}
