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
            List<ViewModels.Result> results = crews.Select(x => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = String.Format("{0:mm\\:ss\\.ff}", x.OverallTime),
                Rank = x.Rank(crews, x.Competition.TimingPoints.Last()),
                FirstIntermediateRank = x.Rank(crews, x.Competition.TimingPoints[1]),
                SecondIntermediateRank = x.Rank(crews, x.Competition.TimingPoints[2]),
                FirstIntermediateTime = String.Format("{0:mm\\:ss\\.ff}", x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[1].TimingPointId)),
                SecondIntermediateTime = String.Format("{0:mm\\:ss\\.ff}", x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[2].TimingPointId))
            }).OrderBy(x => String.IsNullOrEmpty(x.Rank)).ThenBy(x => x.Rank).ToList();

            return results;
        }

        [HttpGet("ById/{id}")]
        public async Task<IEnumerable<CrewResult>> GetById(int id)
        {
            Crew crew = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").Include(c => c.Competition.TimingPoints).FirstAsync(x => x.CrewId == id);
            List<CrewResult> viewResults = new List<CrewResult>();

            List<Crew> allCrews = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").ToListAsync();

            Models.Result previousResult = null;
            bool isFirst = true;

            foreach (Models.Result result in crew.Results.OrderBy(x => x.TimingPoint.Order))
            {
                viewResults.Add(new CrewResult()
                {
                    TimingPoint = result.TimingPoint.Name,
                    TimeOfDay = result.TimeOfDay,
                    SectionTime = isFirst ? (TimeSpan?)null : crew.RunTime(previousResult.TimingPoint, result.TimingPoint),
                    RunTime = isFirst ? (TimeSpan?)null : crew.RunTime(crew.Competition.TimingPoints.First(), result.TimingPoint),
                    Rank = crew.Rank(allCrews, result.TimingPoint)
                });
                previousResult = result;
                isFirst = false;
            }

            return viewResults;
        }

        [HttpGet("ByCompetition/{id}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);

            return BuildResultsList(crews);
        }

        [HttpGet("ByCompetition/{id}/{searchValue}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id, string searchValue)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);
            List<ViewModels.Result> results = BuildResultsList(crews);

            return results.Where(x => x.Name.ToUpper().Contains(searchValue.ToUpper()));
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
    }
}
