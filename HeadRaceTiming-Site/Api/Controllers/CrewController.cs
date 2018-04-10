using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HeadRaceTimingSite.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class CrewController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IAuthorizationHelper _authorizationHelper;
        private readonly IMapper _mapper;
        
        public CrewController(IAuthorizationHelper authorizationHelper, IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _authorizationHelper = authorizationHelper;
            _mapper = mapper;
        } 

        /// <summary>
        /// Creates a new crew instance
        /// </summary>
        /// <param name="compid">The competition to which the crew belongs</param>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="crew">The details of the crew to create</param>
        [SwaggerResponse(201, Description = "Crew has been successfully created in the system")]
        [SwaggerResponse(204, Description = "Crew has been successfully updated in the system")]
        [HttpPut("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Put(int compid, int id, [FromBody] Crew crew)
        {
            Models.Competition competition = await _context.Competitions.Include("Administrators.CompetitionAdministrator").FirstAsync(x => x.CompetitionId == compid);

            var authorizationResult = await _authorizationHelper.AuthorizeAsync(User, competition, "CanAdminCompetition");

            if (!authorizationResult.Succeeded)
            {
                if (User.Identity.IsAuthenticated)
                    return new ForbidResult();
                else
                    return new ChallengeResult();
            }

            Models.Crew dbCrew = await _context.Crews.FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (dbCrew == null)
            {
                Models.Crew modelCrew = new Models.Crew { Competition = competition };
                competition.Crews.Add(modelCrew);
                _mapper.Map(crew, modelCrew);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetById", new { id = modelCrew.BroeCrewId });
            }
            else
            {
                _mapper.Map(crew, dbCrew);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        /// <summary>
        /// Updates selected fields of a specific crew
        /// </summary>
        /// <param name="compid">The competition to which the crew belongs</param>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="crewPatch">A JSON Patch for the details to update</param>
        [SwaggerResponse(204, Description = "Crew has been successfully updated in the system")]
        [HttpPatch("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Patch(int compid, int id, [FromBody]JsonPatchDocument<Crew> crewPatch)
        {
            Models.Crew dbCrew = await _context.Crews.FirstOrDefaultAsync(x => x.BroeCrewId == id);
            Crew crew = _mapper.Map<Crew>(dbCrew);
            crewPatch.ApplyTo(crew);
            _mapper.Map(crew, dbCrew);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gets a crew by its BROE ID
        /// </summary>
        /// <param name="id">The BROE ID for the crew</param>
        /// <response code="200">The crew is returned</response>
        /// <response code="404">The crew was not found</response>
        [HttpGet("/api/crews/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Competition.TimingPoints)
                .Include(x => x.Results).Include(x => x.Penalties).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            Models.Competition comp = await _context.Competitions.Include(c => c.TimingPoints).Include("Crews.Results")
                .Include("Crews.Penalties").FirstOrDefaultAsync(c => c.CompetitionId == crew.CompetitionId);

            Crew output = _mapper.Map<Crew>(crew);
            if (comp.TimingPoints.Count > 0)
            {
                output.Rank = crew.Rank(comp.Crews, comp.TimingPoints.First(), comp.TimingPoints.Last());
            }
            return Ok(output);
        }

        /// <summary>
        /// Retrieves all the crews for a given competition
        /// </summary>
        /// <param name="id">The ID of the competition</param>
        /// <param name="s">A string by which to filter the crews</param>
        /// <response code="200">List of crews returned</response>
        /// <response code="404">Competition not found</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions/{id}/crews")]
        public async Task<IActionResult> ListByCompetition(int id, string s)
        {
            Models.Competition comp = await _context.Competitions.Include(c => c.TimingPoints).Include("Crews.Results")
                .Include("Crews.Penalties").FirstOrDefaultAsync(c => c.CompetitionId == id);

            if (comp == null)
                return NotFound();

            List<Crew> results = ResultsHelper.BuildCrewsList(_mapper, comp.Crews);
            if (String.IsNullOrEmpty(s))
                return Ok(results);
            else
                return Ok(results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture).Contains(s.ToUpper(CultureInfo.CurrentCulture))).ToList());
        }
    }
}
