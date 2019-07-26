using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    public class TournamentStats
    {
        [JsonProperty("count")] public int TournamentCount { get; set; }
        [JsonProperty("withdraw")] public int TournamentWithdraws { get; set; }
        [JsonProperty("points")] public int TournamentPoints { get; set; }
        [JsonProperty("highest_finish")] public int HighestFinish { get; set; }
    }
}
