using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            return View(await _context.Competitions.Where(x => x.IsVisible).ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            int competitionId;
            Competition competition;
            if (Int32.TryParse(id, out competitionId))
            {
                competition = await _context.Competitions.Include(x => x.TimingPoints)
                    .SingleOrDefaultAsync(c => c.CompetitionId == competitionId);
            }
            else
            {
                competition = await _context.Competitions.Include(x => x.TimingPoints)
                    .SingleOrDefaultAsync(c => c.FriendlyName == id);
            }
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

            Competition competition = crews.First().Competition;
            TimingPoint startPoint = competition.TimingPoints.First();
            TimingPoint firstIntermediatePoint = competition.TimingPoints[1];
            TimingPoint secondIntermediatePoint = competition.TimingPoints[2];
            TimingPoint finishPoint = competition.TimingPoints.Last();

            IEnumerable<Crew> firstIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, firstIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, firstIntermediatePoint));
            IEnumerable<Crew> secondIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, secondIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, secondIntermediatePoint));
            IEnumerable<Crew> finishCrewList = crews.OrderByDescending(x => x.RunTime(startPoint, finishPoint).HasValue).ThenBy(x => x.RunTime(startPoint, finishPoint))
                .ThenByDescending(x => x.RunTime(startPoint, secondIntermediatePoint).HasValue).ThenBy(x => x.RunTime(startPoint, secondIntermediatePoint))
                .ThenByDescending(x => x.RunTime(startPoint, firstIntermediatePoint).HasValue).ThenBy(x => x.RunTime(startPoint, firstIntermediatePoint));

            List<ViewModels.Result> results = finishCrewList.Select(x => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.OverallTime),
                Rank = x.OverallTime != null ? x.Rank(finishCrewList, startPoint, finishPoint) : String.Empty,
                FirstIntermediateRank = x.RunTime(startPoint.TimingPointId, firstIntermediatePoint.TimingPointId) != null ? x.Rank(firstIntermediateCrewList, startPoint, firstIntermediatePoint) : String.Empty,
                SecondIntermediateRank = x.RunTime(startPoint.TimingPointId, secondIntermediatePoint.TimingPointId) != null ? x.Rank(secondIntermediateCrewList, startPoint, secondIntermediatePoint) : String.Empty,
                FirstIntermediateTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.RunTime(startPoint.TimingPointId, firstIntermediatePoint.TimingPointId)),
                SecondIntermediateTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.RunTime(startPoint.TimingPointId, secondIntermediatePoint.TimingPointId)),
                Status = x.Status,
                IsStarted = x.Results.Count > 0,
                CriMax = x.CriMax
            }).ToList();

            return Ok(results);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
