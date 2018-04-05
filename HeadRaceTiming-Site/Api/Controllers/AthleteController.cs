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
    public class AthleteController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IMapper _mapper;

        public AthleteController(IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a specific athlete
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="position">The position within the crew</param>
        /// <response code="200">Athlete returned</response>
        /// <response code="400">Bad request (probably position higher than allowed)</response>
        /// <response code="404">Not found</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/athletes/{position}")]
        public async Task<IActionResult> GetByCrewAndPosition(int id, int position)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            if ((crew.BoatClass == Models.BoatClass.Eight && position > 9)
                || (crew.BoatClass == Models.BoatClass.CoxedFour && position > 5)
                || ((crew.BoatClass == Models.BoatClass.CoxlessFour || crew.BoatClass == Models.BoatClass.QuadScull) && position > 4)
                || (crew.BoatClass == Models.BoatClass.CoxedPair && position > 3)
                || ((crew.BoatClass == Models.BoatClass.CoxlessPair || crew.BoatClass == Models.BoatClass.DoubleScull) && position > 2)
                || (crew.BoatClass == Models.BoatClass.SingleScull && position > 1))
                return BadRequest();

            Models.CrewAthlete crewAthlete = crew.Athletes.FirstOrDefault(x => x.Position == position);

            if (crewAthlete == null)
                return NotFound();

            return Ok(_mapper.Map<Athlete>(crewAthlete));
        }

        /// <summary>
        /// Sets the details for a given athlete.
        /// </summary>
        /// <remarks>
        /// If the athlete already exists in the system, will attach them to the crew in the specified position, updating first and last names.
        /// If they are not in the system already, it will create them before attaching them to the crew.
        /// </remarks>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="position">The position within the crew</param>
        /// <param name="athlete">Details of the athlete</param>
        [SwaggerResponse(204, Description = "Athlete has been successfully created or updated in the system")]
        [HttpPut("/api/crews/{id}/athletes/{position}")]
        public async Task<IActionResult> PutByCrewAndPosition(int id, int position, [FromBody]Athlete athlete)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstAsync(x => x.BroeCrewId == id);
            Models.CrewAthlete crewAthlete = crew.Athletes.FirstOrDefault(x => x.Position == position);

            bool created = false;

            if (crewAthlete == null)
            {
                Models.Athlete dbAthlete = await _context.Athletes.FirstOrDefaultAsync(x => x.MembershipNumber == athlete.MembershipNumber);
                if (dbAthlete == null)
                {
                    crew.Athletes.Add(_mapper.Map<Models.CrewAthlete>(athlete));
                    created = true;
                }
                else
                {
                    crewAthlete = new Models.CrewAthlete
                    {
                        Athlete = dbAthlete
                    };

                    crew.Athletes.Add(crewAthlete);
                    _mapper.Map(athlete, crewAthlete);
                }
            }
            else
            { 
                if (crewAthlete.Athlete.MembershipNumber == athlete.MembershipNumber)
                {
                    _mapper.Map(athlete, crewAthlete);
                }
                else
                {
                    Models.Athlete dbAthlete = await _context.Athletes.FirstOrDefaultAsync(x => x.MembershipNumber == athlete.MembershipNumber);
                    crew.Athletes.Remove(crewAthlete);
                    if (dbAthlete == null)
                    {
                        crew.Athletes.Add(_mapper.Map<Models.CrewAthlete>(athlete));
                        created = true;
                    }
                    else
                    {
                        Models.CrewAthlete newCrewAthlete = new Models.CrewAthlete { Athlete = dbAthlete };
                        crew.Athletes.Add(newCrewAthlete);
                        _mapper.Map(athlete, newCrewAthlete);
                    }
                }
            }
            await _context.SaveChangesAsync();
            if (created)
                return CreatedAtRoute("GetByCrewAndPosition", new { id = crew.BroeCrewId, position = athlete.Position });
            else 
                return NoContent();
        }

        /// <summary>
        /// Retrieves the athletes for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <response code="200">List of athletes returned</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/athletes")]
        public async Task<IActionResult> ListByCrew(int id)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            return Ok(crew.Athletes.Select(x => _mapper.Map<Athlete>(x)).ToList());
        }
    }
}