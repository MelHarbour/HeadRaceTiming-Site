using HeadRaceTimingSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadRaceTimingSite.Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void Rank_WithSingleResult_ShouldReturnOne()
        {
            Result result = new Result();
            result.TimeOfDay = TimeSpan.Zero;

            List<Result> resultsList = new List<Result>();
            resultsList.Add(result);

            Assert.AreEqual("1", result.Rank(resultsList));
        }

        [TestMethod]
        public void Rank_WithMultipleDistinct_ShouldReturnPlacing()
        {
            Result resultOne = new Result();
            resultOne.TimeOfDay = TimeSpan.Zero;
            Result resultTwo = new Result();
            resultTwo.TimeOfDay = TimeSpan.Zero.Add(TimeSpan.MinValue);

            List<Result> resultsList = new List<Result>();
            resultsList.Add(resultOne);
            resultsList.Add(resultTwo);

            Assert.AreEqual("1", resultOne.Rank(resultsList));
            Assert.AreEqual("2", resultTwo.Rank(resultsList));
        }

        [TestMethod]
        public void Rank_WithTwoIdenticalTimes_ShouldReturnEqualPlacings()
        {
            Result resultOne = new Result();
            resultOne.TimeOfDay = TimeSpan.Zero;
            Result resultTwo = new Result();
            resultTwo.TimeOfDay = TimeSpan.Zero;

            List<Result> resultsList = new List<Result>();
            resultsList.Add(resultOne);
            resultsList.Add(resultTwo);

            Assert.AreEqual("1=", resultOne.Rank(resultsList));
            Assert.AreEqual("1=", resultTwo.Rank(resultsList));
        }

        [TestMethod]
        public void Rank_WithThreeIdenticalTimes_ShouldReturnEqualPlacings()
        {
            Result resultOne = new Result();
            resultOne.TimeOfDay = TimeSpan.Zero;
            Result resultTwo = new Result();
            resultTwo.TimeOfDay = TimeSpan.Zero;
            Result resultThree = new Result();
            resultThree.TimeOfDay = TimeSpan.Zero;

            List<Result> resultsList = new List<Result>();
            resultsList.Add(resultOne);
            resultsList.Add(resultTwo);
            resultsList.Add(resultThree);

            Assert.AreEqual("1=", resultOne.Rank(resultsList));
            Assert.AreEqual("1=", resultTwo.Rank(resultsList));
            Assert.AreEqual("1=", resultThree.Rank(resultsList));
        }
    }
}
