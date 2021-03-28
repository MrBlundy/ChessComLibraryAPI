using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    public class ClubMember
    {
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("joined")] public int joinedDate { get; set; }
        public DateTime JoinedDate { get { return DateTimeOffset.FromUnixTimeSeconds(joinedDate).DateTime; } }
    }
}
