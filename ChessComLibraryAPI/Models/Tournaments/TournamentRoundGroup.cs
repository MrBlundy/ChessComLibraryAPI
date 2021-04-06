using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    /// <summary>
    /// Get details about a tournament's round group.
    /// </summary>
    public class TournamentRoundGroup
    {
        /// <summary>
        /// List of username accounts closed for fair play violation
        /// </summary>
        [JsonProperty("fair_play_removals")] public string[] FairPlayRemovals { get; set; }

        /// <summary>
        /// List of group's games
        /// </summary>
        [JsonProperty("games")] public TournamentGame[] Games { get; set; }

        /// <summary>
        /// List of group's players
        /// </summary>
        [JsonProperty("players")] public TournamentPlayer[] Players { get; set; }


    }
}
