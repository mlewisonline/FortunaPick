using System.Text.Json;

namespace FortunaPick
{
    public class Statistics
    {
        public Lotto? LottoData { get; }
        public ThunderBall? ThunderBallData { get; }
        public EuroMillions? EuroMillionsData { get; }
        public SetForLife? SetforLifeData { get; }


        public Statistics()
        {
            // Load Main Game Data Statistics
            LottoData = LoadGameData<Lotto>(LottoData, @"gamestats\lotto.json");
            ThunderBallData = LoadGameData<ThunderBall>(ThunderBallData,@"gamestats\thunderball.json");
            EuroMillionsData = LoadGameData<EuroMillions>(EuroMillionsData,@"gamestats\euromillions.json");
            SetforLifeData = LoadGameData<SetForLife>(SetforLifeData,@"gamestats\setforlife.json");

            // Build the Statistics for use
            LottoData.MainballsSorted = SortStatisticsDescending(LottoData.Mainballs);
            LottoData.MainBallHotSix = LottoData.MainballsSorted.Take(6).ToDictionary();
            LottoData.MainBallColdSix = SortStatisticsAscending(LottoData.MainballsSorted).Take(6).ToDictionary();

            ThunderBallData.MainballsSorted = SortStatisticsDescending(ThunderBallData.Mainballs);
            ThunderBallData.MainBallHotSix = ThunderBallData.MainballsSorted.Take(6).ToDictionary();
            ThunderBallData.MainBallColdSix = SortStatisticsAscending(ThunderBallData.MainballsSorted).Take(6).ToDictionary();

            ThunderBallData.ThunderballSorted = SortStatisticsDescending(ThunderBallData.Thunderball);
            ThunderBallData.ThunderballHotSix = ThunderBallData.ThunderballSorted.Take(6).ToDictionary();
            ThunderBallData.ThunderballColdSix = SortStatisticsAscending(ThunderBallData.ThunderballSorted).Take(6).ToDictionary();

            EuroMillionsData.MainballsSorted = SortStatisticsDescending(EuroMillionsData.Mainballs);
            EuroMillionsData.MainBallHotSix = EuroMillionsData.MainballsSorted.Take(6).ToDictionary();
            EuroMillionsData.MainBallColdSix = SortStatisticsAscending(EuroMillionsData.MainballsSorted).Take(6).ToDictionary();

            EuroMillionsData.StarsSorted = SortStatisticsDescending(EuroMillionsData.Stars);
            EuroMillionsData.StarsHotSix = EuroMillionsData.StarsSorted.Take(6).ToDictionary();
            EuroMillionsData.StarsColdSix = SortStatisticsAscending(EuroMillionsData.StarsSorted).Take(6).ToDictionary();

            SetforLifeData.MainballsSorted = SortStatisticsDescending(SetforLifeData.Mainballs);
            SetforLifeData.MainBallHotSix = SetforLifeData.MainballsSorted.Take(6).ToDictionary();
            SetforLifeData.MainBallColdSix = SortStatisticsAscending(SetforLifeData.MainballsSorted).Take(6).ToDictionary();

            SetforLifeData.LifeballSorted = SortStatisticsDescending(SetforLifeData.Lifeball);
            SetforLifeData.LifeballHotSix = SetforLifeData.LifeballSorted.Take(6).ToDictionary();
            SetforLifeData.LifeballColdSix = SortStatisticsAscending(SetforLifeData.LifeballSorted).Take(6).ToDictionary();
        }


        private static T LoadGameData<T>(T? output_object, string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                if (json != null)
                {
                     return JsonSerializer.Deserialize<T>(json);
                }
            }
            return output_object;
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
