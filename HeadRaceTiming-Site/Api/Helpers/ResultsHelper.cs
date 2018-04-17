using AutoMapper;
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
        public static List<Api.Resources.Crew> BuildCrewsList(IMapper mapper, IEnumerable<Models.Crew> crews)
        {
            List<Api.Resources.Crew> apiCrews = new List<Api.Resources.Crew>();

            if (crews.Count() == 0)
                return apiCrews;

            Competition competition = crews.First().Competition;
            TimingPoint startPoint = competition.TimingPoints.First();
            TimingPoint finishPoint = competition.TimingPoints.Last();

            foreach (Models.Crew modelCrew in crews)
            {
                Api.Resources.Crew apiCrew = mapper.Map<Api.Resources.Crew>(modelCrew);

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
                    Api.Resources.Result currentResult = apiCrews[j].Results.FirstOrDefault(y => y.Id == currentTimingPointId);
                    if (currentResult == null)
                        break;

                    currentResult.Rank = rank.ToString(CultureInfo.CurrentCulture);

                    if (j == 0)
                    {
                        if (apiCrews.Count > 1)
                        {
                            currentResult.Rank += (apiCrews[j + 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime == currentResult.RunTime ? "=" : String.Empty);
                        }
                    }
                    else if (currentResult.RunTime == apiCrews[j - 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId).RunTime)
                    {
                        currentResult.Rank += "=";
                    }
                    else
                    {
                        rank = j + 1;
                        if (j < apiCrews.Count - 1)
                            currentResult.Rank += (apiCrews[j + 1].Results.FirstOrDefault(y => y.Id == currentTimingPointId)?.RunTime == currentResult.RunTime ? "=" : String.Empty);
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
                Api.Resources.Crew currentCrew = apiCrews[i];
                if (currentCrew.OverallTime == null)
                    break;

                currentCrew.Rank = overallRank.ToString(CultureInfo.CurrentCulture);

                if (i == 0)
                {
                    if (apiCrews.Count > 1)
                    {
                        currentCrew.Rank += (apiCrews[i + 1].OverallTime == currentCrew.OverallTime ? "=" : String.Empty);
                    }
                }
                else if (currentCrew.OverallTime == apiCrews[i - 1].OverallTime)
                {
                    currentCrew.Rank += "=";
                }
                else
                {
                    overallRank = i + 1;
                    if (i < apiCrews.Count - 1)
                        currentCrew.Rank += (apiCrews[i + 1].OverallTime == currentCrew.OverallTime ? "=" : String.Empty);
                }
            }

            return apiCrews;
        }
    }
}
