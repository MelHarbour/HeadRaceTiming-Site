using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using HeadRaceTimingSite.Helpers;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

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
            if (crewPatch is null)
                return BadRequest();

            Models.Crew dbCrew = await _context.Crews.FirstOrDefaultAsync(x => x.BroeCrewId == id);
            if (dbCrew.CompetitionId != compid)
                return BadRequest();

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
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Competition.TimingPoints)
                .Include(x => x.Results).Include(x => x.Penalties).Include(x => x.Athletes)
                .FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            Models.Competition comp = await _context.Competitions.Include(c => c.TimingPoints).Include("Crews.Results")
                .Include("Crews.Penalties").FirstOrDefaultAsync(c => c.CompetitionId == crew.CompetitionId);

            Crew output = ResultsHelper.BuildCrew(_mapper, comp, crew);
            if (comp.TimingPoints.Count > 0)
            {
                List<Models.Crew> crews = ResultsHelper.OrderCrews(comp.Crews, comp, comp.TimingPoints.Last());
                output.Rank = crew.Rank(crews, comp.TimingPoints.First(), comp.TimingPoints.Last());
            }
            for (int i = 1; i < crew.Results.Count; i++)
            {
                List<Models.Crew> crews = ResultsHelper.OrderCrews(comp.Crews, comp, comp.TimingPoints[i]);
                output.Results[i].Rank = crew.Rank(crews, comp.TimingPoints.First(), comp.TimingPoints[i]); 
            }
            return Ok(output);
        }

        /// <summary>
        /// Deletes a crew by its BROE ID
        /// </summary>
        /// <param name="id">The BROE ID for the crew</param>
        /// <response code="204">The crew was deleted</response>
        [HttpDelete("/api/crews/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Competition.TimingPoints)
                .Include(x => x.Results).Include(x => x.Penalties).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            _context.Crews.Remove(crew);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Retrieves all the crews for a given competition
        /// </summary>
        /// <param name="id">The ID of the competition</param>
        /// <param name="s">A string by which to filter the crews</param>
        /// <param name="award">The ID of an award by which to filter the results</param>
        /// <response code="200">List of crews returned</response>
        /// <response code="404">Competition not found</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions/{id}/crews")]
        public async Task<IActionResult> ListByCompetition(int id, string s, int? award = null)
        {
            List<Models.Crew> crews;
            Models.Competition comp = await _context.Competitions.Include(c => c.TimingPoints).FirstOrDefaultAsync(c => c.CompetitionId == id);

            if (comp is null)
                return NotFound();

            if (award == null)
            {
                crews = await _context.Crews.Include(c => c.Results).Where(c => c.CompetitionId == id).ToListAsync();
            }
            else
            {
                Models.Award dbAward = await _context.Awards.Include("Crews.Crew.Results")
                    .FirstOrDefaultAsync(a => a.AwardId == award);
                crews = dbAward.Crews.Select(x => x.Crew).ToList();
            }

            List<Crew> results = ResultsHelper.BuildCrewsList(_mapper, comp, crews);
            if (String.IsNullOrEmpty(s))
                return Ok(results);
            else
                return Ok(results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture)
                    .Contains(s.ToUpper(CultureInfo.CurrentCulture), StringComparison.CurrentCulture)).ToList());
        }
    }
}
