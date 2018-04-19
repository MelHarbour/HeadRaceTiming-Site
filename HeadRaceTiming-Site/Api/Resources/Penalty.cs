using System;

namespace HeadRaceTimingSite.Api.Resources
{
    /// <summary>
    /// A penalty to be applied to crew
    /// </summary>
    public class Penalty
    {
        /// <summary>
        /// Unique identifier for the penalty
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The time value of the penalty to be applied
        /// </summary>
        public TimeSpan Value { get; set; }
        /// <summary>
        /// The reason for the penalty
        /// </summary>
        public string Reason { get; set; }
    }
}
