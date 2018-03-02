using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public bool IsMasters { get; set; }

        public Competition Competition { get; set; }
        public List<CrewAward> Crews { get; set; }
    }
}
