using System.Text.Json;

namespace FortunaPick
{
    public class Statistics
    {
        private static readonly List<string> statFiles =
            [@"gamestats\lotto-main-stats.json", 
             @"gamestats\thunderball-main-stats.json",
             @"gamestats\thunderball-thunderball-stats.json",
             @"gamestats\euromillion-main-stats.json",
             @"gamestats\euromillion-star-stats.json",
             @"gamestats\setforlife-main-stats.json",
             @"gamestats\setforlife-lifeball-stats.json"
        ];


        public static Dictionary<int, int> LottoStatistics = [];
        public static Dictionary<int, int> ThunderBallMainStatistics = [];
        public static Dictionary<int, int> ThunderballStatistics = [];
        public static Dictionary<int, int> EuromillionMainStatistics = [];
        public static Dictionary<int, int> EuromillionStarStatistics = [];
        public static Dictionary<int, int> SetforlifeMainStatistics = [];
        public static Dictionary<int, int> LifeballStatistics = [];


        public static void LoadStatistics()
        {
            LottoStatistics =           SortStatistics(LoadGameStatsFile(statFiles[0]));
            ThunderBallMainStatistics = SortStatistics(LoadGameStatsFile(statFiles[1]));
            ThunderballStatistics =     SortStatistics(LoadGameStatsFile(statFiles[2]));
            EuromillionMainStatistics = SortStatistics(LoadGameStatsFile(statFiles[3]));
            EuromillionStarStatistics = SortStatistics(LoadGameStatsFile(statFiles[4]));
            SetforlifeMainStatistics =  SortStatistics(LoadGameStatsFile(statFiles[5]));
            LifeballStatistics =        SortStatistics(LoadGameStatsFile(statFiles[6]));
        }

        private static Dictionary<int, int> LoadGameStatsFile(string file)
        {
            string statFile = "";
            try
            {
                statFile = File.ReadAllText(file);
            }
            catch (Exception)
            {

                Console.WriteLine("Cant Access Stat file");
            }
            return JsonSerializer.Deserialize<Dictionary<int, int>>(statFile); 
        }

        private static Dictionary<int, int> SortStatistics(Dictionary<int, int> dataToSort)
        {
            return (from keyValuePair in dataToSort
                    orderby keyValuePair.Value descending
                    select keyValuePair).ToDictionary();
        }
    }
}
