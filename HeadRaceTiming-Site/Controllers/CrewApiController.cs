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
                .Include(x => x.Penalties)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves the results for a specific crew by BROE ID
        /// </summary>
        /// <param name="id">The BROE ID for the crew</param>
        /// <response code="200">List of results returned</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/results")]
        public async Task<IEnumerable<CrewResult>> GetById(int id)
        {
            Crew crew = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").Include(c => c.Competition.TimingPoints).FirstAsync(x => x.BroeCrewId == id);
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
                        .OrderBy(x => x.RunTime(startPoint, result.TimingPoint)).ToList(),
                            startPoint, result.TimingPoint)
                });
                previousResult = result;
                isFirst = false;
            }

            return viewResults;
        }

        /// <summary>
        /// Retrieves all the crews for a given competition
        /// </summary>
        /// <param name="id">The ID of the competition</param>
        /// <param name="s">A string by which to filter the crews</param>
        /// <response code="200">List of crews returned</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions/{id}/crews")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id, string s)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);
            List<ViewModels.Result> results = ResultsHelper.BuildResultsList(crews);
            if (String.IsNullOrEmpty(s))
                return ResultsHelper.BuildResultsList(crews);
            else
                return results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture).Contains(s.ToUpper(CultureInfo.CurrentCulture)));
        }
    }
}
