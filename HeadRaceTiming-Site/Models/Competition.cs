﻿using System;
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

        public List<TimingPoint> TimingPoints { get; set; }
        public List<Crew> Crews { get; set; }
        public List<Award> Awards { get; set; }

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
