using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    public class TournamentPlayer
    {

        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("is_advancing")] public bool IsAdvancing { get; set; }

        public string Result { get; set; }

        public string ID { get; set; }

        public int Rating { get; set; }

        /// <summary>
        /// Points earned by player in this group adjuested in case of fair play recalculations
        /// </summary>
        public float Points { get; set; }

        /// <summary>
        /// Tie-break points by player earned in this group
        /// </summary>
        public int Tiebreak { get; set; }


    }

    public enum TournamentStatus
    {
        Eliminated,
        Removed,
        Withdrew
    }
}
