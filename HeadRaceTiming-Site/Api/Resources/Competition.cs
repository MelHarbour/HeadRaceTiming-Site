using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Api.Resources
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public bool ShowFirstIntermediate { get; set; }
        public bool ShowSecondIntermediate { get; set; }
        public int BackgroundArgb { get; set; }
        public int TextArgb { get; set; }
        /// <summary>
        /// Used for things like URLs
        /// </summary>
        public string FriendlyName { get; set; }
        public bool IsVisible { get; set; }
        public string DialogInformation { get; set; }
        public string BackgroundHtmlColor { get; set; }
        public string TextHtmlColor { get; set; }
        public string FirstIntermediateName { get; set; }
        public string SecondIntermediateName { get; set; }
        public int? FirstIntermediateId { get; set; }
        public int? SecondIntermediateId { get; set; }
    }
}
