using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using HeadRaceTimingSite.ViewModels;
using System.Globalization;
using HeadRaceTimingSite.Helpers;

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

            TimingPoint startPoint = crew.Competition.TimingPoints.First();

            foreach (Models.Result result in crew.Results.OrderBy(x => x.TimingPoint.Order))
            {
                viewResults.Add(new CrewResult()
                {
                    TimingPoint = result.TimingPoint.Name,
                    TimeOfDay = String.Format(CultureInfo.CurrentCulture, "{0:hh\\:mm\\:ss\\.ff}", result.TimeOfDay),
                    SectionTime = isFirst ? String.Empty : String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", crew.RunTime(previousResult.TimingPoint, result.TimingPoint)),
                    RunTime = isFirst ? String.Empty : String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", crew.RunTime(startPoint, result.TimingPoint)),
                    Rank = isFirst ? String.Empty : crew.Rank(allCrews.Where(x => x.RunTime(startPoint, result.TimingPoint).HasValue)
                        .OrderBy(x => x.RunTime(startPoint, result.TimingPoint)),
                            startPoint, result.TimingPoint)
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

            return ResultsHelper.BuildResultsList(crews);
        }

        [HttpGet("ByCompetition/{id}/{searchValue}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id, string searchValue)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);
            List<ViewModels.Result> results = ResultsHelper.BuildResultsList(crews);

            return results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture).Contains(searchValue.ToUpper(CultureInfo.CurrentCulture)));
        }

        [HttpGet("ByCompetitionAndPoint/{competitionId}/{timingPointId}")]
        public async Task<IEnumerable<TimingPointResult>> GetByCompetitionAndPoint(int competitionId, int timingPointId)
        {
            IEnumerable<Crew> crews = await GetCrewList(competitionId);

            TimingPoint startPoint = crews.First().StartPoint;
            TimingPoint point = await _context.TimingPoints.FirstOrDefaultAsync(x => x.TimingPointId == timingPointId);

            crews = crews.OrderBy(x => x.RunTime(startPoint.TimingPointId, timingPointId));

            return crews.Select(x => new TimingPointResult()
            {
                Name = x.Name,
                StartNumber = x.StartNumber,
                RunTime = x.RunTime(startPoint.TimingPointId, timingPointId),
                Rank = x.Rank(crews.ToList(), startPoint, point)
            }).OrderBy(x => x.RunTime).ToList();
        }
    }
}
