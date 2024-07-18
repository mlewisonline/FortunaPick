using System.Diagnostics;

namespace FortunaPick
{
    public class DrawResults
    {
        private readonly string lottoHistoryPath = $"data{Path.DirectorySeparatorChar}lotto-history.csv";
        private readonly string thunderballistoryPath = $"data{Path.DirectorySeparatorChar}thunderball-history.csv";
        private readonly string euromillionHistoryPath = $"data{Path.DirectorySeparatorChar}euromillion-history.csv";
        private readonly string setforlifeHistoryPath = $"data{Path.DirectorySeparatorChar}setforlife-history.csv";
        private readonly string baseURL = "https://www.national-lottery.co.uk/results/";
        public List<LottoResult>? LottoResults { get; set; }
        public List<ThunderBallResult>? ThunderBallResults { get; set; }
        public List<EuroMillionsResult>? EuroMillionsResults { get; set; }
        public List<SetForLifeResult>? SetForLifeResults { get; set; }

        public DrawResults()
        {
           
            Initialize();
            LottoResults = DrawHistoryUtils.CSV2LottoResultsList(lottoHistoryPath);
            ThunderBallResults = DrawHistoryUtils.CSV2ThunderBallResultsList(thunderballistoryPath);
            EuroMillionsResults = DrawHistoryUtils.CSV2EuroMillionsResultsList(euromillionHistoryPath);
            SetForLifeResults = DrawHistoryUtils.CSV2SetForLifeResultsList(setforlifeHistoryPath);
        }

        private void Initialize()
        {
            if (!File.Exists(lottoHistoryPath) || IsFileOver3HoursOld(lottoHistoryPath))
            {
                Debug.WriteLine("Updating Local Lotto Results CSV");
                DrawHistoryUtils.DownloadCSV($"{baseURL}lotto/draw-history/csv", lottoHistoryPath);
            }
            if (!File.Exists(thunderballistoryPath) || IsFileOver3HoursOld(thunderballistoryPath))
            {
                Debug.WriteLine("Updating Local ThunderBall Results CSV");
                DrawHistoryUtils.DownloadCSV($"{baseURL}thunderball/draw-history/csv", thunderballistoryPath);
            }
            if (!File.Exists(euromillionHistoryPath) || IsFileOver3HoursOld(euromillionHistoryPath))
            {
                Debug.WriteLine("Updating Local EuroMillions Results CSV");
                DrawHistoryUtils.DownloadCSV($"{baseURL}euromillions/draw-history/csv", euromillionHistoryPath);
            }
            if (!File.Exists(setforlifeHistoryPath) || IsFileOver3HoursOld(setforlifeHistoryPath))
            {
                Debug.WriteLine("Updating Local SetForLife Results CSV");
                DrawHistoryUtils.DownloadCSV($"{baseURL}set-for-life/draw-history/csv", setforlifeHistoryPath);
            }
            if (File.Exists(setforlifeHistoryPath) && !IsFileOver3HoursOld(setforlifeHistoryPath))
            {
                Debug.WriteLine("All Result files are here and under 3 hours old.");
            }


        }
        private static bool IsFileOver3HoursOld(string filename, int hours = 3)
        {
            var threshold = DateTime.Now.AddHours(-hours);
            return File.GetLastWriteTime(filename) <= threshold;
        }
    }
}
