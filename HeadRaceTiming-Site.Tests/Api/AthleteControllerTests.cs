using AutoMapper;
using HeadRaceTimingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task GetByCrewAndPosition_WithValidData_ShouldReturnAthlete()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                Crew dbCrew = new Crew
                {
                    BroeCrewId = 1,
                    BoatClass = BoatClass.SingleScull
                };
                dbCrew.Athletes.Add(new CrewAthlete { Athlete = new Athlete { MembershipNumber = "ABC123" }, Position = 1 });
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.GetByCrewAndPosition(1, 1).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult, "Should be Ok");
                Assert.AreEqual(200, okResult.StatusCode);
                HeadRaceTimingSite.Api.Resources.Athlete athlete = okResult.Value as HeadRaceTimingSite.Api.Resources.Athlete;
                Assert.IsNotNull(athlete, "Should be Athlete");
                Assert.AreEqual("ABC123", athlete.MembershipNumber);
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

        [TestMethod]
        public async Task ListByCrew_WithCorrectId_ShouldReturnAthletes()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                Crew dbCrew = new Crew { BroeCrewId = 1 };
                dbCrew.Athletes.Add(new CrewAthlete { Athlete = new Athlete { MembershipNumber = "ABC123" } });
                context.Crews.Add(dbCrew);
                context.SaveChanges();

                var result = await controller.ListByCrew(1).ConfigureAwait(false);
                var okResult = result as OkObjectResult;

                Assert.IsNotNull(okResult, "Should be Ok");
                Assert.AreEqual(200, okResult.StatusCode);
                List<HeadRaceTimingSite.Api.Resources.Athlete> athletes = okResult.Value as List<HeadRaceTimingSite.Api.Resources.Athlete>;
                Assert.IsNotNull(athletes, "Should be List<Athlete>");
                Assert.AreEqual(1, athletes.Count);
                Assert.AreEqual("ABC123", athletes[0].MembershipNumber);
            }
        }

        [TestMethod]
        public async Task PutByCrewAndPosition_WithAthleteNotInSystem_ShouldAddAthleteToDatabase()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                context.Crews.Add(new Crew { BroeCrewId = 1 });
                context.SaveChanges();

                var result = await controller.PutByCrewAndPosition(1, 1, new HeadRaceTimingSite.Api.Resources.Athlete
                    {
                        FirstName = "Joe",
                        LastName = "Bloggs",
                        MembershipNumber = "ABC123",
                        Age = 25,
                        Position = 1,
                        Pri = 10,
                        PriMax = 20
                    }).ConfigureAwait(false);
                
                var createdAtResult = result as CreatedAtRouteResult;
                Assert.IsNotNull(createdAtResult, "Should be Created At");
                Assert.AreEqual(201, createdAtResult.StatusCode);
                Crew dbCrew = context.Crews.First(x => x.BroeCrewId == 1);
                Assert.AreEqual(1, dbCrew.Athletes.Count);
                Assert.AreEqual("Joe", dbCrew.Athletes[0].Athlete.FirstName);
                Assert.AreEqual("Bloggs", dbCrew.Athletes[0].Athlete.LastName);
                Assert.AreEqual("ABC123", dbCrew.Athletes[0].Athlete.MembershipNumber);
                Assert.AreEqual(25, dbCrew.Athletes[0].Age);
                Assert.AreEqual(1, dbCrew.Athletes[0].Position);
                Assert.AreEqual(10, dbCrew.Athletes[0].Pri);
                Assert.AreEqual(20, dbCrew.Athletes[0].PriMax);
            }
        }

        [TestMethod]
        public async Task PutByCrewAndPosition_WithExistingAthleteSameMembershipNumberInPosition_ShouldUpdateAthlete()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                Crew crew = new Crew { BroeCrewId = 1 };
                crew.Athletes.Add(new CrewAthlete
                {
                    Athlete = new Athlete
                    {
                        FirstName = "Mike",
                        LastName = "Tester",
                        MembershipNumber = "ABC123",
                    },
                    Age = 24,
                    Position = 1,
                    Pri = 5,
                    PriMax = 10
                });
                context.Crews.Add(crew);
                context.SaveChanges();

                var result = await controller.PutByCrewAndPosition(1, 1, new HeadRaceTimingSite.Api.Resources.Athlete
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    MembershipNumber = "ABC123",
                    Age = 25,
                    Position = 1,
                    Pri = 10,
                    PriMax = 20
                }).ConfigureAwait(false);

                var noContentResult = result as NoContentResult;
                Assert.IsNotNull(noContentResult, "Should be No Content");
                Assert.AreEqual(204, noContentResult.StatusCode);
                Crew dbCrew = context.Crews.First(x => x.BroeCrewId == 1);
                Assert.AreEqual(1, context.Athletes.Count());
                Assert.AreEqual(1, dbCrew.Athletes.Count);
                Assert.AreEqual("Joe", dbCrew.Athletes[0].Athlete.FirstName);
                Assert.AreEqual("Bloggs", dbCrew.Athletes[0].Athlete.LastName);
                Assert.AreEqual("ABC123", dbCrew.Athletes[0].Athlete.MembershipNumber);
                Assert.AreEqual(25, dbCrew.Athletes[0].Age);
                Assert.AreEqual(1, dbCrew.Athletes[0].Position);
                Assert.AreEqual(10, dbCrew.Athletes[0].Pri);
                Assert.AreEqual(20, dbCrew.Athletes[0].PriMax);
            }
        }

        [TestMethod]
        public async Task PutByCrewAndPosition_WithExistingAthleteSameMembershipNumberNotInCrew_ShouldUpdateAthleteAndAttach()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                context.Crews.Add(new Crew { BroeCrewId = 1 });
                context.Athletes.Add(new Athlete
                {
                    FirstName = "Mike",
                    LastName = "Tester",
                    MembershipNumber = "ABC123",
                });
                context.SaveChanges();

                var result = await controller.PutByCrewAndPosition(1, 1, new HeadRaceTimingSite.Api.Resources.Athlete
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    MembershipNumber = "ABC123",
                    Age = 25,
                    Position = 1,
                    Pri = 10,
                    PriMax = 20
                }).ConfigureAwait(false);

                var noContentResult = result as NoContentResult;
                Assert.IsNotNull(noContentResult, "Should be No Content");
                Assert.AreEqual(204, noContentResult.StatusCode);
                Crew dbCrew = context.Crews.First(x => x.BroeCrewId == 1);
                Assert.AreEqual(1, context.Athletes.Count());
                Assert.AreEqual(1, dbCrew.Athletes.Count);
                Assert.AreEqual("Joe", dbCrew.Athletes[0].Athlete.FirstName);
                Assert.AreEqual("Bloggs", dbCrew.Athletes[0].Athlete.LastName);
                Assert.AreEqual("ABC123", dbCrew.Athletes[0].Athlete.MembershipNumber);
                Assert.AreEqual(25, dbCrew.Athletes[0].Age);
                Assert.AreEqual(1, dbCrew.Athletes[0].Position);
                Assert.AreEqual(10, dbCrew.Athletes[0].Pri);
                Assert.AreEqual(20, dbCrew.Athletes[0].PriMax);
            }
        }

        [TestMethod]
        public async Task PutByCrewAndPosition_WithWrongAthleteInPositionAndExistingAthleteElsewhere_ShouldUpdateAthleteAndAttach()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                Crew crew = new Crew { BroeCrewId = 1 };
                context.Crews.Add(crew);
                crew.Athletes.Add(new CrewAthlete
                {
                    Athlete = new Athlete
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        MembershipNumber = "DEF456",
                    },
                    Age = 22,
                    Position = 1,
                    Pri = 20,
                    PriMax = 30
                });
                context.Athletes.Add(new Athlete
                {
                    FirstName = "Mike",
                    LastName = "Tester",
                    MembershipNumber = "ABC123",
                });
                context.SaveChanges();

                var result = await controller.PutByCrewAndPosition(1, 1, new HeadRaceTimingSite.Api.Resources.Athlete
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    MembershipNumber = "ABC123",
                    Age = 25,
                    Position = 1,
                    Pri = 10,
                    PriMax = 20
                }).ConfigureAwait(false);

                var noContentResult = result as NoContentResult;
                Assert.IsNotNull(noContentResult, "Should be No Content");
                Assert.AreEqual(204, noContentResult.StatusCode);
                Crew dbCrew = context.Crews.First(x => x.BroeCrewId == 1);
                Assert.AreEqual(2, context.Athletes.Count());
                Assert.AreEqual(1, dbCrew.Athletes.Count);
                Assert.AreEqual("Joe", dbCrew.Athletes[0].Athlete.FirstName);
                Assert.AreEqual("Bloggs", dbCrew.Athletes[0].Athlete.LastName);
                Assert.AreEqual("ABC123", dbCrew.Athletes[0].Athlete.MembershipNumber);
                Assert.AreEqual(25, dbCrew.Athletes[0].Age);
                Assert.AreEqual(1, dbCrew.Athletes[0].Position);
                Assert.AreEqual(10, dbCrew.Athletes[0].Pri);
                Assert.AreEqual(20, dbCrew.Athletes[0].PriMax);
            }
        }

        [TestMethod]
        public async Task PutByCrewAndPosition_WithWrongAthleteInPositionAndNoExistingAthlete_ShouldCreateAthleteAndAttach()
        {
            using (var context = GetTimingSiteContext())
            using (var controller = new HeadRaceTimingSite.Api.Controllers.AthleteController(mapper, context))
            {
                Crew crew = new Crew { BroeCrewId = 1 };
                context.Crews.Add(crew);
                crew.Athletes.Add(new CrewAthlete
                {
                    Athlete = new Athlete
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        MembershipNumber = "DEF456",
                    },
                    Age = 22,
                    Position = 1,
                    Pri = 20,
                    PriMax = 30
                });
                context.SaveChanges();

                var result = await controller.PutByCrewAndPosition(1, 1, new HeadRaceTimingSite.Api.Resources.Athlete
                {
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    MembershipNumber = "ABC123",
                    Age = 25,
                    Position = 1,
                    Pri = 10,
                    PriMax = 20
                }).ConfigureAwait(false);

                var createdAtResult = result as CreatedAtRouteResult;
                Assert.IsNotNull(createdAtResult, "Should be Created At");
                Assert.AreEqual(201, createdAtResult.StatusCode);
                Crew dbCrew = context.Crews.First(x => x.BroeCrewId == 1);
                Assert.AreEqual(2, context.Athletes.Count());
                Assert.AreEqual(1, dbCrew.Athletes.Count);
                Assert.AreEqual("Joe", dbCrew.Athletes[0].Athlete.FirstName);
                Assert.AreEqual("Bloggs", dbCrew.Athletes[0].Athlete.LastName);
                Assert.AreEqual("ABC123", dbCrew.Athletes[0].Athlete.MembershipNumber);
                Assert.AreEqual(25, dbCrew.Athletes[0].Age);
                Assert.AreEqual(1, dbCrew.Athletes[0].Position);
                Assert.AreEqual(10, dbCrew.Athletes[0].Pri);
                Assert.AreEqual(20, dbCrew.Athletes[0].PriMax);
            }
        }
    }
}
