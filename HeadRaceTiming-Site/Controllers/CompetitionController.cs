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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Competitions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            Competition competition = await _context.Competitions.Include(x => x.TimingPoints)
                .SingleOrDefaultAsync(c => c.CompetitionId == id);
            return View(competition);
        }

        public async Task<IActionResult> LeaderBoards(int? id)
        {
            Competition competition = await _context.Competitions.Include(x => x.TimingPoints)
                .SingleOrDefaultAsync(c => c.CompetitionId == id);
            return View(competition);
        }

        [HttpGet]
        [Produces("text/csv")]
        public async Task<IActionResult> DetailsAsCsv(int? id)
        {
            IEnumerable<Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .ToListAsync();

            List<ViewModels.Result> results = crews.OrderBy(x => x.OverallTime).Select(x => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = x.OverallTime,
                FirstIntermediateTime = x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[1].TimingPointId),
                SecondIntermediateTime = x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[2].TimingPointId)
            }).ToList();

            ViewModels.Result.RankByOverall(results);
            ViewModels.Result.RankByFirstIntermediate(results);
            ViewModels.Result.RankBySecondIntermediate(results);

            return Ok(results);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
