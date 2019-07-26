using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    /// <summary>
    /// Class used to represent Highest/Lowest Stat
    /// </summary>
    public class HiLowStats
    {
        /// <summary>
        /// Highest Stat
        /// </summary>
        [JsonProperty("highest")] public Stat HighestStat { get; set; }

        /// <summary>
        /// Lowest Stat
        /// </summary>
        [JsonProperty("lowest")] public Stat LowestStat { get; set; }
    }
}
