using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HeadRaceTimingSite.ViewModels.Api;
using HeadRaceTimingSite.Models;

namespace HeadRaceTimingSite.Helpers
{
    public static class ResultsHelper
    {
        public static List<ViewModels.Api.Result> BuildResultsList(IEnumerable<Models.Crew> crews)
        {
            Models.Competition competition = crews.First().Competition;
            TimingPoint startPoint = competition.TimingPoints.First();
            TimingPoint firstIntermediatePoint = competition.TimingPoints[1];
            TimingPoint secondIntermediatePoint = competition.TimingPoints[2];
            TimingPoint finishPoint = competition.TimingPoints.Last();

            List<ViewModels.Api.Result> results = crews.Select(x => new ViewModels.Api.Result()
            {
                CrewId = x.CrewId,
                Name = x.Name,
                StartNumber = x.StartNumber,
                OverallTime = x.OverallTime,
                FirstIntermediateTime = x.RunTime(startPoint.TimingPointId, firstIntermediatePoint.TimingPointId),
                SecondIntermediateTime = x.RunTime(startPoint.TimingPointId, secondIntermediatePoint.TimingPointId),
                Status = x.Status,
                IsStarted = x.Results.Count > 0,
                IsTimeOnly = x.IsTimeOnly,
                IsFinished = x.OverallTime.HasValue,
                CriMax = x.CriMax
            }).ToList();

            results = results.OrderByDescending(x => x.FirstIntermediateTime.HasValue).ThenBy(x => x.FirstIntermediateTime).ToList();

            int rank = 1;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].FirstIntermediateTime == null)
                    break;

                if (i == 0)
                {
                    if (results.Count > 1)
                    {
                        results[i].FirstIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].FirstIntermediateTime == results[i].FirstIntermediateTime ? "=" : String.Empty);
                    }
                    else
                    {
                        results[i].FirstIntermediateRank = rank.ToString(CultureInfo.CurrentCulture);
                    }
                }
                else if (results[i].FirstIntermediateTime == results[i - 1].FirstIntermediateTime)
                {
                    results[i].FirstIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + "=";
                }
                else
                {
                    rank = i + 1;
                    if (i < results.Count - 1)
                        results[i].FirstIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].FirstIntermediateTime == results[i].FirstIntermediateTime ? "=" : String.Empty);
                    else
                        results[i].FirstIntermediateRank = rank.ToString(CultureInfo.CurrentCulture);
                }
            }

            results = results.OrderByDescending(x => x.SecondIntermediateTime.HasValue).ThenBy(x => x.SecondIntermediateTime).ToList();

            rank = 1;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].SecondIntermediateTime == null)
                    break;

                if (i == 0)
                {
                    if (results.Count > 1)
                    {
                        results[i].SecondIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].SecondIntermediateTime == results[i].SecondIntermediateTime ? "=" : String.Empty);
                    }
                    else
                    {
                        results[i].SecondIntermediateRank = rank.ToString(CultureInfo.CurrentCulture);
                    }
                }
                else if (results[i].SecondIntermediateTime == results[i - 1].SecondIntermediateTime)
                {
                    results[i].SecondIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + "=";
                }
                else
                {
                    rank = i + 1;
                    if (i < results.Count - 1)
                        results[i].SecondIntermediateRank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].SecondIntermediateTime == results[i].SecondIntermediateTime ? "=" : String.Empty);
                    else
                        results[i].SecondIntermediateRank = rank.ToString(CultureInfo.CurrentCulture);
                }
            }

            results = results.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0)
                .ThenByDescending(x => x.OverallTime.HasValue).ThenBy(x => x.OverallTime)
                .ThenByDescending(x => x.SecondIntermediateTime.HasValue).ThenBy(x => x.SecondIntermediateTime)
                .ThenByDescending(x => x.FirstIntermediateTime.HasValue).ThenBy(x => x.FirstIntermediateTime).ToList();

            rank = 1;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].OverallTime == null)
                    break;

                if (i == 0)
                {
                    if (results.Count > 1)
                    {
                        results[i].Rank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].OverallTime == results[i].OverallTime ? "=" : String.Empty);
                    }
                    else
                    {
                        results[i].Rank = rank.ToString(CultureInfo.CurrentCulture);
                    }
                }
                else if (results[i].OverallTime == results[i - 1].OverallTime)
                {
                    results[i].Rank = rank.ToString(CultureInfo.CurrentCulture) + "=";
                }
                else
                {
                    rank = i + 1;
                    if (i < results.Count - 1)
                        results[i].Rank = rank.ToString(CultureInfo.CurrentCulture) + (results[i + 1].OverallTime == results[i].OverallTime ? "=" : String.Empty);
                    else
                        results[i].Rank = rank.ToString(CultureInfo.CurrentCulture);
                }
            }

            return results;
        }
    }
}
