using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    /// <summary>
    /// Represents a single game
    /// </summary>
    public class ClubMatch
    {
        /// <summary>
        /// Name of the Match
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }
        /// <summary>
        /// Url of Match
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }
        /// <summary>
        /// The Club the Match belonged too
        /// </summary>
        [JsonProperty("club")] public string Club { get; set; }
        /// <summary>
        /// Results of the Match
        /// </summary>
        [JsonProperty("results")] public MatchResult Results { get; set; }
        /// <summary>
        /// Url of the board
        /// </summary>
        [JsonProperty("board")] public string BoardUrl { get; set; }
    }
}
