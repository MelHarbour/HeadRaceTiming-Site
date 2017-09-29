using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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

        [NotMapped]
        public Color BackgroundColor { get; set; }
        [NotMapped]
        public Color TextColor { get; set; }

        public string BackgroundHtmlColor
        {
            get
            {
                return BackgroundColor.ToArgb().ToString("X6");
            }
        }

        public string TextHtmlColor
        {
            get
            {
                return TextColor.ToArgb().ToString("X6");
            }
        }

        public List<TimingPoint> TimingPoints { get; set; }
        public List<Crew> Crews { get; set; }

        public string FirstIntermediateName
        {
            get
            {
                return this.TimingPoints[1].Name;
            }
        }

        public string SecondIntermediateName
        {
            get
            {
                return this.TimingPoints[2].Name;
            }
        }
    }
}
