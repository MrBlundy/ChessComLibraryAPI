using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    public class PuzzleRushStat
    {
        [JsonProperty("best")] public PuzzleRushRecord BestStatsPR { get; set; }
    }
}
