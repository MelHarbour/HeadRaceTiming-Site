using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTiming_Site.Controllers
{
    public class CrewController : Controller
    {
        private readonly TimingSiteContext _context;

        public CrewController(TimingSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            Crew crew = await _context.Crews.Include(c => c.Competition.TimingPoints)
                .Include(c => c.Results)
                .Include(c => c.Competition.Crews)
                .Include("Competition.Crews.Results")
                .Include(c => c.Athletes)
                .Include("Athletes.Athlete")
                .SingleOrDefaultAsync(c => c.CrewId == id);
            return View(crew);
        }
    }
}