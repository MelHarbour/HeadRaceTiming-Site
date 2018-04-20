using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class PenaltyController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IMapper _mapper;

        public PenaltyController(IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all the penalties for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <response code="200">List of penalties returned</response>
        /// <response code="404">Crew not found</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/penalties")]
        public async Task<IActionResult> GetByCrew(int id)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Penalties).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            return Ok(_mapper.Map<List<Models.Penalty>, List<Penalty>>(crew.Penalties));
        }

        /// <summary>
        /// Retrieves a given penalty for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="penaltyId">The ID of the penalty</param>
        /// <response code="200">Result returned</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/penalties/{penaltyId}")]
        public async Task<IActionResult> GetByCrewAndId(int id, int penaltyId)
        {
            Models.Crew crew = await _context.Crews.FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            Models.Penalty penalty = await _context.Penalties.FirstOrDefaultAsync(x => x.PenaltyId == penaltyId);
            if (penalty == null)
                return NotFound();
            else
                return Ok(_mapper.Map<Penalty>(penalty));
        }

        /// <summary>
        /// Creates a penalty for a crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="penalty">Details of the penalty</param>
        [SwaggerResponse(201, Description = "Penalty has been successfully created in the system")]
        [HttpPost("/api/crews/{id}/penalties")]
        public async Task<IActionResult> Post(int id, [FromBody] Penalty penalty)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Penalties).FirstAsync(x => x.BroeCrewId == id);

            Models.Penalty dbPenalty = _mapper.Map<Models.Penalty>(penalty);
            crew.Penalties.Add(dbPenalty);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetByCrewAndId", new { id = crew.BroeCrewId, penaltyId = dbPenalty.PenaltyId });
        }

        /// <summary>
        /// Deletes a given penalty for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="penaltyId">The ID of the penalty</param>
        /// <response code="204">Penalty successfully deleted</response>
        [Produces("application/json")]
        [HttpDelete("/api/crews/{id}/penalties/{penaltyId}")]
        public async Task<IActionResult> DeleteByCrewAndId(int id, int penaltyId)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Penalties).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            Models.Penalty penalty = crew.Penalties.FirstOrDefault(x => x.PenaltyId == penaltyId);

            if (penalty == null)
                return NotFound();

            _context.Penalties.Remove(penalty);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}