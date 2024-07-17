using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaPick
{
    public class DrawResults
    {
        private readonly string lottoHistoryPath = "data\\lotto-history.csv";
        private readonly string thunderballistoryPath = "data\\thunderball-history.csv";
        private readonly string euromillionHistoryPath = "data\\euromillion-history.csv";
        private readonly string setforlifeHistoryPath = "data\\setforlife-history.csv";
        private readonly string baseURL = "https://www.national-lottery.co.uk/results/";
        public List<LottoResult>? LottoResults { get; set; }
        public List<ThunderBallResult>? ThunderBallResults { get; set; }
        public List<EuroMillionsResult>? EuroMillionsResults { get; set; }
        public List<SetForLifeResult>? SetForLifeResults { get; set; }

        public DrawResults()
        {
            _ = InitializeAsync();
            LottoResults = DrawHistoryUtils.CSV2LottoResultsList(lottoHistoryPath);
            ThunderBallResults = DrawHistoryUtils.CSV2ThunderBallResultsList(thunderballistoryPath);
            EuroMillionsResults = DrawHistoryUtils.CSV2EuroMillionsResultsList(euromillionHistoryPath);
            SetForLifeResults = DrawHistoryUtils.CSV2SetForLifeResultsList(setforlifeHistoryPath);
        }

        private async Task InitializeAsync()
        {
            if (!File.Exists(lottoHistoryPath) || IsFileOver3HoursOld(lottoHistoryPath))
            {
                await DrawHistoryUtils.DownloadCSV($"{baseURL}lotto/draw-history/csv", lottoHistoryPath);
            }
            if (!File.Exists(thunderballistoryPath) || IsFileOver3HoursOld(thunderballistoryPath))
            {
                await DrawHistoryUtils.DownloadCSV($"{baseURL}thunderball/draw-history/csv", thunderballistoryPath);
            }
            if (!File.Exists(euromillionHistoryPath) || IsFileOver3HoursOld(euromillionHistoryPath))
            {
                await DrawHistoryUtils.DownloadCSV($"{baseURL}euromillions/draw-history/csv", euromillionHistoryPath);
            }
            if (!File.Exists(setforlifeHistoryPath) || IsFileOver3HoursOld(setforlifeHistoryPath))
            {
                await DrawHistoryUtils.DownloadCSV($"{baseURL}set-for-life/draw-history/csv", setforlifeHistoryPath);
            }
        }
        private static bool IsFileOver3HoursOld(string filename, int hours = 3)
        {
            var threshold = DateTime.Now.AddHours(-hours);
            return File.GetLastWriteTime(filename) <= threshold;
        }
    }
}
