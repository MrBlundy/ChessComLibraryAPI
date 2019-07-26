using ChessComLibraryAPI.Utilities;
using Newtonsoft.Json;
using System;

namespace ChessComLibraryAPI.Models.Clubs
{
    /// <summary>
    /// Represents a Club on Chess.com
    /// </summary>
    public class Club
    {
        /// <summary>
        /// Club Name
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// Club Url
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; }
        
        /// <summary>
        /// Club Icon
        /// </summary>
        [JsonProperty("icon")] public string Icon { get; set; }
        
        /// <summary>
        /// Time Player joined Club
        /// </summary>
        [JsonProperty("joined")] public long joined { get; set; }
        
        /// <summary>
        /// Time Player's last activity
        /// </summary>
        [JsonProperty("last_activity")] public long lastactivity { get; set; }
        
        /// <summary>
        /// Converted(joined) -> DateTime Player joined Club
        /// </summary>
        public DateTime JoinedDate { get { return joined.FromUnixTime(); } }
        
        /// <summary>
        /// Converted(lastActivity) -> DateTime Player was last active
        /// </summary>
        public DateTime LastActivity { get { return lastactivity.FromUnixTime(); } }
    }
}
