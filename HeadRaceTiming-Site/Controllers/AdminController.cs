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

namespace HeadRaceTimingSite.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminController : Controller
    {
        private readonly TimingSiteContext _context;

        public AdminController(TimingSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUsers.ToListAsync());
        }

        public async Task<IActionResult> EditUser(string id)
        {
            return View(await _context.ApplicationUsers.FirstAsync(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult ImportAthletes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportAthletes(ImportAthletesViewModel viewModel)
        {
            CsvReader csv = new CsvReader(new StreamReader(viewModel.CsvUpload.OpenReadStream()));
            csv.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", String.Empty);
            return View();
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
            public string FirstName { get; set; }
            public int Age { get; set; }
            public DateTime DofB { get; set; }
            public char Gender { get; set; }
            public bool Cox { get; set; }
            public string MembersClubName { get; set; }
            public string MembersClubIndexCode { get; set; }
            public int RowingPRI { get; set; }
            public int ScullingPRI { get; set; }
            public int RowingPRIMax { get; set; }
            public int ScullingPRIMax { get; set; }
            public int RowingPoints { get; set; }
            public int ScullingPoints { get; set; }
            public bool Substitute { get; set; }
        }
    }
}
