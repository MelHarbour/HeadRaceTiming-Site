using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Controllers
{
    public class CrewController : BaseController
    {
        public CrewController(TimingSiteContext context) : base(context) { }

        public async Task<IActionResult> Details(int? id)
        {
            Crew crew = await _context.Crews.Include(c => c.Competition)
                .Include(c => c.Athletes)
                .Include("Athletes.Athlete")
                .Include("Awards.Award")
                .SingleOrDefaultAsync(c => c.CrewId == id);
            return View(crew);
        }
    }
}