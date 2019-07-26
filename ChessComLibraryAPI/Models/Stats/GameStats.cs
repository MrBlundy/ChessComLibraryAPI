using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    /// <summary>
    /// Class used to represent the stats for a particular game
    /// </summary>
    public class GameStats
    {
        /// <summary>
        /// Current Stat
        /// </summary>
        [JsonProperty("last")] public Stat LastStat { get; set; }

        /// <summary>
        /// Best Stat
        /// </summary>
        [JsonProperty("best")] public Stat BestStat { get; set; }

        /// <summary>
        /// Record Stat
        /// </summary>
        [JsonProperty("record")] public Record RecordStat { get; set; }
    }
}
