using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    /// <summary>
    ///  Get details about a team match and players playing that match.
    ///  After the match is finished there will be a link to each player's stats endpoint,
    ///  in order to get up-to-date information about the player
    /// </summary>
    public class TeamMatch
    {
        [JsonProperty("@id")] public string ID { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// The URL of the match on the website
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        /// <summary>
        /// Manual or Auto time start
        /// </summary>
        [JsonProperty("start_time")] public int startTime { get; set; }

        /// <summary>
        /// registration
        /// </summary>
        [JsonProperty("status")] public string Status { get; set; }

        /// <summary>
        /// Number of boards
        /// </summary>
        [JsonProperty("boards")] public int Boards { get; set; }

        [JsonProperty("settings")] public MatchSetting Settings { get; set; }

        [JsonProperty("teams")] public Teams Teams { get; set; }
    }
}
