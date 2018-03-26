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

namespace HeadRaceTimingSite.Api.Controllers
{
    public class CrewController : HeadRaceTimingSite.Controllers.BaseController
    {
        public CrewController(Models.TimingSiteContext context) : base(context) { } 

        /// <summary>
        /// Creates a new crew instance
        /// </summary>
        /// <param name="crew">The details of the crew to create</param>
        [SwaggerResponse(201, Description = "Crew has been successfully created in the system")]
        [HttpPut("/api/competitions/{compid}/crews/{id}")]
        public async Task<IActionResult> Create(int compid, int id, [FromBody] Crew crew)
        {
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
        [HttpGet("/api/crews/{id}")]
        public async Task<Crew> GetById(int id)
        {
            Models.Crew crew = await _context.Crews.FirstAsync(x => x.BroeCrewId == id);
            return new Crew()
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
            };
        }

        /// <summary>
        /// Retrieves all the crews for a given competition
        /// </summary>
        /// <param name="id">The ID of the competition</param>
        /// <param name="s">A string by which to filter the crews</param>
        /// <response code="200">List of crews returned</response>
        [Produces("application/json")]
        [HttpGet("/api/competitions/{id}/crews")]
        public async Task<IEnumerable<Crew>> ListByCompetition(int id, string s)
        {
            IEnumerable<Models.Crew> crews = await _context.Crews.Where(c => c.CompetitionId == id)
                .Include(x => x.Competition.TimingPoints).Include(x => x.Results)
                .Include(x => x.Penalties)
                .ToListAsync();

            List<Crew> results = ResultsHelper.BuildCrewsList(crews);
            if (String.IsNullOrEmpty(s))
                return results;
            else
                return results.Where(x => x.Name.ToUpper(CultureInfo.CurrentCulture).Contains(s.ToUpper(CultureInfo.CurrentCulture)));
        }
    }
}
