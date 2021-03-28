using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    /// <summary>
    /// Represents the results of a Match
    /// </summary>
    public class MatchResult
    {
        /// <summary>
        /// Player who played as white
        /// </summary>
        [JsonProperty("played_as_white")] public string PlayedAsWhite { get; set; }
        /// <summary>
        /// Player who played as black
        /// </summary>
        [JsonProperty("played_as_black")] public string PlayedAsBlack { get; set; }

    }
}
