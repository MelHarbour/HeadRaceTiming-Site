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

            TimingPoint startPoint = crews.First().Competition.TimingPoints.First();
            TimingPoint firstIntermediatePoint = crews.First().Competition.TimingPoints[1];
            TimingPoint secondIntermediatePoint = crews.First().Competition.TimingPoints[2];
            TimingPoint finishPoint = crews.First().Competition.TimingPoints.Last();

            IEnumerable<Crew> firstIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, firstIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, firstIntermediatePoint));
            IEnumerable<Crew> secondIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, secondIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, secondIntermediatePoint));
            IEnumerable<Crew> finishCrewList = crews.Where(x => x.RunTime(startPoint, finishPoint).HasValue).OrderBy(x => x.RunTime(startPoint, finishPoint));

            List<ViewModels.Result> results = crews.OrderBy(x => x.OverallTime).Select(x => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = String.Format("{0:mm\\:ss\\.ff}", x.OverallTime),
                Rank = x.Rank(finishCrewList, startPoint, finishPoint),
                FirstIntermediateRank = x.Rank(firstIntermediateCrewList, startPoint, firstIntermediatePoint),
                SecondIntermediateRank = x.Rank(secondIntermediateCrewList, startPoint, secondIntermediatePoint),
                FirstIntermediateTime = String.Format("{0:mm\\:ss\\.ff}", x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[1].TimingPointId)),
                SecondIntermediateTime = String.Format("{0:mm\\:ss\\.ff}", x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[2].TimingPointId))
            }).ToList();

            return Ok(results);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
