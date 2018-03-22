using HeadRaceTimingSite.Api.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeadRaceTimingSite.Api.Resources
{
    /// <summary>
    /// An individual timing result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The ID of the timing point
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the timing point
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The time of day when the crew passed through the timing point
        /// </summary>
        public TimeSpan TimeOfDay { get; set; }
        /// <summary>
        /// The time since the previous timing point
        /// </summary>
        public TimeSpan? SectionTime { get; set; }
        /// <summary>
        /// The time since the start
        /// </summary>
        public TimeSpan? RunTime { get; set; }
        /// <summary>
        /// The rank of the crew based on their RunTime at that timing point
        /// </summary>
        public string Rank { get; set; }
    }
}
