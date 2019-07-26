using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Misc
{
    /// <summary>
    /// Class representing a item/player of a Leaderboard
    /// </summary>
    public class LeaderboardPlayer
    {
        /// <summary>
        /// ID of the player
        /// </summary>
        [JsonProperty("player_id")] public int PlayerID { get; set; }

        /// <summary>
        /// Url of player's profile
        /// </summary>
        [JsonProperty("url")] public string ProfileUrl { get; set; }

        /// <summary>
        /// Username of player
        /// </summary>
        [JsonProperty("username")] public string Username { get; set; }

        /// <summary>
        /// Rating Score
        /// </summary>
        [JsonProperty("score")] public int Score { get; set; }

        /// <summary>
        /// Leaderboard Rank
        /// </summary>
        [JsonProperty("rank")] public int Rank { get; set; }
    }
}
