using HeadRaceTimingSite.Api.Resources;
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
        public static List<Api.Resources.Crew> BuildCrewsList(IEnumerable<Models.Crew> crews)
        {
            Competition competition = crews.First().Competition;
            TimingPoint startPoint = competition.TimingPoints.First();
            TimingPoint finishPoint = competition.TimingPoints.Last();

            List<Api.Resources.Crew> apiCrews = new List<Api.Resources.Crew>();

            foreach (Models.Crew modelCrew in crews)
            {
                Api.Resources.Crew apiCrew = new Api.Resources.Crew()
                {
                    Id = modelCrew.CrewId,
                    Name = modelCrew.Name,
                    StartNumber = modelCrew.StartNumber,
                    OverallTime = modelCrew.OverallTime,
                    Status = modelCrew.Status,
                    IsStarted = modelCrew.Results.Count > 0,
                    IsTimeOnly = modelCrew.IsTimeOnly,
                    IsFinished = modelCrew.OverallTime.HasValue,
                    CriMax = modelCrew.CriMax
                };

                foreach (Models.Result modelResult in modelCrew.Results)
                {
                    Api.Resources.Result apiResult = new Api.Resources.Result()
                    {
                        Id = modelResult.TimingPointId,
                        TimeOfDay = modelResult.TimeOfDay,
                        RunTime = modelCrew.RunTime(startPoint.TimingPointId, modelResult.TimingPointId),
                        SectionTime = startPoint.TimingPointId != modelResult.TimingPointId ? 
                            modelCrew.RunTime(competition.TimingPoints.IndexOf(modelResult.TimingPoint) - 1, modelResult.TimingPointId) : null
                    };
                    apiCrew.Results.Add(apiResult);
                }

                apiCrews.Add(apiCrew);
            }

            for (int i = 1; i < competition.TimingPoints.Count - 1; i++)
            {
                int currentTimingPointId = competition.TimingPoints[i].TimingPointId;
                apiCrews = apiCrews.OrderByDescending(x => x.Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime != null)
                    .ThenBy(x => x.Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime).ToList();

                int rank = 1;
                for (int j = 0; j < apiCrews.Count; j++)
                {
                    if (apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId) == null)
                        break;

                    if (j == 0)
                    {
                        if (apiCrews.Count > 1)
                        {
                            apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).Rank = 
                                rank.ToString(CultureInfo.CurrentCulture) 
                                    + (apiCrews[j + 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime == apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).RunTime ? "=" : String.Empty);
                        }
                        else
                        {
                            apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).Rank = rank.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    else if (apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).RunTime == apiCrews[j - 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId).RunTime)
                    {
                        apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).Rank = rank.ToString(CultureInfo.CurrentCulture) + "=";
                    }
                    else
                    {
                        rank = j + 1;
                        if (j < apiCrews.Count - 1)
                            apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).Rank = rank.ToString(CultureInfo.CurrentCulture) + (apiCrews[j + 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime == apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime ? "=" : String.Empty);
                        else
                            apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId).Rank = rank.ToString(CultureInfo.CurrentCulture);
                    }
                }
            }

            if (competition.TimingPoints.Count > 2)
            {
                int firstIntermediateId = competition.TimingPoints[1].TimingPointId;
                if (competition.TimingPoints.Count > 3)
                {
                    int secondIntermediateId = competition.TimingPoints[2].TimingPointId;
                    apiCrews = apiCrews.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0)
                        .ThenByDescending(x => x.OverallTime.HasValue).ThenBy(x => x.OverallTime)
                        .ThenByDescending(x => x.Results.FirstOrDefault(y => y.Id == secondIntermediateId)?.RunTime != null)
                        .ThenBy(x => x.Results.FirstOrDefault(y => y.Id == secondIntermediateId)?.RunTime)
                        .ThenByDescending(x => x.Results.FirstOrDefault(y => y.Id == firstIntermediateId)?.RunTime != null)
                        .ThenBy(x => x.Results.FirstOrDefault(y => y.Id == firstIntermediateId)?.RunTime).ToList();
                }
                else
                {
                    apiCrews = apiCrews.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0)
                        .ThenByDescending(x => x.OverallTime.HasValue).ThenBy(x => x.OverallTime)
                        .ThenByDescending(x => x.Results.FirstOrDefault(y => y.Id == firstIntermediateId)?.RunTime != null)
                        .ThenBy(x => x.Results.FirstOrDefault(y => y.Id == firstIntermediateId)?.RunTime).ToList();
                }
            }
            else
            {
                apiCrews = apiCrews.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0)
                .ThenByDescending(x => x.OverallTime.HasValue).ThenBy(x => x.OverallTime).ToList();
            }
            
            int overallRank = 1;
            for (int i = 0; i < apiCrews.Count; i++)
            {
                if (apiCrews[i].OverallTime == null)
                    break;

                if (i == 0)
                {
                    if (apiCrews.Count > 1)
                    {
                        apiCrews[i].Rank = overallRank.ToString(CultureInfo.CurrentCulture) + (apiCrews[i + 1].OverallTime == apiCrews[i].OverallTime ? "=" : String.Empty);
                    }
                    else
                    {
                        apiCrews[i].Rank = overallRank.ToString(CultureInfo.CurrentCulture);
                    }
                }
                else if (apiCrews[i].OverallTime == apiCrews[i - 1].OverallTime)
                {
                    apiCrews[i].Rank = overallRank.ToString(CultureInfo.CurrentCulture) + "=";
                }
                else
                {
                    overallRank = i + 1;
                    if (i < apiCrews.Count - 1)
                        apiCrews[i].Rank = overallRank.ToString(CultureInfo.CurrentCulture) + (apiCrews[i + 1].OverallTime == apiCrews[i].OverallTime ? "=" : String.Empty);
                    else
                        apiCrews[i].Rank = overallRank.ToString(CultureInfo.CurrentCulture);
                }
            }

            return apiCrews;
        }
    }
}
