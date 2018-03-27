using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadRaceTimingSite.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Api.Controllers
{
    public class ResultsController : HeadRaceTimingSite.Controllers.BaseController
    {
        public ResultsController(Models.TimingSiteContext context) : base(context) { }

        /// <summary>
        /// Retrieves all the results for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <response code="200">List of results returned</response>
        /// <response code="404">Crew not found</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/results")]
        public async Task<IActionResult> GetByCrew(int id)
        {
            Models.Crew crew = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").Include(c => c.Competition.TimingPoints).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            List<Result> viewResults = new List<Result>();

            List<Models.Crew> allCrews = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").ToListAsync();

            Models.Result previousResult = null;
            bool isFirst = true;

            Models.TimingPoint startPoint = crew.Competition.TimingPoints.First();

            foreach (Models.Result result in crew.Results.OrderBy(x => x.TimingPoint.Order))
            {
                viewResults.Add(new Result()
                {
                    Id = result.TimingPointId,
                    Name = result.TimingPoint.Name,
                    TimeOfDay = result.TimeOfDay,
                    SectionTime = isFirst ? null : crew.RunTime(previousResult.TimingPoint, result.TimingPoint),
                    RunTime = isFirst ? null : crew.RunTime(startPoint, result.TimingPoint),
                    Rank = isFirst ? String.Empty : crew.Rank(allCrews.Where(x => x.RunTime(startPoint, result.TimingPoint).HasValue)
                        .OrderBy(x => x.RunTime(startPoint, result.TimingPoint)).ToList(),
                            startPoint, result.TimingPoint)
                });
                previousResult = result;
                isFirst = false;
            }

            return Ok(viewResults);
        }


        public async Task<IActionResult> Put(int crewId, int timingPointId, [FromBody] Result result)
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