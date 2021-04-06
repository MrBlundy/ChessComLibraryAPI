using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class Team
    {
        /// <summary>
        /// API URL for the club profile
        /// </summary>
        [JsonProperty("@id")] public string ID { get; set; }

        /// <summary>
        /// WEB URL for the club profile
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }

        /// <summary>
        /// Name for the club profile
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// Team score (adjuested in case of fair play recalculations)
        /// </summary>
        [JsonProperty("score")] public float Score { get; set; }

        /// <summary>
        /// Team Players
        /// </summary>
        [JsonProperty("players")] public TeamPlayer[] Players { get; set; }

    }
}
