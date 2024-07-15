using System.Text.Json.Serialization;

namespace FortunaPick
{
    public class BallStatisticsModel
    {

        [JsonPropertyName("data_set")]
        public string? Dataset { get; set; }

        [JsonPropertyName("data_updated")]
        public string? DataUpdated { get; set; }


        [JsonPropertyName("lotto_main_balls")]
        public Dictionary<int, int>? LottoMainBalls { get; set; }
        public Dictionary<int, int>? LottoMainBallsSorted { get; set; }
        public Dictionary<int, int>? LottoHotSix { get; set; }
        public Dictionary<int, int>? LottoColdSix { get; set; }


        [JsonPropertyName("thunderball_main_balls")]
        public Dictionary<int, int>? ThunderballMainBalls { get; set; }
        public Dictionary<int, int>? ThunderballMainBallsSorted { get; set; }
        public Dictionary<int, int>? ThunderballMainHotSix { get; set; }
        public Dictionary<int, int>? ThunderballMainColdSix { get; set; }


        [JsonPropertyName("thunderballs")]
        public Dictionary<int, int>? Thunderballs { get; set; }
        public Dictionary<int, int>? ThunderballsSorted { get; set; }
        public Dictionary<int, int>? ThunderballsHotSix { get; set; }
        public Dictionary<int, int>? ThunderballsColdSix { get; set; }


        [JsonPropertyName("euromillion_main_balls")]
        public Dictionary<int, int>? EuromillionsMainBalls { get; set; }
        public Dictionary<int, int>? EuromillionsMainBallsSorted { get; set; }
        public Dictionary<int, int>? EuromillionsMainHotSix { get; set; }
        public Dictionary<int, int>? EuromillionsMainColdSix { get; set; }


        [JsonPropertyName("stars")]
        public Dictionary<int, int>? EuromillionsStars { get; set; }
        public Dictionary<int, int>? EuromillionsStarsSorted { get; set; }
        public Dictionary<int, int>? EuromillionsStarsHotSix { get; set; }
        public Dictionary<int, int>? EuromillionsStarsColdSix { get; set; }


        [JsonPropertyName("setforlife_main_balls")]
        public Dictionary<int, int>? SetforlifeMainBalls { get; set; }
        public Dictionary<int, int>? SetforlifeMainBallsSorted { get; set; }
        public Dictionary<int, int>? SetforlifeMainHotSix { get; set; }
        public Dictionary<int, int>? SetforlifeMainColdSix { get; set; }


        [JsonPropertyName("lifeballs")]
        public Dictionary<int, int>? SetforlifeLifeballs { get; set; }
        public Dictionary<int, int>? SetforlifeLifeballsSorted { get; set; }
        public Dictionary<int, int>? SetforlifeLifeballsHotSix { get; set; }
        public Dictionary<int, int>? SetforlifeLifeballsColdSix { get; set; }
    }

}
