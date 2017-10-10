using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using HeadRaceTimingSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeadRaceTimingSite.Controllers
{
    [Route("api/[controller]")]
    public class CrewApiController : Controller
    {
        private readonly TimingSiteContext _context;

        public CrewApiController(TimingSiteContext context)
        {
            _context = context;
        }

        private async Task<IEnumerable<Crew>> GetCrewList(int competitionId)
        {
            return await _context.Crews.Where(c => c.CompetitionId == competitionId)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .ToListAsync();
        }

        private List<ViewModels.Result> BuildResultsList(IEnumerable<Crew> crews)
        {
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

            return results;
        }

        [HttpGet("ById/{id}")]
        public async Task<IEnumerable<CrewResult>> GetById(int id)
        {
            Crew crew = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").FirstAsync(x => x.CrewId == id);
            List<CrewResult> viewResults = new List<CrewResult>();

            List<Crew> allCrews = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").ToListAsync();

            Models.Result startResult = null;
            Models.Result previousResult = null;

            foreach (Models.Result result in crew.Results.OrderBy(x => x.TimingPoint.Order))
            {
                string rank = String.Empty;

                if (startResult != null)
                {
                    var allTimesAtPoint = allCrews.Select(x => new { CrewId = x.CrewId, RunTime = x.RunTime(startResult.TimingPoint, result.TimingPoint) }).OrderBy(x => x.RunTime).ToList();

                    int overallRank = 1;
                    TimeSpan previousTime = TimeSpan.Zero;
                    foreach (var crewTime in allTimesAtPoint)
                    {
                        if (crewTime.CrewId == result.CrewId)
                            rank = overallRank.ToString();
                        overallRank++;
                    }
                }
                
                viewResults.Add(new CrewResult()
                {
                    TimingPoint = result.TimingPoint.Name,
                    TimeOfDay = result.TimeOfDay,
                    SectionTime = startResult == null ? (TimeSpan?)null : crew.RunTime(previousResult.TimingPoint, result.TimingPoint),
                    RunTime = startResult == null ? (TimeSpan?)null : crew.RunTime(startResult.TimingPoint, result.TimingPoint),
                    Rank = rank
                });
                if (startResult == null)
                {
                    startResult = result;
                }
                previousResult = result;
            }

            return viewResults;
        }

        [HttpGet("ByCompetition/{id}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);

            return BuildResultsList(crews);
        }

        [HttpGet("ByCompetitionAndPoint/{competitionId}/{timingPointId}")]
        public async Task<IEnumerable<TimingPointResult>> GetByCompetitionAndPoint(int competitionId, int timingPointId)
        {
            IEnumerable<Crew> crews = await GetCrewList(competitionId);

            Competition competition = await _context.Competitions.FirstOrDefaultAsync(x => x.CompetitionId == competitionId);
            TimingPoint point = await _context.TimingPoints.FirstOrDefaultAsync(x => x.TimingPointId == timingPointId);

            return crews.OrderBy(x => x.RunTime(competition.TimingPoints.FirstOrDefault().TimingPointId, timingPointId))
                .Select(x => new TimingPointResult()
            {
                Name = x.Name,
                StartNumber = x.StartNumber,
                RunTime = x.RunTime(competition.TimingPoints.FirstOrDefault().TimingPointId, timingPointId),
                Rank = x.Rank(crews.ToList(), point).ToString()
            }).ToList();
        }

        [HttpGet("ByCompetition/{id}/{search}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id, string search)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);

            string lowerSearch = search.ToLower();

            return BuildResultsList(crews.Where(x => x.Name.ToLower().Contains(lowerSearch)));
        }
    }
}
