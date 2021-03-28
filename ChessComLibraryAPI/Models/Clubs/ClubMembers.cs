using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Clubs
{
    public class ClubMembers
    {
        [JsonProperty("weekly")] public ClubMember[] Weekly { get; set; }
        [JsonProperty("monthly")] public ClubMember[] Monthly { get; set; }
        [JsonProperty("all_time")] public ClubMember[] AllTime { get; set; }


    }
}
