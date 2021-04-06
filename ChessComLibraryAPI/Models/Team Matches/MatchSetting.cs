using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class MatchSetting
    {
        /// <summary>
        /// Time-per-move grouping, used for ratings
        /// </summary>
        public string TimeClass { get; set; }

        /// <summary>
        /// PGN-compliant time control
        /// </summary>
        public string TimeControl { get; set; }


        public string InitialSetup { get; set; }

        /// <summary>
        /// Game variant information (e.g., "chess960")
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// Minimum number of players per team
        /// </summary>
        public int MinTeamPlayers { get; set; }

        /// <summary>
        /// Maximum number of players per team
        /// </summary>
        public int MaxTeamPlayers { get; set; }

        /// <summary>
        /// Minimum number of required games
        /// </summary>
        public int MinRequiredGames { get; set; }

        /// <summary>
        /// Minimum rating of players to be admitted in this match
        /// </summary>
        public int MinRating { get; set; }

        /// <summary>
        /// Maximum rating of players to be admitted in this match
        /// </summary>
        public int MaxRating { get; set; }

        /// <summary>
        /// If the match is set to automatically start
        /// </summary>
        public bool IsAutoStart { get; set; }

    }
}
