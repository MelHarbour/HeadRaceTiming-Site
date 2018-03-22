using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class AthleteController : HeadRaceTimingSite.Controllers.BaseController
    {
        public AthleteController(Models.TimingSiteContext context) : base(context) { }

        /// <summary>
        /// Retrieves a specific athlete
        /// </summary>
        /// <param name="id">The unique identifier of the athlete</param>
        /// <param name="position">The position within the crew</param>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/athletes/{position}")]
        public async Task<Athlete> GetByCrewAndPosition(int id, int position)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstAsync(x => x.BroeCrewId == id);
            Models.CrewAthlete crewAthlete = crew.Athletes.First(x => x.Position == position);
            return new Athlete
            {
                Id = crewAthlete.Athlete.AthleteId,
                FirstName = crewAthlete.Athlete.FirstName,
                LastName = crewAthlete.Athlete.LastName,
                MembershipNumber = crewAthlete.Athlete.MembershipNumber,
                Position = crewAthlete.Position
            };
        }

        /// <summary>
        /// Retrieves the athletes for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <response code="200">List of athletes returned</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/athletes")]
        public async Task<IEnumerable<Athlete>> ListByCrew(int id)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstAsync(x => x.BroeCrewId == id);
            return crew.Athletes.Select(x => new Athlete
            {
                Id = x.Athlete.AthleteId,
                FirstName = x.Athlete.FirstName,
                LastName = x.Athlete.LastName,
                MembershipNumber = x.Athlete.MembershipNumber,
                Position = x.Position
            });
        }
    }
}