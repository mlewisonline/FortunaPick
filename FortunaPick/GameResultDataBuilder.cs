//using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.Json;
using System.Xml;


namespace FortunaPick
{
    public class GameResultDataBuilder
    {

        //    static List<LottoResult> jsonList = new();

        //    readonly static string lottoURL = "https://www.national-lottery.co.uk/results/lotto/draw-history/csv";
        //    readonly static string lottoFile = @"data\lotto-draw-history.csv";
        //    readonly static string thunderURL = "https://www.national-lottery.co.uk/results/thunderball/draw-history/csv";
        //    readonly static string thunderFile = @"data\thunder-draw-history.csv";
        //    readonly static string euroURL = "https://www.national-lottery.co.uk/results/euromillions/draw-history/csv";
        //    readonly static string euroFile = @"data\euro-draw-history.csv";
        //    readonly static string set4URL = "https://www.national-lottery.co.uk/results/set-for-life/draw-history/csv";
        //    readonly static string set4File = @"data\setforlife-draw-history.csv";


        //    private static void BuildResultsList(string filename, GameType game, List<LottoResults> jsonList)
        //    {

        //        var csvLines = File.ReadAllLines(filename);
        //        foreach (var line in csvLines[1..7])
        //        {

        //            var fields = line.Split(',');

        //            if (game == GameType.Lotto)
        //            {
        //                var obj = new LottoResults
        //                (
        //                   game.ToString(),
        //                   DateOnly.Parse(fields[0]),
        //                   fields[1],
        //                   fields[2],
        //                   fields[3],
        //                   fields[4],
        //                   fields[5],
        //                   fields[6],
        //                   fields[7]
        //                );
        //                jsonList.Add(obj);
        //            }
        //            else if (game == GameType.ThunderBall)
        //            {
        //                var obj = new ThunderBallResults
        //                (
        //                    game.ToString(),
        //                    DateOnly.Parse(fields[0]),
        //                    fields[1],
        //                    fields[2],
        //                    fields[3],
        //                    fields[4],
        //                    fields[5],
        //                    fields[6]
        //                );
        //                jsonList.Add(obj);
        //            }
        //            else if (game == GameType.EuroMillions)
        //            {
        //                int startIndex = line.IndexOf("\"") + 1;
        //                int endIndex = line.IndexOf("\"", startIndex);
        //                var obj = new EuroMillionsResults
        //                (
        //                    game.ToString(),
        //                    DateOnly.Parse(fields[0]),
        //                    fields[1],
        //                    fields[2],
        //                    fields[3],
        //                    fields[4],
        //                    fields[5],
        //                    fields[6],
        //                    fields[7],
        //                    line[startIndex..endIndex]
        //                );
        //                jsonList.Add(obj);
        //            }
        //            else if (game == GameType.SetForLife)
        //            {
        //                var obj = new SetforlifeResults
        //                (
        //                    game.ToString(),
        //                    DateOnly.Parse(fields[0]),
        //                    fields[1],
        //                    fields[2],
        //                    fields[3],
        //                    fields[4],
        //                    fields[5],
        //                    fields[6]
        //                );
        //                jsonList.Add(obj);
        //            }
        //        }
        //    }

        //    private static void WriteResultDataJsonFile<T>(List<T> jsonList)
        //    {

        //        var options = new JsonSerializerOptions
        //        {
        //            WriteIndented = true
        //        };
        //        //string json = JsonConvert.SerializeObject(jsonList, Newtonsoft.Json.Formatting.Indented);
        //        //string json = "";
        //        //foreach (var obj in jsonList)
        //        //{
        //        //     json +=$"{JsonSerializer.Serialize(obj, obj.GetType(), options)},\n";
        //        //}

        //        string json = JsonSerializer.Serialize(jsonList[0..6],options);
        //        File.WriteAllText(@"data\lotto-draw-results.json", json);
        //        json = JsonSerializer.Serialize(jsonList[6..12], options);
        //        File.WriteAllText(@"data\thunderball-draw-results.json", json);
        //        json = JsonSerializer.Serialize(jsonList[12..18], options);
        //        File.WriteAllText(@"data\euromillions-draw-results.json", json);
        //        json = JsonSerializer.Serialize(jsonList[18..], options);
        //        File.WriteAllText(@"data\setforlife-draw-results.json", json);
        //    }

        //private static bool IsFileOver3HoursOld(string filename, int hours = 3)
        //{
        //    var threshold = DateTime.Now.AddHours(-hours);
        //    return File.GetLastWriteTime(filename) <= threshold;
        //}

        //    public static async void GetOrUpdateResultsJson()
        //    {
        //        if (!File.Exists(lottoFile) || IsFileOver3HoursOld(lottoFile))
        //            await DownloadResultData(lottoURL, lottoFile);

        //        if (!File.Exists(thunderFile) || IsFileOver3HoursOld(thunderFile))
        //            await DownloadResultData(thunderURL, thunderFile);

        //        if (!File.Exists(euroFile) || IsFileOver3HoursOld(euroFile))
        //            await DownloadResultData(euroURL, euroFile);

        //        if (!File.Exists(set4File) || IsFileOver3HoursOld(set4File))
        //            await DownloadResultData(set4URL, set4File);


        //        BuildResultsList(lottoFile, GameType.Lotto, jsonList);
        //        BuildResultsList(thunderFile, GameType.ThunderBall, jsonList);
        //        BuildResultsList(euroFile, GameType.EuroMillions, jsonList);
        //        BuildResultsList(set4File, GameType.SetForLife, jsonList);

        //        WriteResultDataJsonFile(jsonList);
        //    }

    }
}
