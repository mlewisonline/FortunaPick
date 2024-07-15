using System.Text.Json.Serialization;

namespace FortunaPick
{
    public class GameStats
    {
        [JsonPropertyName("gametype")]
        public string? Gametype { get; set; }

        [JsonPropertyName("last_updated")]
        public string? LastUpdated { get; set; }

        public Dictionary<int, int>? MainballsSorted { get; set; }

        public Dictionary<int, int>? MainBallHotSix { get; set; }

        public Dictionary<int, int>? MainBallColdSix { get; set; }

    }

    public class Lotto : GameStats
    {
        [JsonPropertyName("main_balls")]
        public Dictionary<int, int>? Mainballs { get; set; }

    }

    public class ThunderBall : GameStats
    {
        [JsonPropertyName("main_balls")]
        public Dictionary<int, int>? Mainballs { get; set; }

        [JsonPropertyName("thunderball")]
        public Dictionary<int, int>? Thunderball { get; set; }

        public Dictionary<int, int>? ThunderballSorted { get; set; }

        public Dictionary<int, int>? ThunderballHotSix { get; set; }

        public Dictionary<int, int>? ThunderballColdSix { get; set; }
    }

    public class EuroMillions : GameStats
    {
        [JsonPropertyName("main_balls")]
        public Dictionary<int, int>? Mainballs { get; set; }

        [JsonPropertyName("stars")]
        public Dictionary<int, int>? Stars { get; set; }

        public Dictionary<int, int>? StarsSorted { get; set; }

        public Dictionary<int, int>? StarsHotSix { get; set; }

        public Dictionary<int, int>? StarsColdSix { get; set; }
    }

    public class SetForLife : GameStats
    {
        [JsonPropertyName("main_balls")]
        public Dictionary<int, int>? Mainballs { get; set; }

        [JsonPropertyName("lifeball")]
        public Dictionary<int, int>? Lifeball { get; set; }

        public Dictionary<int, int>? LifeballSorted { get; set; }

        public Dictionary<int, int>? LifeballHotSix { get; set; }

        public Dictionary<int, int>? LifeballColdSix { get; set; }
    }

}
