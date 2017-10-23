using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class ImportAthletesViewModel
    {
        [Required]
        public int CompetitionId { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile CsvUpload { get; set; }
    }
}
