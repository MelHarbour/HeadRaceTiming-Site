using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class CompetitionDetailsViewModel
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string BackgroundHtmlColor { get; set; }
        public string FirstIntermediateName { get; set; }
        public string SecondIntermediateName { get; set; }
        public int FirstIntermediateId { get; set; }
        public int SecondIntermediateId { get; set; }
        public string AwardFilterName { get; set; }
        public int? AwardFilterId { get; set; }
        public string DialogInformation { get; set; }
        public List<AwardViewModel> Awards { get; set; }
}

    public class AwardViewModel
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
    }
}
