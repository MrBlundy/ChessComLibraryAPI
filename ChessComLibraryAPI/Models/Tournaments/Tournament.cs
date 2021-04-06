using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    /// <summary>
    /// Get details about a daily, live and arena tournament.
    /// </summary>
    public class Tournament
    {
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// Url to Web tournament's URL
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        /// <summary>
        /// Username of creator
        /// </summary>
        [JsonProperty("creator")] public string Creator { get; set; }

        /// <summary>
        /// Status of tournament (finished, in_progress, registration)
        /// </summary>
        [JsonProperty("status")] public string Status { get; set; }

        /// <summary>
        /// Timestamp of finish time, if tournament is finished
        /// </summary>
        [JsonProperty("finish_time")] public int finishTime { get; set; }

        [JsonProperty("settings")] public TournamentSettings Settings { get; set; }

        /// <summary>
        /// List of tournament's rounds players
        /// </summary>
        [JsonProperty("players")] public TournamentPlayer[] Players { get; set; }

        /// <summary>
        /// List of tournament's rounds URL
        /// </summary>
        [JsonProperty("rounds")] public string[] Rounds { get; set; }
    }
}
