﻿using System;
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
        /// <param name="id">The BROE ID of the crew</param>
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
        /// Sets the details for a given athlete.
        /// </summary>
        /// <remarks>
        /// If the athlete already exists in the system, will attach them to the crew in the specified position, updating first and last names.
        /// If they are not in the system already, it will create them before attaching them to the crew.
        /// </remarks>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="position">The position within the crew</param>
        /// <param name="athlete">Details of the athlete</param>
        /// <response code="204">Athlete successfully created or updated</response>
        [HttpPut("/api/crews/{id}/athletes/{position}")]
        public async Task<IActionResult> PutByCrewAndPosition(int id, int position, [FromBody]Athlete athlete)
        {
            Models.Crew crew = await _context.Crews.Include("Athletes.Athlete").FirstAsync(x => x.BroeCrewId == id);
            Models.CrewAthlete crewAthlete = crew.Athletes.FirstOrDefault(x => x.Position == position);
            Models.Athlete dbAthlete = await _context.Athletes.FirstOrDefaultAsync(x => x.MembershipNumber == athlete.MembershipNumber);

            if (crewAthlete == null)
            {
                crew.Athletes.Add(new Models.CrewAthlete
                {
                    Athlete = dbAthlete ?? new Models.Athlete
                    {
                        FirstName = athlete.FirstName,
                        LastName = athlete.LastName,
                        MembershipNumber = athlete.MembershipNumber
                    },
                    Position = position,
                    Pri = athlete.Pri,
                    PriMax = athlete.PriMax
                });
            }
            else
            { 
                if (crewAthlete.Athlete.MembershipNumber == athlete.MembershipNumber)
                {
                    crewAthlete.Athlete.FirstName = athlete.FirstName;
                    crewAthlete.Athlete.LastName = athlete.LastName;
                }
                else
                {
                    crew.Athletes.Remove(crewAthlete);
                    crew.Athletes.Add(new Models.CrewAthlete
                    {
                        Athlete = dbAthlete ?? new Models.Athlete
                        {
                            FirstName = athlete.FirstName,
                            LastName = athlete.LastName,
                            MembershipNumber = athlete.MembershipNumber
                        },
                        Position = position,
                        Pri = athlete.Pri,
                        PriMax = athlete.PriMax
                    });
                }
            }
            await _context.SaveChangesAsync();
            return NoContent();
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