using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    public class PuzzleRushRecord
    {
        [JsonProperty("total_attempts")] public int TotalAttempts { get; set; }
        [JsonProperty("score")] public int HighestScore { get; set; }
    }
}
