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
    }
}
