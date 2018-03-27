using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public bool ShowFirstIntermediate { get; set; }
        public bool ShowSecondIntermediate { get; set; }
        public int BackgroundArgb
        {
            get { return BackgroundColor.ToArgb(); }
            set { BackgroundColor = Color.FromArgb(value); }
        }

        public int TextArgb
        {
            get { return TextColor.ToArgb(); }
            set { TextColor = Color.FromArgb(value); }
        }
        public string ImageUriText { get; set; }
        /// <summary>
        /// Used for things like URLs
        /// </summary>
        public string FriendlyName { get; set; }
        public bool IsVisible { get; set; }

        [NotMapped]
        public Color BackgroundColor { get; set; }
        [NotMapped]
        public Color TextColor { get; set; }

        public string BackgroundHtmlColor
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0:X6}", BackgroundColor.ToArgb());
            }
        }

        public string TextHtmlColor
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0:X6}", TextColor.ToArgb());
            }
        }

        public ICollection<CompCompAdmin> Administrators { get; set; }
        public List<TimingPoint> TimingPoints { get; set; }
        public List<Crew> Crews { get; set; }
        public List<Award> Awards { get; set; }

        public string FirstIntermediateName
        {
            get
            {
                if (TimingPoints.Count > 2)
                    return TimingPoints[1].Name;
                else
                    return String.Empty;
            }
        }

        public string SecondIntermediateName
        {
            get
            {
                if (TimingPoints.Count > 3)
                    return TimingPoints[2].Name;
                else
                    return String.Empty;
            }
        }

        public int? FirstIntermediateId
        {
            get
            {
                if (TimingPoints.Count > 2)
                    return TimingPoints[1].TimingPointId;
                else
                    return null;
            }
        }

        public int? SecondIntermediateId
        {
            get
            {
                if (TimingPoints.Count > 3)
                    return TimingPoints[2].TimingPointId;
                else
                    return null;
            }
        }
    }
}
