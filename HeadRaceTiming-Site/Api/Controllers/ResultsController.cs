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
    public class ResultsController : HeadRaceTimingSite.Controllers.BaseController
    {
        private readonly IMapper _mapper;

        public ResultsController(IMapper mapper, Models.TimingSiteContext context) : base(context)
        {
            _mapper = mapper;
        }

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
            Models.Crew crew = await _context.Crews.Include("Results.TimingPoint")
                .Include(c => c.Competition.TimingPoints).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            List<Result> viewResults = await GetResults(crew);

            return Ok(viewResults);
        }

        /// <summary>
        /// Retrieves a given result for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="timingPointId">The ID of the timing point</param>
        /// <response code="200">Result returned</response>
        [Produces("application/json")]
        [HttpGet("/api/crews/{id}/results/{timingPointId}")]
        public async Task<IActionResult> GetByCrewAndTimingPoint(int id, int timingPointId)
        {
            Models.Crew crew = await _context.Crews.Include("Results.TimingPoint")
                .Include(c => c.Competition.TimingPoints).FirstOrDefaultAsync(x => x.BroeCrewId == id);

            if (crew == null)
                return NotFound();

            List<Result> results = await GetResults(crew);

            Result response = results.FirstOrDefault(x => x.Id == timingPointId);
            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }

        private async Task<List<Result>> GetResults(Models.Crew crew)
        {
            List<Models.Crew> allCrews = await _context.Crews.Include(c => c.Results)
                .Include("Results.TimingPoint").ToListAsync();

            Models.Result previousResult = null;
            bool isFirst = true;
            Models.TimingPoint startPoint = crew.Competition.TimingPoints.First();

            List<Result> results = new List<Result>();

            foreach (Models.Result result in crew.Results.OrderBy(x => x.TimingPoint.Order))
            {
                results.Add(new Result()
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
            return results;
        }

        /// <summary>
        /// Retrieves a given result for a given crew
        /// </summary>
        /// <param name="id">The BROE ID of the crew</param>
        /// <param name="timingPointId">The ID of the timing point</param>
        /// <param name="result">Details of the result</param>
        [SwaggerResponse(201, Description = "Result has been successfully updated in the system")]
        [SwaggerResponse(204, Description = "Result has been successfully created in the system")]
        [HttpGet("/api/crews/{id}/results/{timingPointId}")]
        public async Task<IActionResult> Put(int id, int timingPointId, [FromBody] Result result)
        {
            Models.Crew crew = await _context.Crews.Include(x => x.Results).FirstAsync(x => x.BroeCrewId == id);
            Models.Result modelResult = crew.Results.First(x => x.TimingPointId == timingPointId);
            if (modelResult != null)
            {
                _mapper.Map(result, modelResult);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                crew.Results.Add(_mapper.Map<Models.Result>(result));
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetByCrewAndTimingPoint", new { crewId = crew.BroeCrewId });
            }
        }
    }
}