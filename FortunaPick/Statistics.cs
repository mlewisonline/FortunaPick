using Newtonsoft.Json;

namespace FortunaPick
{
    public class Lotto(Dictionary<int, int> mainBalls)
    {
        public Dictionary<int, int> MainBalls { get; } = mainBalls;

    }

    public class EuroMillions(Dictionary<int, int> mainBalls, Dictionary<int, int> stars)
    {
        public Dictionary<int, int> MainBalls { get; } = mainBalls;
        public Dictionary<int, int> Stars { get; } = stars;
    }

    public class ThunderBall(Dictionary<int, int> mainBalls, Dictionary<int, int> thunderBalls)
    {
        public Dictionary<int, int> MainBalls { get; } = mainBalls;
        public Dictionary<int, int> Thunderballs { get; } = thunderBalls;
    }

    public class SetForLife(Dictionary<int, int> mainBalls, Dictionary<int, int> lifeBalls)
    {
        public Dictionary<int, int> MainBalls { get; } = mainBalls;
        public Dictionary<int, int> LifeBalls { get; } = lifeBalls;
    }

    public class Statistics
    {
        public Lotto Lotto { get; }

        public ThunderBall ThunderBall { get; }

        public EuroMillions EuroMillions { get; }

        public SetForLife SetForLife { get;}

        public Lotto LottoSorted { get; }

        public ThunderBall ThunderBallSorted { get; }

        public EuroMillions EuroMillionsSorted { get; }

        public SetForLife SetForLifeSorted { get; }

        public Dictionary<int, int> LottoHotSix { get; }
        public Statistics()
        {
            // Initialize Statistics Properties
            Lotto = new (LoadGameStatsFile(@"gamestats\lotto-main-stats.json"));

            ThunderBall = new (LoadGameStatsFile(@"gamestats\thunderball-main-stats.json"),
                               LoadGameStatsFile(@"gamestats\thunderball-thunderball-stats.json"));

            EuroMillions = new (LoadGameStatsFile(@"gamestats\euromillion-main-stats.json"),
                                LoadGameStatsFile(@"gamestats\euromillion-star-stats.json"));

            SetForLife = new(LoadGameStatsFile(@"gamestats\setforlife-main-stats.json"),
                             LoadGameStatsFile(@"gamestats\setforlife-lifeball-stats.json"));

            // Initialize Sorted Statistics Properties
            LottoSorted = new (SortStatistics(Lotto.MainBalls));

            ThunderBallSorted = new(SortStatistics(ThunderBall.MainBalls),
                                    SortStatistics(ThunderBall.Thunderballs));

            EuroMillionsSorted = new(SortStatistics(EuroMillions.MainBalls),
                                     SortStatistics(EuroMillions.Stars));

            SetForLifeSorted = new(SortStatistics(SetForLife.MainBalls),
                                   SortStatistics(SetForLife.LifeBalls));


            // Initialize Hot 6 Statistics Properties
            LottoHotSix = LottoSorted.MainBalls.Take(6).ToDictionary();
        }


        private static Dictionary<int, int> LoadGameStatsFile(string file)
        {
            if(File.Exists(file))
            { 
               var json = File.ReadAllText(file);
               return JsonConvert.DeserializeObject<Dictionary<int, int>>(json);           
            }
            return [];     
        }


        private static Dictionary<int, int> SortStatistics(Dictionary<int, int> dataToSort)
        {
            return (from keyValuePair in dataToSort
                    orderby keyValuePair.Value descending
                    select keyValuePair).ToDictionary();
        }

    }
}
