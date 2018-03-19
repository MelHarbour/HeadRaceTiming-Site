using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadRaceTimingSite.Models;
using HeadRaceTimingSite.ViewModels.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Controllers.Api
{
    public class AthleteController : Controller
    {
        private readonly TimingSiteContext _context;

        public AthleteController(TimingSiteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a specific athlete
        /// </summary>
        /// <param name="id">The unique identifier of the athlete</param>
        [Produces("application/json")]
        [HttpGet("/api/athletes/{id}")]
        public async Task<ViewModels.Api.Athlete> GetById(int id)
        {
            Models.Athlete athlete = await _context.Athletes. FirstAsync(x => x.AthleteId == id);
            return new ViewModels.Api.Athlete { Id = athlete.AthleteId, FirstName = athlete.FirstName, LastName = athlete.LastName };
        }
    }
}