using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class Teams
    {

        [JsonProperty("team1")] public Team Team1 { get; set; }

        [JsonProperty("team2")] public Team Team2 { get; set; }

    }
}
