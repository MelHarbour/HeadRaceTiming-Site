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
            if (mapper is null)
                throw new ArgumentNullException(nameof(mapper));

            if (crews is null)
                throw new ArgumentNullException(nameof(crews));

            List<Api.Resources.Crew> apiCrews = new List<Api.Resources.Crew>();

            if (!crews.Any())
                return apiCrews;

            Models.Competition competition = crews.First().Competition;
            TimingPoint finishPoint = competition.TimingPoints.Last();

            foreach (Models.Crew modelCrew in crews)
            {
                Api.Resources.Crew apiCrew = BuildCrew(mapper, competition, modelCrew);

                apiCrews.Add(apiCrew);
            }

            for (int i = 1; i < competition.TimingPoints.Count - 1; i++)
            {
                apiCrews = OrderCrews(apiCrews, competition, competition.TimingPoints[i]);
                
                int currentTimingPointId = competition.TimingPoints[i].TimingPointId;
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

            apiCrews = OrderCrews(apiCrews, competition);

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

        public static List<Api.Resources.Crew> OrderCrews(List<Api.Resources.Crew> apiCrews, Models.Competition competition, Models.TimingPoint timingPoint)
        {
            if (apiCrews is null)
                throw new ArgumentNullException(nameof(apiCrews));

            if (competition is null)
                throw new ArgumentNullException(nameof(competition));

            if (timingPoint is null)
                throw new ArgumentNullException(nameof(timingPoint));

            int timingPointIndex = competition.TimingPoints.IndexOf(timingPoint);

            var ordered = apiCrews.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0);

            for (int i = timingPointIndex; i > 0; i--)
            {
                ordered = ordered.ThenByDescending(x => x.Results.FirstOrDefault(y => y.Id == competition.TimingPoints[timingPointIndex].TimingPointId)?.RunTime != null)
                    .ThenBy(x => x.Results.FirstOrDefault(y => y.Id == competition.TimingPoints[timingPointIndex].TimingPointId)?.RunTime);
            }
            
            return ordered.ToList();
        }

        public static List<Models.Crew> OrderCrews(List<Models.Crew> crews, Models.Competition competition, Models.TimingPoint timingPoint)
        {
            if (crews is null)
                throw new ArgumentNullException(nameof(crews));

            if (competition is null)
                throw new ArgumentNullException(nameof(competition));

            if (timingPoint is null)
                throw new ArgumentNullException(nameof(timingPoint));

            int timingPointIndex = competition.TimingPoints.IndexOf(timingPoint);

            var ordered = crews.OrderByDescending(x => (x.IsStarted) ? (x.IsTimeOnly ? 1 : 2) : 0);

            for (int i = timingPointIndex; i > 0; i--)
            {
                ordered = ordered.ThenByDescending(x => x.Results.FirstOrDefault(y => y.TimingPointId == competition.TimingPoints[timingPointIndex].TimingPointId) != null)
                    .ThenBy(x => x.RunTime(competition.TimingPoints.First(), timingPoint));
            }

            return ordered.ToList();
        }

        public static List<Api.Resources.Crew> OrderCrews(List<Api.Resources.Crew> apiCrews, Models.Competition competition)
        {
            if (apiCrews is null)
                throw new ArgumentNullException(nameof(apiCrews));

            if (competition is null)
                throw new ArgumentNullException(nameof(competition));

            return OrderCrews(apiCrews, competition, competition.TimingPoints.Last());
        }

        public static Api.Resources.Crew BuildCrew(IMapper mapper, Models.Competition competition, Models.Crew modelCrew)
        {
            if (mapper is null)
                throw new ArgumentNullException(nameof(mapper));
            if (competition is null)
                throw new ArgumentNullException(nameof(competition));
            if (modelCrew is null)
                throw new ArgumentNullException(nameof(modelCrew));

            TimingPoint startPoint = competition.TimingPoints.First();

            Api.Resources.Crew apiCrew = mapper.Map<Api.Resources.Crew>(modelCrew);

            foreach (Models.Result modelResult in modelCrew.Results)
            {
                Api.Resources.Result apiResult = new Api.Resources.Result()
                {
                    Id = modelResult.TimingPointId,
                    TimeOfDay = modelResult.TimeOfDay,
                    Name = modelResult.TimingPoint.Name,
                    RunTime = modelCrew.RunTime(startPoint.TimingPointId, modelResult.TimingPointId),
                    SectionTime = startPoint.TimingPointId != modelResult.TimingPointId ?
                        modelCrew.RunTime(competition.TimingPoints[competition.TimingPoints.IndexOf(modelResult.TimingPoint) - 1].TimingPointId,
                            modelResult.TimingPointId) : null
                };
                apiCrew.Results.Add(apiResult);
            }

            return apiCrew;
        }
    }
}
