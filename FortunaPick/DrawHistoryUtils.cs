using System.Diagnostics;
using System.Text.Json;

namespace FortunaPick
{
    internal class DrawHistoryUtils
    {
        public static async Task DownloadCSV(string url, string filename)
        {
            using var httpClient = new HttpClient();
            try
            {
                var responseStream = await httpClient.GetStreamAsync(url);

                using var fileStream = new FileStream(filename, FileMode.Create);
                await responseStream.CopyToAsync(fileStream);

                Debug.WriteLine($"File downloaded and written successfully: {filename}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error downloading or writing the file: {ex.Message}");
            }
        }


        public static List<LottoResult> CSV2LottoResultsList(string filename)
        {
            List<LottoResult> list = [];
            var csvLines = File.ReadAllLines(filename);
            foreach (var line in csvLines[1..7])
            {
                var fields = line.Split(separator: ',');
                    var obj = new LottoResult
                    (
                       GameType.Lotto.ToString(),
                       DateOnly.Parse(fields[0]),
                       int.Parse(fields[1]),
                       int.Parse(fields[2]),
                       int.Parse(fields[3]),
                       int.Parse(fields[4]),
                       int.Parse(fields[5]),
                       int.Parse(fields[6]),
                       int.Parse(fields[7])
                    );
                list.Add(obj);
            }
            return list;
        }

        public static List<ThunderBallResult> CSV2ThunderBallResultsList(string filename)
        {
            List<ThunderBallResult> list = [];
            var csvLines = File.ReadAllLines(filename);
            foreach (var line in csvLines[1..7])
            {
                var fields = line.Split(separator: ',');
                var obj = new ThunderBallResult
                (
                   GameType.ThunderBall.ToString(),
                   DateOnly.Parse(fields[0]),
                   int.Parse(fields[1]),
                   int.Parse(fields[2]),
                   int.Parse(fields[3]),
                   int.Parse(fields[4]),
                   int.Parse(fields[5]),
                   int.Parse(fields[6])
                );
                list.Add(obj);
            }
            return list;
        }

        public static List<EuroMillionsResult> CSV2EuroMillionsResultsList(string filename)
        {
            List<EuroMillionsResult> list = [];
            var csvLines = File.ReadAllLines(filename);
            foreach (var line in csvLines[1..7])
            {
                var fields = line.Split(separator: ',');
                int startIndex = line.IndexOf("\"") + 1;
                int endIndex = line.IndexOf("\"", startIndex);
                var obj = new EuroMillionsResult
                (
                   GameType.EuroMillions.ToString(),
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
                list.Add(obj);
            }
            return list;
        }

        public static List<SetForLifeResult> CSV2SetForLifeResultsList(string filename)
        {
            List<SetForLifeResult> list = [];
            var csvLines = File.ReadAllLines(filename);
            foreach (var line in csvLines[1..7])
            {
                var fields = line.Split(separator: ',');
                var obj = new SetForLifeResult
                (
                   GameType.SetForLife.ToString(),
                   DateOnly.Parse(fields[0]),
                   int.Parse(fields[1]),
                   int.Parse(fields[2]),
                   int.Parse(fields[3]),
                   int.Parse(fields[4]),
                   int.Parse(fields[5]),
                   int.Parse(fields[6])
                );
                list.Add(obj);
            }
            return list;
        }

        public static void WriteList2JSON<T>(string filename, List<T> list)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json =JsonSerializer.Serialize(list,options);
            File.WriteAllText(filename,json);
        }
    
    }
}
