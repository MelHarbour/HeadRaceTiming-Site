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
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        
        public CrewController(IAuthorizationService authorizationService, IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        } 

        /// <summary>
        /// Creates a new crew instance
        /// </summary>
        /// <param name="compid">The competition to which the crew belongs</param>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="crew">The details of the crew to create</param>
        [SwaggerResponse(201, Description = "Crew has been successfully created in the system")]
        [HttpPut("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Put(int compid, int id, [FromBody] Crew crew)
        {
            Models.Competition competition = await _context.Competitions.Include("Administrators.CompetitionAdministrator").FirstAsync(x => x.CompetitionId == compid);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, competition, "CanAdminCompetition");

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
                Models.Crew modelCrew = new Models.Crew
                {
                    BroeCrewId = id,
                    BoatClass = crew.BoatClass,
                    ClubCode = crew.ClubCode,
                    IsTimeOnly = crew.IsTimeOnly,
                    Name = crew.Name,
                    StartNumber = crew.StartNumber,
                    Status = crew.Status
                };
                _context.Crews.Add(modelCrew);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetById", new { id = modelCrew.BroeCrewId });
            }
            else
            {
                dbCrew.BoatClass = crew.BoatClass;
                dbCrew.ClubCode = crew.ClubCode;
                dbCrew.IsTimeOnly = crew.IsTimeOnly;
                dbCrew.Name = crew.Name;
                dbCrew.StartNumber = crew.StartNumber;
                dbCrew.Status = crew.Status;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        /// <summary>
        /// Updates selected fields of a specific crew
        /// </summary>
        /// <param name="compid">The competition to which the crew belongs</param>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="crewPatch">A JSON Patch for the details to update</param>
        [HttpPatch("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Patch(int compid, int id, [FromBody]JsonPatchDocument<Crew> crewPatch)
        {
            return Ok();
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
                .Include(x => x.Results).Include(x => x.Penalties)
                .Include("Athletes.Athlete").FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            Models.Competition comp = await _context.Competitions.Include(c => c.TimingPoints).Include("Crews.Results")
                .Include("Crews.Penalties").FirstOrDefaultAsync(c => c.CompetitionId == crew.CompetitionId);

            return Ok(_mapper.Map<Crew>(crew, opt => 
            {
                opt.Items["crews"] = comp.Crews;
                opt.Items["start"] = comp.TimingPoints.First();
                opt.Items["finish"] = comp.TimingPoints.Last();
            }));
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

            List<Crew> results = ResultsHelper.BuildCrewsList(comp.Crews);
            if (String.IsNullOrEmpty(s))
                return Ok(results);
            else
                return Ok(results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture).Contains(s.ToUpper(CultureInfo.CurrentCulture))));
        }
    }
}
