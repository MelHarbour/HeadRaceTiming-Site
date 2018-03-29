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
    public class AthleteControllerTests
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

        [DataTestMethod]
        [DataRow(BoatClass.Eight, 10)]
        [DataRow(BoatClass.CoxedFour, 6)]
        [DataRow(BoatClass.CoxlessFour, 5)]
        [DataRow(BoatClass.QuadScull, 5)]
        [DataRow(BoatClass.CoxedPair, 4)]
        [DataRow(BoatClass.CoxlessPair, 3)]
        [DataRow(BoatClass.DoubleScull, 3)]
        [DataRow(BoatClass.SingleScull, 2)]
        public async Task GetByCrewAndPosition_WithPositionOverCrewSize_ShouldReturn400(BoatClass boatClass, int position)
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                context.Crews.Add(new Crew
                {
                    BroeCrewId = 1,
                    BoatClass = boatClass
                });
                context.SaveChanges();

                var result = await controller.GetByCrewAndPosition(1, position).ConfigureAwait(false);
                var badRequestResult = result as BadRequestResult;

                Assert.IsNotNull(badRequestResult, "Boatclass: {0}; Position: {1}", boatClass, position);
                Assert.AreEqual(400, badRequestResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndPosition_WithIncorrectId_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                var result = await controller.GetByCrewAndPosition(1, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndPosition_WithMissingPosition_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                context.Crews.Add(new Crew
                {
                    BroeCrewId = 1
                });
                context.SaveChanges();

                var result = await controller.GetByCrewAndPosition(1, 1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task ListByCrew_WithIncorrectId_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                var result = await controller.ListByCrew(1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }
    }
}
