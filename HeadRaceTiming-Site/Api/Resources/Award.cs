using System;

namespace HeadRaceTimingSite.Api.Resources
{
    /// <summary>
    /// A penalty to be applied to crew
    /// </summary>
    public class Award
    {
        /// <summary>
        /// Unique identifier for the award
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The title of the award
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Whether the award is a Masters award (and hence subject to handicapping).
        /// </summary>
        public bool IsMasters { get; set; }
    }
}
