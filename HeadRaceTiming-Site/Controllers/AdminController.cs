using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HeadRaceTimingSite.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeadRaceTimingSite.ViewModels;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace HeadRaceTimingSite.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(TimingSiteContext context) : base(context) { }

        [HttpGet]
        public IActionResult ImportAthletes()
        {
            ImportAthletesViewModel viewModel = new ImportAthletesViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportAthletes(ImportAthletesViewModel importAthletesViewModel)
        {
            if (importAthletesViewModel is null)
                throw new ArgumentNullException(nameof(importAthletesViewModel));

            IEnumerable<CsvCrewAthlete> records;
            using (CsvReader csv = new CsvReader(new StreamReader(importAthletesViewModel.CsvUpload.OpenReadStream()), CultureInfo.InvariantCulture))
            {
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.Replace(" ", String.Empty, StringComparison.CurrentCulture);

                records = csv.GetRecords<CsvCrewAthlete>();
            }

            importAthletesViewModel.Message = records.Count().ToString(CultureInfo.CurrentCulture);

            var crews = await _context.Crews.Where(x => x.CompetitionId == importAthletesViewModel.CompetitionId).ToListAsync();

            foreach (CsvCrewAthlete csvAthlete in records)
            {
                if (crews.First(x => x.BroeCrewId == csvAthlete.CrewID) != null)
                {
                    
                }
            }

            return View(importAthletesViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// This class should match the CSV fields available in Competitors.csv (with spaces removed).
        /// </summary>
        private class CsvCrewAthlete
        {
            public int CrewID { get; set; }
            public int Position { get; set; }
            public string MembershipNumber { get; set; }
            public string Surname { get; set; }
            public string FirstNames { get; set; }
            public int Age { get; set; }
            public DateTime DofB { get; set; }
            public char Gender { get; set; }
            public string Cox { get; set; }
            public string MembersClubName { get; set; }
            public string MembersClubIndexCode { get; set; }
            public int RowingPRI { get; set; }
            public int ScullingPRI { get; set; }
            public int RowingPRIMax { get; set; }
            public int ScullingPRIMax { get; set; }
            public string RowingPoints { get; set; }
            public string ScullingPoints { get; set; }
            public string Substitute { get; set; }
        }
    }
}
