using ChessComLibraryAPI.Utilities;
using Newtonsoft.Json;
using System;

namespace ChessComLibraryAPI.Models.Misc
{
    /// <summary>
    /// Represents a players profile
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Username of the account
        /// </summary>
        [JsonProperty("username")] public string Username { get; set; }
        
        /// <summary>
        /// Player ID of the account, this never changes
        /// </summary>
        [JsonProperty("player_id")] public int PlayerID { get; set; }

        /// <summary>
        /// Status of the account : basic/premium/fair_play_violation/staff
        /// </summary>
        [JsonProperty("status")] public string Status { get; set; }

        /// <summary>
        /// Player's Title: GM/WGM/IM/WIM/etc
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; }

        /// <summary>
        /// Player's First and Last Name
        /// </summary>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// Url of Player's Avatar
        /// </summary>
        [JsonProperty("avatar")] public string Avatar { get; set; }

        /// <summary>
        /// Player's Location
        /// </summary>
        [JsonProperty("location")] public string Location { get; set; }

        /// <summary>
        /// Player's Country
        /// </summary>
        [JsonProperty("country")] public string Country { get; set; }

        /// <summary>
        /// Is a Twitch Streamer
        /// </summary>
        [JsonProperty("is_streamer")] public bool IsStreamer { get; set; }

        /// <summary>
        /// Url of Twitch Stream if Streamer
        /// </summary>
        [JsonProperty("twitch_url")] public string TwitchURL { get; set; }

        /// <summary>
        /// Amount of Chess.com Followers
        /// </summary>
        [JsonProperty("followers")] public int FollowersCount { get; set; }

        /// <summary>
        /// Time Player Joined
        /// </summary>
        [JsonProperty("joined")] public long joinedDate { get; set; }

        /// <summary>
        /// Converted(joinedDate) -> DateTime Player Joined
        /// </summary>
        public DateTime JoinedDate { get { return joinedDate.FromUnixTime(); } }

        /// <summary>
        /// Last time Player was Online
        /// </summary>
        [JsonProperty("last_online")] public long lastOnline { get; set; }

        /// <summary>
        /// Converted(lastOnline) -> DateTime Player last online
        /// </summary>
        public DateTime LastOnline { get { return lastOnline.FromUnixTime(); } }

    }
}
