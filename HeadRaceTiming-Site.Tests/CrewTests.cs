using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadRaceTimingSite.Models;
using System.Collections.Generic;

namespace HeadRaceTiming_Site.Tests
{
    [TestClass]
    public class CrewTests
    {
        [TestMethod]
        public void RunTime_WithNoResults_ShouldReturnNull()
        {
            Crew crew = new Crew();
            TimingPoint startPoint = new TimingPoint();
            TimingPoint finishPoint = new TimingPoint();

            Assert.IsNull(crew.RunTime(startPoint, finishPoint));
        }

        [TestMethod]
        public void RunTime_WithTwoResults_ShouldReturnDifference()
        {
            Crew crew = new Crew();
            crew.CrewId = 1;
            crew.Results = new List<Result>();
            TimingPoint startPoint = new TimingPoint();
            startPoint.TimingPointId = 1;
            TimingPoint finishPoint = new TimingPoint();
            finishPoint.TimingPointId = 2;

            crew.Results.Add(new Result(startPoint, crew, new TimeSpan(2, 0, 0)));
            crew.Results.Add(new Result(finishPoint, crew, new TimeSpan(2, 20, 0)));

            Assert.AreEqual(new TimeSpan(0, 20, 0), crew.RunTime(startPoint, finishPoint));
        }

        [TestMethod]
        public void Placing_WithOneCrew_ShouldReturnOne()
        {
            Crew crew = new Crew();
            crew.CrewId = 1;
            crew.Results = new List<Result>();
            TimingPoint startPoint = new TimingPoint();
            startPoint.TimingPointId = 1;
            TimingPoint finishPoint = new TimingPoint();
            finishPoint.TimingPointId = 2;

            Competition comp = new Competition();
            comp.Crews = new List<Crew>();
            comp.TimingPoints = new List<TimingPoint>();
            comp.TimingPoints.Add(startPoint);
            comp.TimingPoints.Add(finishPoint);

            crew.Results.Add(new Result(startPoint, crew, new TimeSpan(2, 0, 0)));
            crew.Results.Add(new Result(finishPoint, crew, new TimeSpan(2, 20, 0)));

            comp.Crews.Add(crew);
            crew.Competition = comp;

            Assert.AreEqual(1, crew.Placing(finishPoint));
        }

        [TestMethod]
        public void Placing_WithOrderedCrews_ShouldReturnPlacingOfEach()
        {
            TimingPoint startPoint = new TimingPoint();
            startPoint.TimingPointId = 1;
            TimingPoint finishPoint = new TimingPoint();
            finishPoint.TimingPointId = 2;

            Competition comp = new Competition();
            comp.Crews = new List<Crew>();
            comp.TimingPoints = new List<TimingPoint>();
            comp.TimingPoints.Add(startPoint);
            comp.TimingPoints.Add(finishPoint);

            Crew crew1 = new Crew();
            crew1.CrewId = 1;
            crew1.Results = new List<Result>();
            
            crew1.Results.Add(new Result(startPoint, crew1, new TimeSpan(2, 0, 0)));
            crew1.Results.Add(new Result(finishPoint, crew1, new TimeSpan(2, 20, 0)));
            comp.Crews.Add(crew1);
            crew1.Competition = comp;

            Crew crew2 = new Crew();
            crew2.CrewId = 2;
            crew2.Results = new List<Result>();

            crew2.Results.Add(new Result(startPoint, crew1, new TimeSpan(2, 0, 0)));
            crew2.Results.Add(new Result(finishPoint, crew1, new TimeSpan(2, 21, 0)));
            comp.Crews.Add(crew2);
            crew2.Competition = comp;

            Assert.AreEqual(1, crew1.Placing(finishPoint));
            Assert.AreEqual(2, crew2.Placing(finishPoint));
        }
    }
}
