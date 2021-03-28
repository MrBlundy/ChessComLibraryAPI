using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Misc
{
    /// <summary>
    /// Class to represent a streamer
    /// </summary>
    public class Streamer
    {
        /// <summary>
        /// Username of streamer
        /// </summary>
        [JsonProperty("username")] public string Username { get; set; }

        /// <summary>
        /// Avatar of Streamer
        /// </summary>
        [JsonProperty("avatar")] public string AvatarUrl { get; set; }

        /// <summary>
        /// Twitch Url of Streamer
        /// </summary>
        [JsonProperty("twitch_url")] public string TwitchUrl { get; set; }

        /// <summary>
        /// Chess.com Profile Url of Streamer
        /// </summary>
        [JsonProperty("url")] public string ProfileUrl { get; set; }

        /// <summary>
        /// Is Streamer currently live
        /// </summary>
        [JsonProperty("is_live")] public bool IsLive { get; set; }
    }
}
