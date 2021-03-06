﻿using AutoMapper;
using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Tests.Api
{
    [TestClass]
    public class ResultControllerTests
    {
        private IMapper mapper;
        private ServiceProvider provider;

        [TestInitialize]
        public void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiProfile());
            });
            mapper = config.CreateMapper();
            var services = new ServiceCollection();
            services.AddDbContext<TimingSiteContext>(
                options => options.UseInMemoryDatabase($"db-{Guid.NewGuid()}"),
                ServiceLifetime.Transient
            );
            provider = services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task GetByCrew_WithIncorrectId_ShouldReturn404()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
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
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
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
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
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
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
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

        [TestMethod]
        public async Task Put_WithNoExistingResult_ShouldAddResult()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
            {
                Crew crew = new Crew { BroeCrewId = 1 };
                context.Crews.Add(crew);
                context.SaveChanges();

                HeadRaceTimingSite.Api.Resources.Result result = new HeadRaceTimingSite.Api.Resources.Result
                {
                    TimeOfDay = new TimeSpan(10, 0, 0)
                };

                var response = await controller.Put(1, 1, result).ConfigureAwait(false);
                var createdResult = response as CreatedAtRouteResult;

                Assert.IsNotNull(createdResult);
                Assert.AreEqual(201, createdResult.StatusCode);
                Assert.AreEqual(1, crew.Results.Count);
                Assert.AreEqual(new TimeSpan(10, 0, 0), crew.Results[0].TimeOfDay);
                Assert.AreEqual(1, crew.Results[0].TimingPointId);
            }
        }

        [TestMethod]
        public async Task Put_WithExistingResult_ShouldAmendResult()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
            {
                Crew crew = new Crew { BroeCrewId = 1 };
                crew.Results.Add(new Result { TimingPointId = 1, TimeOfDay = new TimeSpan(9, 0, 0) });
                context.Crews.Add(crew);
                context.SaveChanges();

                HeadRaceTimingSite.Api.Resources.Result result = new HeadRaceTimingSite.Api.Resources.Result
                {
                    TimeOfDay = new TimeSpan(10, 0, 0)
                };

                var response = await controller.Put(1, 1, result).ConfigureAwait(false);
                var noContentResult = response as NoContentResult;

                Assert.IsNotNull(noContentResult);
                Assert.AreEqual(204, noContentResult.StatusCode);
                Assert.AreEqual(1, crew.Results.Count, "Should be one result");
                Assert.AreEqual(new TimeSpan(10, 0, 0), crew.Results[0].TimeOfDay);
                Assert.AreEqual(1, crew.Results[0].TimingPointId, "Should be for timing point 1");
            }
        }

        [TestMethod]
        public async Task Delete_WithValidCrewAndTimingPoint_ShouldDeleteResult()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.ResultController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                context.Crews.Add(dbCrew);
                Result result = new Result { TimingPointId = 1 };
                dbCrew.Results.Add(result);
                context.SaveChanges();

                var response = await controller.DeleteByCrewAndTimingPoint(123456, 1).ConfigureAwait(false);
                var noContentResult = response as NoContentResult;

                Assert.IsNotNull(noContentResult);
                Assert.AreEqual(204, noContentResult.StatusCode);
                Assert.AreEqual(0, dbCrew.Results.Count);
            }
        }
    }
}
