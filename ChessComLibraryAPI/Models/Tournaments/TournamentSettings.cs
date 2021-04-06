using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    public class TournamentSettings
    {

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("rules")] public string Rules { get; set; }

        [JsonProperty("time_class")] public string TimeClass { get; set; }

        [JsonProperty("time_control")] public string TimeControl { get; set; }

        [JsonProperty("is_rated")] public bool IsRated { get; set; }

        [JsonProperty("is_official")] public bool IsOfficial { get; set; }

        [JsonProperty("is_invite_only")] public bool IsInviteOnly { get; set; }

        [JsonProperty("initial_group_size")] public int InitialGroupSize { get; set; }

        [JsonProperty("user_advance_count")] public int UserAdvanceCount { get; set; }

        [JsonProperty("use_tiebreak")] public bool UseTiebreak { get; set; }

        [JsonProperty("allow_vacation")] public bool AllowVacation { get; set; }

        [JsonProperty("winner_places")] public int WinnerPlaces { get; set; }

        [JsonProperty("registered_user_count")] public int RegisteredUserCount { get; set; }

        [JsonProperty("games_per_opponent")] public int GamesPerOpponent { get; set; }

        [JsonProperty("total_rounds")] public int TotalRounds { get; set; }

        [JsonProperty("concurrent_games_per_opponent")] public int ConcurrentGamesPerOpponent { get; set; }


    }
}
