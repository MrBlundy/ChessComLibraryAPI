using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Stats
{
    /// <summary>
    /// Class used to represent the stats in a player's profile
    /// </summary>
    public class ProfileStats
    {
        /// <summary>
        ///Bullet Game Stats
        /// </summary>
        [JsonProperty("chess_bullet")] public GameStats ChessBullet { get; set; }
        /// <summary>
        /// Daily Game Stats
        /// </summary>
        [JsonProperty("chess_daily")] public GameStats ChessDaily { get; set; }

        /// <summary>
        /// Daily 960 Game Stats
        /// </summary>
        [JsonProperty("chess960_daily")] public GameStats Chess960Daily { get; set; }

        /// <summary>
        /// Blitz Game Stats
        /// </summary>
        [JsonProperty("chess_blitz")] public GameStats ChessBlitz { get; set; }

        /// <summary>
        /// Rapid Game Stats
        /// </summary>
        [JsonProperty("chess_rapid")] public GameStats ChessRapid { get; set; }

        /// <summary>
        /// Puzzle Rush Stats
        /// </summary>
        [JsonProperty("puzzle_rush")] public PuzzleRushStat PuzzleRush { get; set; }

        /// <summary>
        /// Tactics Stats
        /// </summary>
        [JsonProperty("tactics")] public HiLowStats Tactics { get; set; }

        /// <summary>
        /// Lessons Stats
        /// </summary>
        [JsonProperty("lessons")] public HiLowStats Lessons { get; set; }
    }
}
