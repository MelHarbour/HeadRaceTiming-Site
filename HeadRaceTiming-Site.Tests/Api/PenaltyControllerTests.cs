using AutoMapper;
using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Tests.Api
{
    [TestClass]
    public class PenaltyControllerTests
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
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
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
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                dbCrew.Penalties.Add(new Penalty { Reason = "Testing", Value = new TimeSpan(0, 0, 10) });
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.GetByCrew(123456).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult, "Should return Ok");
                Assert.AreEqual(200, okResult.StatusCode);
                List<HeadRaceTimingSite.Api.Resources.Penalty> penalties = okResult.Value as List<HeadRaceTimingSite.Api.Resources.Penalty>;
                Assert.IsNotNull(penalties, "Should return List<Penalty>");
                Assert.AreEqual(1, penalties.Count);
                Assert.AreEqual(new TimeSpan(0, 0, 10), penalties[0].Value);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndId_WithIncorrectCrewId_ShouldReturn404()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                var result = await controller.GetByCrewAndId(1, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndId_WithIncorrectPenaltyId_ShouldReturn404()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.GetByCrewAndId(123456, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndId_WithCorrectPenaltyId_ShouldReturnPenalty()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.GetByCrewAndId(123456, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task Post_WithValidCrew_ShouldAddPenalty()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                HeadRaceTimingSite.Api.Resources.Penalty penalty = new HeadRaceTimingSite.Api.Resources.Penalty
                {
                    Reason = "Testing",
                    Value = new TimeSpan(0, 0, 5)
                };

                var response = await controller.Post(123456, penalty).ConfigureAwait(false);
                var createdResult = response as CreatedAtRouteResult;

                Assert.IsNotNull(createdResult);
                Assert.AreEqual(201, createdResult.StatusCode);
                Assert.AreEqual(1, dbCrew.Penalties.Count);
                Assert.AreEqual(new TimeSpan(0, 0, 5), dbCrew.Penalties[0].Value);
                Assert.AreEqual("Testing", dbCrew.Penalties[0].Reason);
            }
        }

        [TestMethod]
        public async Task Delete_WithValidCrewAndPenalty_ShouldDeletePenalty()
        {
            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.PenaltyController(mapper, context))
            {
                Crew dbCrew = new Crew { CrewId = 1, BroeCrewId = 123456 };
                context.Crews.Add(dbCrew);
                Penalty dbPenalty = new Penalty { PenaltyId = 1 };
                dbCrew.Penalties.Add(dbPenalty);
                context.SaveChanges();

                var response = await controller.DeleteByCrewAndId(123456, 1).ConfigureAwait(false);
                var noContentResult = response as NoContentResult;

                Assert.IsNotNull(noContentResult);
                Assert.AreEqual(204, noContentResult.StatusCode);
                Assert.AreEqual(0, dbCrew.Penalties.Count);
            }
        }
    }
}
