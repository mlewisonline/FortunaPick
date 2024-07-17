using System.Diagnostics;
using System.Text.Json;

namespace FortunaPick
{
    public class GameResultDataBuilder
    {
        HttpClient client = new();
        static List<IGameResults> jsonList = new();

        readonly static string lottoURL = "https://www.national-lottery.co.uk/results/lotto/draw-history/csv";
        readonly static string lottoFile = @"data\lotto-draw-history.csv";
        readonly static string thunderURL = "https://www.national-lottery.co.uk/results/thunderball/draw-history/csv";
        readonly static string thunderFile = @"data\thunder-draw-history.csv";
        readonly static string euroURL = "https://www.national-lottery.co.uk/results/euromillions/draw-history/csv";
        readonly static string euroFile = @"data\euro-draw-history.csv";
        readonly static string set4URL = "https://www.national-lottery.co.uk/results/set-for-life/draw-history/csv";
        readonly static string set4File = @"data\setforlife-draw-history.csv";
        private static async Task DownloadResultData(string url, string filename)
        {
            using var httpClient = new HttpClient();
            try
            {
                var responseStream = await httpClient.GetStreamAsync(url);

                // Write the content to a local file
                using var fileStream = new FileStream(filename, FileMode.Create);
                await responseStream.CopyToAsync(fileStream);

                Debug.WriteLine($"File downloaded and written successfully: {filename}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error downloading or writing the file: {ex.Message}");
            }
        }

        
        private static void BuildResultsList(string filename, GameType game, List<IGameResults> jsonList)
        {
            var csvLines = File.ReadAllLines(filename);
            foreach (var line in csvLines[1..7])
            {

                var fields = line.Split(',');

                if (game == GameType.Lotto)
                {
                    var obj = new LottoResults
                    (
                       game.ToString(),
                       DateOnly.Parse(fields[0]),
                       int.Parse(fields[1]),
                       int.Parse(fields[2]),
                       int.Parse(fields[3]),
                       int.Parse(fields[4]),
                       int.Parse(fields[5]),
                       int.Parse(fields[6]),
                       int.Parse(fields[7])
                    );
                    jsonList.Add(obj);
                }
                else if (game == GameType.ThunderBall)
                {
                    var obj = new ThunderBallResults
                    (
                        game.ToString(),
                        DateOnly.Parse(fields[0]),
                        int.Parse(fields[1]),
                        int.Parse(fields[2]),
                        int.Parse(fields[3]),
                        int.Parse(fields[4]),
                        int.Parse(fields[5]),
                        int.Parse(fields[6])
                    );
                    jsonList.Add(obj);
                }
                else if (game == GameType.EuroMillions)
                {
                    int startIndex = line.IndexOf("\"") + 1;
                    int endIndex = line.IndexOf("\"", startIndex);
                    var obj = new EuroMillionsResults
                    (
                        game.ToString(),
                        DateOnly.Parse(fields[0]),
                        int.Parse(fields[1]),
                        int.Parse(fields[2]),
                        int.Parse(fields[3]),
                        int.Parse(fields[4]),
                        int.Parse(fields[5]),
                        int.Parse(fields[6]),
                        int.Parse(fields[7]),
                        line[startIndex..endIndex]
                    );
                    jsonList.Add(obj);
                }
                else if (game == GameType.SetForLife)
                {
                    var obj = new SetforlifeResults
                    (
                        game.ToString(),
                        DateOnly.Parse(fields[0]),
                        int.Parse(fields[1]),
                        int.Parse(fields[2]),
                        int.Parse(fields[3]),
                        int.Parse(fields[4]),
                        int.Parse(fields[5]),
                        int.Parse(fields[6])
                    );
                    jsonList.Add(obj);
                }
            }
        }

        private static void WriteResultDataJsonFile(List<IGameResults> jsonList)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(jsonList, options);
            File.WriteAllText(@"data\draw-results.json", json);

        }

        private static bool IsFileOver3HoursOld(string filename, int hours = 3)
        {
            var threshold = DateTime.Now.AddHours(-hours);
            return File.GetLastWriteTime(filename) <= threshold;
        }

        public static async void GetOrUpdateResultsJson()
        {
            if (!File.Exists(lottoFile) || IsFileOver3HoursOld(lottoFile))
                await DownloadResultData(lottoURL, lottoFile);

            if (!File.Exists(thunderFile) || IsFileOver3HoursOld(thunderFile))
                await DownloadResultData(thunderURL, thunderFile);

            if (!File.Exists(euroFile) || IsFileOver3HoursOld(euroFile))
                await DownloadResultData(euroURL, euroFile);

            if (!File.Exists(set4File) || IsFileOver3HoursOld(set4File))
                await DownloadResultData(set4URL, set4File);

            
            BuildResultsList(lottoFile, GameType.Lotto, jsonList);
            BuildResultsList(thunderFile, GameType.ThunderBall, jsonList);
            BuildResultsList(euroFile, GameType.EuroMillions, jsonList);
            BuildResultsList(set4File, GameType.SetForLife, jsonList);

            WriteResultDataJsonFile(jsonList);
        }
    
    }
}
