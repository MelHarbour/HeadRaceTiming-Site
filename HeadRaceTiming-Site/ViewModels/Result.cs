using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class Result
    {
        public int CrewId { get; set; }
        public int StartNumber { get; set; }
        public string Name { get; set; }
        public TimeSpan? OverallTime { get; set; }
        public TimeSpan? FirstIntermediateTime { get; set; }
        public TimeSpan? SecondIntermediateTime { get; set; }
        public string Rank { get; set; }
        public string FirstIntermediateRank { get; set; }
        public string SecondIntermediateRank { get; set; }

        public static void RankByOverall(List<Result> results)
        {
            int overallRank = 1;
            TimeSpan previousTime = TimeSpan.Zero;
            foreach (var result in results.Where(x => x.OverallTime.HasValue).OrderBy(x => x.OverallTime))
            {
                result.Rank = (overallRank++).ToString();
                if (result.OverallTime == previousTime)
                {
                    result.Rank = result.Rank + "=";
                }
                previousTime = result.OverallTime.Value;
            }
        }

        public static void RankByFirstIntermediate(List<Result> results)
        {
            int firstRank = 1;
            TimeSpan previousTime = TimeSpan.Zero;
            foreach (var result in results.Where(x => x.FirstIntermediateTime.HasValue).OrderBy(x => x.FirstIntermediateTime))
            {
                result.FirstIntermediateRank = (firstRank++).ToString();
                if (result.FirstIntermediateTime == previousTime)
                {
                    result.FirstIntermediateRank = result.FirstIntermediateRank + "=";
                }
                previousTime = result.FirstIntermediateTime.Value;
            }
        }

        public static void RankBySecondIntermediate(List<Result> results)
        {
            int secondRank = 1;
            TimeSpan previousTime = TimeSpan.Zero;
            foreach (var result in results.Where(x => x.SecondIntermediateTime.HasValue).OrderBy(x => x.SecondIntermediateTime))
            {
                result.SecondIntermediateRank = (secondRank++).ToString();
                if (result.SecondIntermediateTime == previousTime)
                {
                    result.SecondIntermediateRank = result.SecondIntermediateRank + "=";
                }
                previousTime = result.SecondIntermediateTime.Value;
            }
        }
    }
}
