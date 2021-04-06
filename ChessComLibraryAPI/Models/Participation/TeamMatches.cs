using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Participation
{
    /// <summary>
    /// Represents all Club Matchs a Player has been apart of
    /// </summary>
    public class TeamMatches
    {
        /// <summary>
        /// Player's finished Club Matchs
        /// </summary>
        [JsonProperty("finished")] public TeamMatch[] FinishedMatches { get; set; }
        /// <summary>
        /// Player's in-progress Club Matchs
        /// </summary>
        [JsonProperty("in_progress")] public TeamMatch[] InProgressMatches { get; set; }
        /// <summary>
        /// Matchs Player has register for
        /// </summary>
        [JsonProperty("registered")] public TeamMatch[] RegisteredMatches { get; set; }
    }



}
