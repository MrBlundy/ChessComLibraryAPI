using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Misc
{
    /// <summary>
    /// Class representing Chess.com Leaderboards
    /// </summary>
    public class Leaderboard
    {
        /// <summary>
        /// Daily Leaderboard
        /// </summary>
        [JsonProperty("daily")] public LeaderboardPlayer[] Daily { get; set; }

        /// <summary>
        /// Daily 960 Leaderboard
        /// </summary>
        [JsonProperty("daily960")] public LeaderboardPlayer[] Daily960 { get; set; }

        /// <summary>
        /// Rapid Leaderboard
        /// </summary>
        [JsonProperty("live_rapid")] public LeaderboardPlayer[] Rapid { get; set; }

        /// <summary>
        /// Blitz Leaderboard
        /// </summary>
        [JsonProperty("live_blitz")] public LeaderboardPlayer[] Blitz { get; set; }

        /// <summary>
        /// Bullet Leaderboard
        /// </summary>
        [JsonProperty("live_bullet")] public LeaderboardPlayer[] Bullet { get; set; }

        /// <summary>
        /// Bughouse Leaderboard
        /// </summary>
        [JsonProperty("live_bughouse")] public LeaderboardPlayer[] Bughouse { get; set; }

        /// <summary>
        /// Blitz 960 Leaderboard
        /// </summary>
        [JsonProperty("live_blitz960")] public LeaderboardPlayer[] Blitz960 { get; set; }

        /// <summary>
        /// 3 Check Leaderboard
        /// </summary>
        [JsonProperty("live_threecheck")] public LeaderboardPlayer[] ThreeCheck { get; set; }

        /// <summary>
        /// Crazyhouse Leaderboard
        /// </summary>
        [JsonProperty("live_crazyhouse")] public LeaderboardPlayer[] Crazyhouse { get; set; }

        /// <summary>
        /// King of the Hill Leaderboard
        /// </summary>
        [JsonProperty("live_kingofthehill")] public LeaderboardPlayer[] KingOfTheHill { get; set; }

        /// <summary>
        /// Lessons Leaderboard
        /// </summary>
        [JsonProperty("lessons")] public LeaderboardPlayer[] Lessons { get; set; }

        /// <summary>
        /// Tactics Leaderboard
        /// </summary>
        [JsonProperty("tactics")] public LeaderboardPlayer[] Tactics { get; set; }
    }
}
