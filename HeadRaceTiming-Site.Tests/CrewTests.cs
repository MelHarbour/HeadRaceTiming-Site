using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadRaceTimingSite.Models;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Tests
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
            TimingPoint startPoint = new TimingPoint(1);
            TimingPoint finishPoint = new TimingPoint(2);

            crew.Results.Add(new Result(startPoint, crew, new TimeSpan(2, 0, 0)));
            crew.Results.Add(new Result(finishPoint, crew, new TimeSpan(2, 20, 0)));

            Assert.AreEqual(new TimeSpan(0, 20, 0), crew.RunTime(startPoint, finishPoint));
        }

        [TestMethod]
        public void RunTime_ShouldRoundToNearestTenth()
        {
            Crew crew = new Crew();
            crew.CrewId = 1;
            crew.Results = new List<Result>();
            TimingPoint startPoint = new TimingPoint(1);
            TimingPoint finishPoint = new TimingPoint(2);

            crew.Results.Add(new Result(startPoint, crew, new TimeSpan(2, 0, 0)));
            crew.Results.Add(new Result(finishPoint, crew, new TimeSpan(0, 2, 20, 0, 210)));

            Assert.AreEqual(new TimeSpan(0, 0, 20, 0, 200), crew.RunTime(startPoint, finishPoint));
        }

        [TestMethod]
        public void Rank_WithSingleResult_ShouldReturnOne()
        {
            Crew crew = new Crew();
            crew.Results = new List<Result>();
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            crew.Results.Add(startResult);
            TimingPoint finishTimingPoint = new TimingPoint(2);
            Result finishResult = new Result(finishTimingPoint, TimeSpan.Zero);
            crew.Results.Add(finishResult);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crew);

            Assert.AreEqual("1", crew.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void Rank_WithMultipleDistinct_ShouldReturnPlacing()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            TimingPoint finishTimingPoint = new TimingPoint(2);
            Crew crewOne = new Crew();
            crewOne.Results = new List<Result>();
            Result resultOne = new Result(finishTimingPoint, TimeSpan.Zero);
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);
            Crew crewTwo = new Crew();
            crewTwo.Results = new List<Result>();
            Result resultTwo = new Result(finishTimingPoint, TimeSpan.Zero.Add(new TimeSpan(0, 0, 2)));
            crewTwo.Results.Add(startResult);
            crewTwo.Results.Add(resultTwo);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);
            crewList.Add(crewTwo);

            Assert.AreEqual("1", crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("2", crewTwo.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void Rank_WithTwoIdenticalTimes_ShouldReturnEqualPlacings()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            TimingPoint finishTimingPoint = new TimingPoint(2);
            Crew crewOne = new Crew();
            crewOne.Results = new List<Result>();

            Result resultOne = new Result(finishTimingPoint, TimeSpan.Zero);
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);
            Crew crewTwo = new Crew();
            crewTwo.Results = new List<Result>();
            Result resultTwo = new Result(finishTimingPoint, TimeSpan.Zero);
            crewTwo.Results.Add(startResult);
            crewTwo.Results.Add(resultTwo);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);
            crewList.Add(crewTwo);

            Assert.AreEqual("1=", crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("1=", crewTwo.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void Rank_WithThreeIdenticalTimes_ShouldReturnEqualPlacings()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            TimingPoint finishTimingPoint = new TimingPoint(2);

            Crew crewOne = new Crew();
            crewOne.Results = new List<Result>();
            Result resultOne = new Result(finishTimingPoint, TimeSpan.Zero);
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);
            Crew crewTwo = new Crew();
            crewTwo.Results = new List<Result>();
            Result resultTwo = new Result(finishTimingPoint, TimeSpan.Zero);
            crewTwo.Results.Add(startResult);
            crewTwo.Results.Add(resultTwo);
            Crew crewThree = new Crew();
            crewThree.Results = new List<Result>();
            Result resultThree = new Result(finishTimingPoint, TimeSpan.Zero);
            crewThree.Results.Add(startResult);
            crewThree.Results.Add(resultThree);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);
            crewList.Add(crewTwo);
            crewList.Add(crewThree);

            Assert.AreEqual("1=", crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("1=", crewTwo.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("1=", crewThree.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void Rank_WithTimesWithinOneTenthRoundingEqual_ShouldReturnEqual()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            TimingPoint finishTimingPoint = new TimingPoint(2);
            Crew crewOne = new Crew();
            crewOne.Results = new List<Result>();
            Result resultOne = new Result(finishTimingPoint, TimeSpan.Zero);
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);
            Crew crewTwo = new Crew();
            crewTwo.Results = new List<Result>();
            Result resultTwo = new Result(finishTimingPoint, TimeSpan.Zero.Add(new TimeSpan(0, 0, 0, 0, 5)));
            crewTwo.Results.Add(startResult);
            crewTwo.Results.Add(resultTwo);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);
            crewList.Add(crewTwo);

            Assert.AreEqual("1=", crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("1=", crewTwo.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void Rank_WithTimesWithinOneTenthRoundingNotEqual_ShouldReturnNotEqual()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);
            TimingPoint finishTimingPoint = new TimingPoint(2);
            Crew crewOne = new Crew();
            crewOne.Results = new List<Result>();
            Result resultOne = new Result(finishTimingPoint, new TimeSpan(0, 0, 0, 0, 410));
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);
            Crew crewTwo = new Crew();
            crewTwo.Results = new List<Result>();
            Result resultTwo = new Result(finishTimingPoint, new TimeSpan(0, 0, 0, 0, 490));
            crewTwo.Results.Add(startResult);
            crewTwo.Results.Add(resultTwo);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);
            crewList.Add(crewTwo);

            Assert.AreEqual("1", crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
            Assert.AreEqual("2", crewTwo.Rank(crewList, startTimingPoint, finishTimingPoint));
        }
    }
}
