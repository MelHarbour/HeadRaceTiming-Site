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
    public class ResultsController : Controller
    {
        private readonly TimingSiteContext _context;

        public ResultsController(TimingSiteContext context)
        {
            _context = context;
        }

        public async Task<ViewModels.Api.Result> GetByCrewAndTimingPoint(int crewId, int timingPointId)
        {
            Models.Result modelResult = await _context.Results.FirstAsync(x => x.Crew.BroeCrewId == crewId && x.TimingPointId == timingPointId);
            return new ViewModels.Api.Result { };
        }

        public async Task<IActionResult> Put(int crewId, int timingPointId, [FromBody] ViewModels.Api.Result result)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Results).FirstAsync(x => x.BroeCrewId == crewId);
            Models.Result modelResult = crew.Results.First(x => x.TimingPointId == timingPointId);
            if (modelResult != null)
            {
                
            }
            else
            {
                crew.Results.Add(new Models.Result());
            }
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetByCrewAndTimingPoint", new { crewId = crew.BroeCrewId });
        }
    }
}