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
                competition = await _context.Competitions.Include(x => x.TimingPoints).Include(x => x.Awards)
                    .SingleOrDefaultAsync(c => c.CompetitionId == competitionId);
            }
            else
            {
                competition = await _context.Competitions.Include(x => x.TimingPoints).Include(x => x.Awards)
                    .SingleOrDefaultAsync(c => c.FriendlyName == id);
            }
            CompetitionDetailsViewModel viewModel = _mapper.Map<CompetitionDetailsViewModel>(competition);
            viewModel.AwardFilterName = "Overall";
            return View(viewModel);
        }

        [HttpGet]
        [Produces("text/csv")]
        public async Task<IActionResult> DetailsAsCsv(int? id)
        {
            IEnumerable<Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .Include("Athletes.Athlete")
                .Include(x => x.Penalties).ToListAsync();

            return Ok(ResultsHelper.BuildCrewsList(_mapper, crews));
        }
    }
}
