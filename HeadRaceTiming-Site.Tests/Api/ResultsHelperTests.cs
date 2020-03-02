using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HeadRaceTimingSite.Helpers;
using HeadRaceTimingSite.Models;
using AutoMapper;

namespace HeadRaceTimingSite.Tests
{
    [TestClass]
    public class ResultsHelperTests
    {
        private Competition Competition;
        private TimingPoint StartPoint = new TimingPoint(1);
        private TimingPoint BarnesPoint = new TimingPoint(2);
        private TimingPoint HammersmithPoint = new TimingPoint(3);
        private TimingPoint FinishPoint = new TimingPoint(4);
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            Competition = new Competition();
            StartPoint = new TimingPoint(1);
            BarnesPoint = new TimingPoint(2);
            HammersmithPoint = new TimingPoint(3);
            FinishPoint = new TimingPoint(4);
            Competition.TimingPoints.Add(StartPoint);
            Competition.TimingPoints.Add(BarnesPoint);
            Competition.TimingPoints.Add(HammersmithPoint);
            Competition.TimingPoints.Add(FinishPoint);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiProfile());
            });
            mapper = config.CreateMapper();
        }

        [TestMethod]
        public void BuildResultsList_WithSingleCrewWithTime_ShouldRankItFirst()
        {
            List<Crew> crews = new List<Crew>();
            Crew crew1 = new Crew { BroeCrewId = 1, Competition = Competition };
            crews.Add(crew1);

            Crew crew2 = new Crew { BroeCrewId = 2, Competition = Competition };
            crew2.Results.Add(new Result(StartPoint, crew2, new TimeSpan(2, 0, 0)));
            crew2.Results.Add(new Result(FinishPoint, crew2, new TimeSpan(2, 20, 0)));
            crews.Add(crew2);

            List<HeadRaceTimingSite.Api.Resources.Crew> results = ResultsHelper.BuildCrewsList(mapper, Competition, crews);

            Assert.AreEqual(2, results[0].Id);
            Assert.AreEqual(1, results[1].Id);
        }

        [TestMethod]
        public void BuildResultsList_WithTwoCrewsWithTimes_ShouldOrderByTimes()
        {
            List<Crew> crews = new List<Crew>();
            Crew crew1 = new Crew { BroeCrewId = 1, Competition = Competition };
            crew1.Results.Add(new Result(StartPoint, crew1, new TimeSpan(2, 0, 0)));
            crew1.Results.Add(new Result(FinishPoint, crew1, new TimeSpan(2, 20, 0)));
            crews.Add(crew1);

            Crew crew2 = new Crew { BroeCrewId = 2, Competition = Competition };
            crew2.Results.Add(new Result(StartPoint, crew2, new TimeSpan(2, 1, 0)));
            crew2.Results.Add(new Result(FinishPoint, crew2, new TimeSpan(2, 20, 0)));
            crews.Add(crew2);

            List<HeadRaceTimingSite.Api.Resources.Crew> results = ResultsHelper.BuildCrewsList(mapper, Competition, crews);

            Assert.AreEqual(2, results[0].Id);
            Assert.AreEqual(1, results[1].Id);
        }

        [TestMethod]
        public void BuildResultsList_WithFirstCrewTimeOnly_ShouldReturnFirstCrewSecond()
        {
            List<Crew> crews = new List<Crew>();
            Crew crew1 = new Crew { BroeCrewId = 1, Competition = Competition };
            crew1.Results.Add(new Result(StartPoint, crew1, new TimeSpan(2, 0, 0)));
            crew1.Results.Add(new Result(FinishPoint, crew1, new TimeSpan(2, 20, 0)));
            crews.Add(crew1);

            Crew crew2 = new Crew { BroeCrewId = 2, Competition = Competition, IsTimeOnly = true };
            crew2.Results.Add(new Result(StartPoint, crew2, new TimeSpan(2, 1, 0)));
            crew2.Results.Add(new Result(FinishPoint, crew2, new TimeSpan(2, 20, 0)));
            crews.Add(crew2);

            List<HeadRaceTimingSite.Api.Resources.Crew> results = ResultsHelper.BuildCrewsList(mapper, Competition, crews);

            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual(2, results[1].Id);
        }

        [TestMethod]
        public void BuildResultsList_WithFirstCrewTimeOnlyAndSecondCrewAtBarnes_ShouldReturnFirstCrewSecond()
        {
            List<Crew> crews = new List<Crew>();
            Crew crew1 = new Crew { BroeCrewId = 1, Competition = Competition };
            crew1.BroeCrewId = 1;
            crew1.Competition = Competition;
            crew1.Results.Add(new Result(StartPoint, crew1, new TimeSpan(2, 0, 0)));
            crew1.Results.Add(new Result(BarnesPoint, crew1, new TimeSpan(2, 4, 0)));
            crews.Add(crew1);

            Crew crew2 = new Crew { BroeCrewId = 2, Competition = Competition, IsTimeOnly = true };
            crew2.Results.Add(new Result(StartPoint, crew2, new TimeSpan(2, 1, 0)));
            crew2.Results.Add(new Result(FinishPoint, crew2, new TimeSpan(2, 20, 0)));
            crews.Add(crew2);

            List<HeadRaceTimingSite.Api.Resources.Crew> results = ResultsHelper.BuildCrewsList(mapper, Competition, crews);

            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual(2, results[1].Id);
        }

        [TestMethod]
        public void BuildResultsList_WithNoCrewsWithTimesButTimeOnlyFirst_ShouldReturnStartOrder()
        {
            List<Crew> crews = new List<Crew>();
            Crew crew1 = new Crew { BroeCrewId = 1, IsTimeOnly = true, Competition = Competition };
            crews.Add(crew1);

            Crew crew2 = new Crew { BroeCrewId = 2, Competition = Competition };
            crews.Add(crew2);

            List<HeadRaceTimingSite.Api.Resources.Crew> results = ResultsHelper.BuildCrewsList(mapper, Competition, crews);

            Assert.AreEqual(1, results[0].Id);
            Assert.AreEqual(2, results[1].Id);
        }
    }
}
