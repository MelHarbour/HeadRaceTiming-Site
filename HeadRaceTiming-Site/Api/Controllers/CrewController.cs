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

namespace HeadRaceTimingSite.Api.Controllers
{
    public class CrewController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        
        public CrewController(IAuthorizationService authorizationService, Models.TimingSiteContext context) : base(context)
        {
            _authorizationService = authorizationService;
        } 

        /// <summary>
        /// Creates a new crew instance
        /// </summary>
        /// <param name="crew">The details of the crew to create</param>
        [SwaggerResponse(201, Description = "Crew has been successfully created in the system")]
        [HttpPut("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Create(int compid, int id, [FromBody] Crew crew)
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

            Models.Crew modelCrew = new Models.Crew
            {
                BroeCrewId = id
            };
            _context.Crews.Add(modelCrew);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetById", new { id = modelCrew.BroeCrewId });
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
            Models.Crew crew = await _context.Crews.FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            return Ok(new Crew()
            {
                Id = crew.BroeCrewId.Value,
                Name = crew.Name,
                StartNumber = crew.StartNumber,
                OverallTime = crew.OverallTime,
                Status = crew.Status,
                IsStarted = crew.Results.Count > 0,
                IsTimeOnly = crew.IsTimeOnly,
                IsFinished = crew.OverallTime.HasValue,
                CriMax = crew.CriMax
            });
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
