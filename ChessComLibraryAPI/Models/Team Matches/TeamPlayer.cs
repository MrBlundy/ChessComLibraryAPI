using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class TeamPlayer
    {
        /// <summary>
        /// Chess.com Username
        /// </summary>
        [JsonProperty("username")] public string Username { get; set; }

        /// <summary>
        /// Url of board
        /// </summary>
        [JsonProperty("board")] public string Board { get; set; }

        /// <summary>
        /// Rating of player
        /// </summary>
        [JsonProperty("rating")] public int Rating { get; set; }

        /// <summary>
        /// Glicko RD
        /// </summary>
        [JsonProperty("rd")] public float RD { get; set; }

        /// <summary>
        /// Timeout percentage in the last 90 days
        /// </summary>
        [JsonProperty("timeout_percentage")] public float TimeoutPercentage { get; set; }

        /// <summary>
        /// Status of the account. basic/premium/closed/fairplay/staff
        /// </summary>
        [JsonProperty("status")] public string Status { get; set; }

        /// <summary>
        /// Url to player's stats
        /// </summary>
        [JsonProperty("stats")] public string Stats { get; set; }

        /// <summary>
        /// Result {win, lose, resign, etc.} of player when played as white (if game's finished)
        /// </summary>
        [JsonProperty("played_as_white")] public string PlayedAsWhite { get; set; }

        /// <summary>
        /// Result {win, lose, resign, etc.} of player when played as black (if game's finished)
        /// </summary>
        [JsonProperty("played_as_black")] public string PlayedAsBlack { get; set; }

        /// <summary>
        /// URL of this player's profile
        /// </summary>
        [JsonProperty("id")] public string ID { get; set; }

        /// <summary>
        /// URL to club's profile
        /// </summary>
        [JsonProperty("team")] public string Team { get; set; }

    }
}
