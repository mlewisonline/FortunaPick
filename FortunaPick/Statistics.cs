﻿using System.Text.Json;

namespace FortunaPick
{
    public class Statistics
    {
        public BallStatisticsModel? BallStatistics { get; }

        public Statistics()
        {
            // Load ball Statistics
            BallStatistics = LoadData(fileName: @"data\ballstatistics.json");
            // Create sorted data
            BallStatistics.LottoMainBallsSorted = SortStatisticsDescending(BallStatistics.LottoMainBalls);
            BallStatistics.EuromillionsMainBallsSorted = SortStatisticsDescending(BallStatistics.EuromillionsMainBalls);
            BallStatistics.EuromillionsStarsSorted = SortStatisticsDescending(BallStatistics.EuromillionsStars);
            BallStatistics.SetforlifeMainBallsSorted = SortStatisticsDescending(BallStatistics.SetforlifeMainBalls);
            BallStatistics.SetforlifeLifeballsSorted = SortStatisticsDescending(BallStatistics.SetforlifeLifeballs);
            BallStatistics.ThunderballMainBallsSorted = SortStatisticsDescending(BallStatistics.ThunderballMainBalls);
            BallStatistics.ThunderballsSorted = SortStatisticsDescending(BallStatistics.Thunderballs);
            // initailise hot and cold
            BallStatistics.LottoHotSix = BallStatistics.LottoMainBallsSorted.Take(6).ToDictionary();
            BallStatistics.EuromillionsMainHotSix = BallStatistics.EuromillionsMainBallsSorted.Take(6).ToDictionary();
            BallStatistics.EuromillionsStarsHotSix = BallStatistics.EuromillionsStarsSorted.Take(6).ToDictionary();
            BallStatistics.SetforlifeMainHotSix = BallStatistics.SetforlifeMainBallsSorted.Take(6).ToDictionary();
            BallStatistics.SetforlifeLifeballsHotSix = BallStatistics.SetforlifeLifeballsSorted.Take(6).ToDictionary();
            BallStatistics.ThunderballMainHotSix = BallStatistics.ThunderballMainBallsSorted.Take(6).ToDictionary();
            BallStatistics.ThunderballsHotSix = BallStatistics.ThunderballsSorted.Take(6).ToDictionary();

        }

        private static BallStatisticsModel LoadData(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                if (json != null)
                {
                    return JsonSerializer.Deserialize<BallStatisticsModel>(json);
                }
            }
            return new BallStatisticsModel();
        }

        private static Dictionary<int, int> SortStatisticsDescending(Dictionary<int, int>? dataToSort)
        {
            return (from keyValuePair in dataToSort
                    orderby keyValuePair.Value descending
                    select keyValuePair).ToDictionary();
        }

        private static Dictionary<int, int> SortStatisticsAscending(Dictionary<int, int>? dataToSort)
        {
            return (from keyValuePair in dataToSort
                    orderby keyValuePair.Value ascending
                    select keyValuePair).ToDictionary();
        }
    }
}
