using HeadRaceTimingSite.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Helpers
{
    public static class ResultsHelper
    {
        public static List<ViewModels.Result> BuildResultsList(IEnumerable<Crew> crews)
        {
            Competition competition = crews.First().Competition;
            TimingPoint startPoint = competition.TimingPoints.First();
            TimingPoint firstIntermediatePoint = competition.TimingPoints[1];
            TimingPoint secondIntermediatePoint = competition.TimingPoints[2];
            TimingPoint finishPoint = competition.TimingPoints.Last();

            IEnumerable<Crew> firstIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, firstIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, firstIntermediatePoint));
            IEnumerable<Crew> secondIntermediateCrewList = crews.Where(x => x.RunTime(startPoint, secondIntermediatePoint).HasValue).OrderBy(x => x.RunTime(startPoint, secondIntermediatePoint));
            IEnumerable<Crew> finishCrewList = crews.OrderByDescending(x => (x.Results.Count > 0) ? (x.IsTimeOnly ? 1 : 2) : 0)
                .ThenByDescending(x => x.RunTime(startPoint, finishPoint).HasValue).ThenBy(x => x.RunTime(startPoint, finishPoint))
                .ThenByDescending(x => x.RunTime(startPoint, secondIntermediatePoint).HasValue).ThenBy(x => x.RunTime(startPoint, secondIntermediatePoint))
                .ThenByDescending(x => x.RunTime(startPoint, firstIntermediatePoint).HasValue).ThenBy(x => x.RunTime(startPoint, firstIntermediatePoint));

            List<ViewModels.Result> results = finishCrewList.Select(x => new ViewModels.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.OverallTime),
                Rank = x.OverallTime != null ? x.Rank(finishCrewList, startPoint, finishPoint) : String.Empty,
                FirstIntermediateRank = x.RunTime(startPoint.TimingPointId, firstIntermediatePoint.TimingPointId) != null ? x.Rank(firstIntermediateCrewList, startPoint, firstIntermediatePoint) : String.Empty,
                SecondIntermediateRank = x.RunTime(startPoint.TimingPointId, secondIntermediatePoint.TimingPointId) != null ? x.Rank(secondIntermediateCrewList, startPoint, secondIntermediatePoint) : String.Empty,
                FirstIntermediateTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.RunTime(startPoint.TimingPointId, firstIntermediatePoint.TimingPointId)),
                SecondIntermediateTime = String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.ff}", x.RunTime(startPoint.TimingPointId, secondIntermediatePoint.TimingPointId)),
                Status = x.Status,
                IsStarted = x.Results.Count > 0,
                CriMax = x.CriMax
            }).ToList();

            return results;
        }
    }
}
