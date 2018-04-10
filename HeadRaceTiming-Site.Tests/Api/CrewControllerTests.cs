using AutoMapper;
using HeadRaceTimingSite.Helpers;
using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Tests.Api
{
    [TestClass]
    public class CrewControllerTests
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
        public async Task GetById_WithIncorrectId_ShouldReturn404()
        {
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
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
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
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
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
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
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
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
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
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

        [TestMethod]
        public async Task ListByCompetition_WithAward_ShouldReturnMatchingCrews()
        {
            var authService = new Mock<IAuthorizationHelper>();

            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition
                {
                    CompetitionId = 1
                };
                competition.TimingPoints.Add(new TimingPoint(1));
                Award award = new Award { AwardId = 1 };
                Crew alpha = new Crew { BroeCrewId = 1, Name = "Alpha" };
                Crew beta = new Crew { BroeCrewId = 2, Name = "Beta" };
                Crew gamma = new Crew { BroeCrewId = 3, Name = "Gamma" };
                beta.Awards.Add(new CrewAward { Award = award });
                gamma.Awards.Add(new CrewAward { Award = award });
                competition.Crews.Add(alpha);
                competition.Crews.Add(beta);
                competition.Crews.Add(gamma);
                context.Competitions.Add(competition);
                context.SaveChanges();

                var result = await controller.ListByCompetition(1, String.Empty, award: 1).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
                List<HeadRaceTimingSite.Api.Resources.Crew> crews = okResult.Value as List<HeadRaceTimingSite.Api.Resources.Crew>;
                Assert.IsNotNull(crews, "Should return List<Crew>");
                Assert.AreEqual(2, crews.Count, "Should be two crews");
                Assert.AreEqual(2, crews[0].Id, "Should be crew ID 2");
                Assert.AreEqual(3, crews[1].Id, "Should be crew ID 3");
            }
        }

        [TestMethod]
        public async Task Put_WithNoExistingCrew_ShouldAddCrew()
        {
            var authService = new Mock<IAuthorizationHelper>();
            authService.Setup(x => x.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(AuthorizationResult.Success());

            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition { CompetitionId = 1 };
                context.Competitions.Add(competition);
                context.SaveChanges();

                HeadRaceTimingSite.Api.Resources.Crew crew = new HeadRaceTimingSite.Api.Resources.Crew
                {
                    Id = 123456,
                    BoatClass = BoatClass.Eight,
                    ClubCode = "LDR",
                    IsTimeOnly = true,
                    Name = "Leander A",
                    StartNumber = 1,
                    Status = Crew.ResultStatus.Dns
                };

                var result = await controller.Put(1, 123456, crew).ConfigureAwait(false);
                var createdResult = result as CreatedAtRouteResult;

                Assert.IsNotNull(createdResult);
                Assert.AreEqual(201, createdResult.StatusCode);
                Assert.AreEqual(1, competition.Crews.Count);
                Assert.AreEqual(123456, competition.Crews[0].BroeCrewId);
                Assert.AreEqual(BoatClass.Eight, competition.Crews[0].BoatClass);
                Assert.AreEqual("LDR", competition.Crews[0].ClubCode);
                Assert.AreEqual(true, competition.Crews[0].IsTimeOnly);
                Assert.AreEqual("Leander A", competition.Crews[0].Name);
                Assert.AreEqual(1, competition.Crews[0].StartNumber);
                Assert.AreEqual(Crew.ResultStatus.Dns, competition.Crews[0].Status);
            }
        }

        [TestMethod]
        public async Task Put_WithExistingCrew_ShouldUpdateCrew()
        {
            var authService = new Mock<IAuthorizationHelper>();
            authService.Setup(x => x.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(AuthorizationResult.Success());

            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition { CompetitionId = 1 };
                context.Competitions.Add(competition);
                Crew dbCrew = new Crew
                {
                    BroeCrewId = 123456,
                    BoatClass = BoatClass.SingleScull,
                    ClubCode = "ABC",
                    IsTimeOnly = false,
                    Name = "Another BC",
                    StartNumber = 5,
                    Status = Crew.ResultStatus.Dsq
                };
                competition.Crews.Add(dbCrew);
                context.SaveChanges();

                HeadRaceTimingSite.Api.Resources.Crew crew = new HeadRaceTimingSite.Api.Resources.Crew
                {
                    Id = 123456,
                    BoatClass = BoatClass.Eight,
                    ClubCode = "LDR",
                    IsTimeOnly = true,
                    Name = "Leander A",
                    StartNumber = 1,
                    Status = Crew.ResultStatus.Dns
                };

                var result = await controller.Put(1, 123456, crew).ConfigureAwait(false);

                var noContentResult = result as NoContentResult;
                Assert.IsNotNull(noContentResult, "Should be No Content");
                Assert.AreEqual(204, noContentResult.StatusCode);
                Assert.AreEqual(1, competition.Crews.Count, "Should be one crew");
                Assert.AreEqual(123456, competition.Crews[0].BroeCrewId);
                Assert.AreEqual(BoatClass.Eight, competition.Crews[0].BoatClass);
                Assert.AreEqual("LDR", competition.Crews[0].ClubCode);
                Assert.AreEqual(true, competition.Crews[0].IsTimeOnly);
                Assert.AreEqual("Leander A", competition.Crews[0].Name);
                Assert.AreEqual(1, competition.Crews[0].StartNumber);
                Assert.AreEqual(Crew.ResultStatus.Dns, competition.Crews[0].Status);
            }
        }

        [TestMethod]
        public async Task Patch_WithExistingCrew_ShouldUpdateCrew()
        {
            var authService = new Mock<IAuthorizationHelper>();
            authService.Setup(x => x.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(AuthorizationResult.Success());

            using (var context = provider.GetService<TimingSiteContext>())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.CrewController(authService.Object, mapper, context))
            {
                Competition competition = new Competition { CompetitionId = 1 };
                context.Competitions.Add(competition);
                Crew dbCrew = new Crew
                {
                    BroeCrewId = 123456,
                    BoatClass = BoatClass.SingleScull,
                    ClubCode = "ABC",
                    IsTimeOnly = false,
                    Name = "Another BC",
                    StartNumber = 5,
                    Status = Crew.ResultStatus.Dsq
                };
                competition.Crews.Add(dbCrew);
                context.SaveChanges();

                JsonPatchDocument<HeadRaceTimingSite.Api.Resources.Crew> jsonPatch = new JsonPatchDocument<HeadRaceTimingSite.Api.Resources.Crew>();
                jsonPatch.Replace(x => x.Name, "Leander A");
                jsonPatch.Replace(x => x.StartNumber, 1);
                jsonPatch.Replace(x => x.BoatClass, BoatClass.Eight);
                jsonPatch.Replace(x => x.ClubCode, "LDR");
                jsonPatch.Replace(x => x.IsTimeOnly, true);
                jsonPatch.Replace(x => x.Status, Crew.ResultStatus.Dns);

                var result = await controller.Patch(1, 123456, jsonPatch).ConfigureAwait(false);

                var noContentResult = result as NoContentResult;
                Assert.IsNotNull(noContentResult, "Should be No Content");
                Assert.AreEqual(204, noContentResult.StatusCode);
                Assert.AreEqual(1, competition.Crews.Count, "Should be one crew");
                Assert.AreEqual(123456, competition.Crews[0].BroeCrewId);
                Assert.AreEqual(BoatClass.Eight, competition.Crews[0].BoatClass);
                Assert.AreEqual("LDR", competition.Crews[0].ClubCode);
                Assert.AreEqual(true, competition.Crews[0].IsTimeOnly);
                Assert.AreEqual("Leander A", competition.Crews[0].Name);
                Assert.AreEqual(1, competition.Crews[0].StartNumber);
                Assert.AreEqual(Crew.ResultStatus.Dns, competition.Crews[0].Status);
            }
        }
    }
}
