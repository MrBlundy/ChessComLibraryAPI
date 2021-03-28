using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    public class ClubProfile
    {
        // the location of this profile (always self-referencing)
        [JsonProperty("id")] public string ClubURL { get; set; }

        // the human-readable name of this club
        [JsonProperty("name")] public string Name { get; set; }

        // the non-changing Chess.com ID of this club
        [JsonProperty("club_id")] public int ID { get; set; }

        // (optional) URL of a 200x200 image
        [JsonProperty("icon")] public string Icon { get; set; }

        // location of this club's country profile
        [JsonProperty("country")] public string Country { get; set; }

        //average daily rating
        [JsonProperty("average_daily_rating")] public int AverageDailyRating { get; set; }

        //total members count
        [JsonProperty("members_count")] public int MembersCount { get; set; }

        // timestamp of creation on Chess.com
        [JsonProperty("created")] public int Created { get; set; }

        // timestamp of the most recent post, match, etc
        [JsonProperty("last_activity")] public int LastActivity { get; set; }

        // whether the club is public or private
        [JsonProperty("visibility")] public string Visibility { get; set; }

        // location to submit a request to join this club
        [JsonProperty("join_request")] public string JoinRequest { get; set; }

        // array of URLs to the player profiles for the admins of this club
        [JsonProperty("admin")] public string[] Admins { get; set; }

        // text description of the club
        [JsonProperty("description")] public string Description { get; set; }

    }
}
