using AutoMapper;
using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Tests.Api
{
    [TestClass]
    public class ResultsControllerTests
    {
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiProfile());
            });
            mapper = config.CreateMapper();
        }

        private static TimingSiteContext GetTimingSiteContext()
        {
            var options = new DbContextOptionsBuilder<TimingSiteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TimingSiteContext(options);

            return context;
        }

        [TestMethod]
        public async Task GetByCrew_WithIncorrectId_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultsController(mapper, context))
            {
                var result = await controller.GetByCrew(1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrew_WithCorrectId_ShouldReturnCorrectResults()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultsController(mapper, context))
            {
                TimingPoint timingPoint = new TimingPoint(1);
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                dbCrew.Results.Add(new Result(timingPoint, new TimeSpan(10, 0, 0)));
                dbCrew.Competition = new Competition();
                dbCrew.Competition.TimingPoints.Add(timingPoint);
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.GetByCrew(123456).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult, "Should return Ok");
                Assert.AreEqual(200, okResult.StatusCode);
                List<HeadRaceTimingSite.Api.Resources.Result> results = okResult.Value as List<HeadRaceTimingSite.Api.Resources.Result>;
                Assert.IsNotNull(results, "Should return List<Result>");
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual(new TimeSpan(10, 0, 0), results[0].TimeOfDay);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndTimingPoint_WithIncorrectCrewId_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultsController(mapper, context))
            {
                var result = await controller.GetByCrewAndTimingPoint(1, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndTimingPoint_WithMissingResult_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultsController(mapper, context))
            {
                Competition competition = new Competition();
                competition.TimingPoints.Add(new TimingPoint(1));
                Crew crew = new Crew
                {
                    BroeCrewId = 1,
                    Competition = competition
                };
                context.Crews.Add(crew);
                context.SaveChanges();
                var result = await controller.GetByCrewAndTimingPoint(1, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }
    }
}
