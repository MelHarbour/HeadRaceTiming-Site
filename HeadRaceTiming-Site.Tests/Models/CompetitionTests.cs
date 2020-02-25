using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadRaceTimingSite.Models;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Tests.Models
{
    [TestClass]
    public class CompetitionTests
    {
        [TestMethod]
        public void StandardTime_WithNoResults_ShouldReturnNull()
        {
            Competition competition = new Competition();
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 1 });
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 2 });
            Crew crew1 = new Crew() { Competition = competition };
            Crew crew2 = new Crew() { Competition = competition };
            competition.Crews.Add(crew1);
            competition.Crews.Add(crew2);
            competition.Awards.Add(new Award { IsMasters = true });

            TimeSpan? standardTime = competition.StandardTime;

            Assert.IsNull(standardTime);
        }

        [TestMethod]
        public void StandardTime_WithMastersPennantAndResults_ShouldReturnOverallTime()
        {
            Competition competition = new Competition();
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 1 });
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 2 });
            Award award = new Award { IsMasters = true, AwardId = 1 };
            competition.Awards.Add(award);
            Crew crewOne = new Crew();
            crewOne.Results.Add(new Result { TimingPointId = 1, TimeOfDay = new TimeSpan(10, 0, 0) });
            crewOne.Results.Add(new Result { TimingPointId = 2, TimeOfDay = new TimeSpan(10, 15, 0) });
            crewOne.Competition = competition;
            competition.Crews.Add(crewOne);
            Crew crewTwo = new Crew();
            crewTwo.Results.Add(new Result { TimingPointId = 1, TimeOfDay = new TimeSpan(10, 0, 0) });
            crewTwo.Results.Add(new Result { TimingPointId = 2, TimeOfDay = new TimeSpan(10, 16, 0) });
            crewTwo.Awards.Add(new CrewAward { Award = award });
            crewTwo.Competition = competition;
            award.Crews.Add(new CrewAward { Crew = crewTwo });
            competition.Crews.Add(crewTwo);

            TimeSpan? standardTime = competition.StandardTime;

            Assert.AreEqual(new TimeSpan(0, 15, 0), standardTime);
        }

        [TestMethod]
        public void StandardTime_WithMastersPennantAndResults_ShouldReturnFastestMastersTime()
        {
            Competition competition = new Competition();
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 1 });
            competition.TimingPoints.Add(new TimingPoint { TimingPointId = 2 });
            Award award = new Award { IsMasters = true, AwardId = 1 };
            competition.Awards.Add(award);
            Crew crewOne = new Crew();
            crewOne.Results.Add(new Result { TimingPointId = 1, TimeOfDay = new TimeSpan(10, 0, 0) });
            crewOne.Results.Add(new Result { TimingPointId = 2, TimeOfDay = new TimeSpan(10, 15, 0) });
            crewOne.Awards.Add(new CrewAward { Award = award });
            award.Crews.Add(new CrewAward { Crew = crewOne });
            crewOne.Competition = competition;
            competition.Crews.Add(crewOne);
            Crew crewTwo = new Crew();
            crewTwo.Results.Add(new Result { TimingPointId = 1, TimeOfDay = new TimeSpan(10, 0, 0) });
            crewTwo.Results.Add(new Result { TimingPointId = 2, TimeOfDay = new TimeSpan(10, 16, 0) });
            crewTwo.Awards.Add(new CrewAward { Award = award });
            crewTwo.Competition = competition;
            award.Crews.Add(new CrewAward { Crew = crewTwo });
            competition.Crews.Add(crewTwo);

            TimeSpan? standardTime = competition.StandardTime;

            Assert.AreEqual(new TimeSpan(0, 15, 0), standardTime);
        }
    }
}
