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

        private TimingSiteContext GetTimingSiteContext()
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
    }
}
