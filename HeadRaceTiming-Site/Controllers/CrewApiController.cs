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
            List<ViewModels.Result> results = crews.OrderBy(x => x.OverallTime).Select((x, i) => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = x.OverallTime,
                Rank = (i + 1).ToString(),
                FirstIntermediateTime = x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[1].TimingPointId),
                SecondIntermediateTime = x.RunTime(x.Competition.TimingPoints[0].TimingPointId, x.Competition.TimingPoints[2].TimingPointId)
            })
                .ToList();

            int firstRank = 1;
            TimeSpan previousTime = TimeSpan.Zero;
            foreach (var result in results.Where(x => x.FirstIntermediateTime.HasValue).OrderBy(x => x.FirstIntermediateTime))
            {
                result.FirstIntermediateRank = (firstRank++).ToString();
                if (result.FirstIntermediateTime == previousTime)
                {
                    result.FirstIntermediateRank = result.FirstIntermediateRank + "=";
                }
                previousTime = result.FirstIntermediateTime.Value;
            }

            int secondRank = 1;
            foreach (var result in results.Where(x => x.SecondIntermediateTime.HasValue).OrderBy(x => x.SecondIntermediateTime))
            {
                result.SecondIntermediateRank = (secondRank++).ToString();
            }

            return results;
        }

        [HttpGet("{id}")]
        public async Task<Crew> GetById(int id)
        {
            return await _context.Crews.FirstOrDefaultAsync(x => x.CrewId == id);
        }

        [HttpGet("ByCompetition/{id}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id)
        {
            IEnumerable<Crew> crews = await GetCrewList(id);

            return BuildResultsList(crews);
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
