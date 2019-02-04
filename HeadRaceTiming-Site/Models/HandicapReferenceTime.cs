using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    public class HandicapReferenceTime
    {
        public int HandicapReferenceTimeId { get; set; }
        public TimeSpan StandardTime { get; set; }
        public int Seconds { get; set; }
        public MastersCategory MastersCategory { get; set; }
    }
}
