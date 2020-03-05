using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HeadRaceTimingSite.Helpers;
using AutoMapper;
using HeadRaceTimingSite.ViewModels;

namespace HeadRaceTimingSite.Controllers
{
    public class CompetitionController : BaseController
    {
        private readonly IMapper _mapper;

        public CompetitionController(IMapper mapper, TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("text/csv")]
        public async Task<IActionResult> DetailsAsCsv(int? id)
        {
            Competition competition = await _context.Competitions.Include(c => c.TimingPoints).FirstOrDefaultAsync(c => c.CompetitionId == id);
            IEnumerable<Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id).Include(x => x.Results)
                .Include("Athletes.Athlete").Include(x => x.Penalties).ToListAsync();

            return Ok(_mapper.Map<IList<CsvCrewViewModel>>(ResultsHelper.BuildCrewsList(_mapper, competition, crews)));
        }
    }
}
