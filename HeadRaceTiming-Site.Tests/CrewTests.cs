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
    }
}
