using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadRaceTimingSite.Models;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Tests.Models
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

        [TestMethod]
        public void Rank_WithTimeOnlyCrew_ShouldReturnEmptyString()
        {
            TimingPoint startTimingPoint = new TimingPoint(1);
            Result startResult = new Result(startTimingPoint, TimeSpan.Zero);

            TimingPoint finishTimingPoint = new TimingPoint(2);
            Crew crewOne = new Crew();
            crewOne.IsTimeOnly = true;
            crewOne.Results = new List<Result>();
            Result resultOne = new Result(finishTimingPoint, new TimeSpan(0, 0, 0, 0, 410));
            crewOne.Results.Add(startResult);
            crewOne.Results.Add(resultOne);

            List<Crew> crewList = new List<Crew>();
            crewList.Add(crewOne);

            Assert.AreEqual(String.Empty, crewOne.Rank(crewList, startTimingPoint, finishTimingPoint));
        }

        [TestMethod]
        public void AverageAge_WithCrewWithAges_ShouldReturnAverage()
        {
            Crew crew = new Crew();
            Athlete athleteOne = new Athlete();
            Athlete athleteTwo = new Athlete();
            Athlete athleteThree = new Athlete();
            crew.Athletes = new List<CrewAthlete>();
            crew.Athletes.Add(new CrewAthlete { Athlete = athleteOne, Age = 30 });
            crew.Athletes.Add(new CrewAthlete { Athlete = athleteTwo, Age = 31 });
            crew.Athletes.Add(new CrewAthlete { Athlete = athleteThree, Age = 32 });

            Assert.AreEqual(31, crew.AverageAge);
        }

        [DataTestMethod]
        [DataRow(MastersCategory.None, 26)]
        [DataRow(MastersCategory.A, 27)]
        [DataRow(MastersCategory.B, 36)]
        [DataRow(MastersCategory.C, 43)]
        [DataRow(MastersCategory.D, 50)]
        [DataRow(MastersCategory.E, 55)]
        [DataRow(MastersCategory.F, 60)]
        [DataRow(MastersCategory.G, 65)]
        [DataRow(MastersCategory.H, 70)]
        [DataRow(MastersCategory.I, 75)]
        [DataRow(MastersCategory.J, 80)]
        [DataRow(MastersCategory.K, 85)]
        public void MastersCategory_WithCrewWithAges_ShouldReturnCorrectCategory(MastersCategory mastersCategory, int athleteAge)
        {
            Crew crew = new Crew();
            Athlete athlete = new Athlete();
            crew.Athletes = new List<CrewAthlete>();
            crew.Athletes.Add(new CrewAthlete { Athlete = athlete, Age = athleteAge });

            Assert.AreEqual(mastersCategory, crew.MastersCategory, "Category: {0}; Age One: {1}", mastersCategory, athleteAge);
        }

        [TestMethod]
        public void MastersHandicap_WithNonMastersCrew_ShouldThrowInvalidOperationException()
        {
            Crew crew = new Crew();
            Athlete athlete = new Athlete();
            crew.Athletes = new List<CrewAthlete>();
            crew.Athletes.Add(new CrewAthlete { Athlete = athlete, Age = 26 });

            Assert.ThrowsException<InvalidOperationException>(() => crew.CalculateMastersHandicap());
        }
    }
}
