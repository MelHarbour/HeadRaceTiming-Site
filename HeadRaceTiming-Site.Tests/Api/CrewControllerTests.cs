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
    public class CrewControllerTests
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
        public async Task GetById_WithIncorrectId_ShouldReturn404()
        {
            var authService = new Mock<IAuthorizationService>();

            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                var result = await controller.GetById(1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetById_WithCorrectId_ShouldReturnCrew()
        {
            var authService = new Mock<IAuthorizationService>();

            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition();
                Crew dbCrew = new Crew
                {
                    BroeCrewId = 1,
                    Competition = competition
                };
                competition.Crews.Add(dbCrew);
                context.Competitions.Add(competition);
                context.SaveChanges();
                var result = await controller.GetById(1).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult, "Should be Ok Object");
                Assert.AreEqual(200, okResult.StatusCode);
                HeadRaceTimingSite.Api.Resources.Crew crew = okResult.Value as HeadRaceTimingSite.Api.Resources.Crew;
                Assert.IsNotNull(crew, "Should be Crew");
                Assert.AreEqual(1, crew.Id);
            }
        }

        [TestMethod]
        public async Task ListByCompetition_WithIncorrectCompetitionId_ShouldReturn404()
        {
            var authService = new Mock<IAuthorizationService>();

            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                var result = await controller.ListByCompetition(1, null).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task ListByCompetition_WithCompetitionAndNoCrews_ShouldReturnBlankList()
        {
            var authService = new Mock<IAuthorizationService>();

            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                context.Competitions.Add(new Competition
                {
                    CompetitionId = 1
                });
                context.SaveChanges();

                var result = await controller.ListByCompetition(1, null).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task ListByCompetition_WithSearchString_ShouldReturnMatchingCrew()
        {
            var authService = new Mock<IAuthorizationService>();

            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition
                {
                    CompetitionId = 1
                };
                competition.TimingPoints.Add(new TimingPoint(1));
                competition.Crews.Add(new Crew { BroeCrewId = 1, Name = "Alpha" });
                competition.Crews.Add(new Crew { BroeCrewId = 2, Name = "Beta" });
                context.Competitions.Add(competition);
                context.SaveChanges();

                var result = await controller.ListByCompetition(1, "alp").ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
                List<HeadRaceTimingSite.Api.Resources.Crew> crews = okResult.Value as List<HeadRaceTimingSite.Api.Resources.Crew>;
                Assert.IsNotNull(crews, "Should return List<Crew>");
                Assert.AreEqual(1, crews.Count);
                Assert.AreEqual(1, crews[0].Id);
            }
        }
    }
}
