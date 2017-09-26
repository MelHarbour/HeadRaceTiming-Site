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

        [HttpGet("{id}")]
        public async Task<Crew> GetById(int id)
        {
            return await _context.Crews.FirstOrDefaultAsync(x => x.CrewId == id);
        }

        [HttpGet("ByCompetition/{id}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id)
        {
            IEnumerable<Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .ToListAsync();
            return crews.OrderBy(x => x.OverallTime).Select((x,i) => new ViewModels.Result() { CrewId = x.CrewId, Name = x.Name, StartNumber = x.StartNumber, OverallTime = x.OverallTime, Rank = i+1 })
                .ToList();
        }

        [HttpGet("ByCompetition/{id}/{search}")]
        public async Task<IEnumerable<ViewModels.Result>> GetByCompetition(int id, string search)
        {
            IEnumerable<Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .ToListAsync();
            string lowerSearch = search.ToLower();

            return crews.OrderBy(x => x.OverallTime).Select((x, i) => new ViewModels.Result() { CrewId = x.CrewId, Name = x.Name, StartNumber = x.StartNumber, OverallTime = x.OverallTime, Rank = i + 1 })
                .Where(x => x.Name.ToLower().Contains(lowerSearch))
                .ToList();
        }
    }
}
