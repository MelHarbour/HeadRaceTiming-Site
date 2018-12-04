using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class AwardController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IMapper _mapper;

        public AwardController(IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all the awards for a given competition
        /// </summary>
        /// <param name="id">The ID of the competition</param>
        /// <response code="200">List of awards returned</response>
        /// <response code="404">Competition not found</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions/{id}/awards")]
        public async Task<IActionResult> GetByCompetition(int id)
        {
            Models.Competition competition = await _context.Competitions.Include(x => x.Awards).FirstOrDefaultAsync(x => x.CompetitionId == id);

            if (competition == null)
                return NotFound();

            return Ok(_mapper.Map<List<Models.Award>, List<Award>>(competition.Awards));
        }
    }
}