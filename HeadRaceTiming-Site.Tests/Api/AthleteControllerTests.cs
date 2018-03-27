﻿using HeadRaceTimingSite.Models;
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
        private TimingSiteContext GetTimingSiteContext()
        {
            var options = new DbContextOptionsBuilder<TimingSiteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TimingSiteContext(options);

            return context;
        }

        [TestMethod]
        public async Task GetByCrewAndPosition_WithPositionOver9_ShouldReturn400()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(context))
            {
                context.Crews.Add(new Crew
                {
                    BroeCrewId = 1
                });
                context.SaveChanges();

                var result = await controller.GetByCrewAndPosition(1, 10).ConfigureAwait(false);
                var badRequestResult = result as BadRequestResult;

                Assert.IsNotNull(badRequestResult);
                Assert.AreEqual(400, badRequestResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetByCrewAndPosition_WithIncorrectId_ShouldReturn404()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(context))
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
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(context))
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
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(context))
            {
                var result = await controller.ListByCrew(1).ConfigureAwait(false);
                var notFoundResult = result as NotFoundResult;

                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual(404, notFoundResult.StatusCode);
            }
        }
    }
}
