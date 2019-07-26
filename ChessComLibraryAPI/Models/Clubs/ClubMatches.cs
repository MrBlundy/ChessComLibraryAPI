using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    /// <summary>
    /// Represents all Club Matchs a Player has been apart of
    /// </summary>
    public class ClubMatches
    {
        /// <summary>
        /// Player's finished Club Matchs
        /// </summary>
        [JsonProperty("finished")] public ClubMatch[] FinishedMatchs { get; set; }
        /// <summary>
        /// Player's in-progress Club Matchs
        /// </summary>
        [JsonProperty("in_progress")] public ClubMatch[] InProgressMatchs { get; set; }
        /// <summary>
        /// Matchs Player has register for
        /// </summary>
        [JsonProperty("registered")] public ClubMatch[] RegisteredMatchs { get; set; }
    }



}
