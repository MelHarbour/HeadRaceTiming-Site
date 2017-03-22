using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly TimingSiteContext _context;

        public CompetitionController(TimingSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            Competition competition = await _context.Competitions
                .SingleOrDefaultAsync(c => c.CompetitionId == id);
            return View(competition);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
