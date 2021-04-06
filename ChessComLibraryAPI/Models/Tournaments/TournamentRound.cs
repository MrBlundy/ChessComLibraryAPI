using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    /// <summary>
    /// Description: Get details about a tournament's round.
    /// </summary>
    public class TournamentRound
    {
        /// <summary>
        /// List of tournament's round groups
        /// </summary>
        [JsonProperty("groups")] public string[] Groups { get; set; }

        /// <summary>
        /// List of tournament's round players
        /// </summary>
        [JsonProperty("players")] public TournamentPlayer[] Players { get; set; }

    }
}
