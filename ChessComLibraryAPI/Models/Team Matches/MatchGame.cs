using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class MatchGame
    {
        /// <summary>
        /// Details of the white-piece player
        /// </summary>
        public TeamPlayer White { get; set; }

        /// <summary>
        /// Details of the black-piece player
        /// </summary>
        public TeamPlayer Black { get; set; }

        /// <summary>
        /// URL of this game
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Current fen
        /// </summary>
        public string FEN { get; set; }

        /// <summary>
        /// Final PGN, if game's finished
        /// </summary>
        public string PGN { get; set; }

        /// <summary>
        /// Timestamp of the game start (Daily Chess only)
        /// </summary>
        public int startTime { get; set; }

        /// <summary>
        /// Timestamp of the game end, if game's finished
        /// </summary>
        public int endTime { get; set; }

        /// <summary>
        /// PGN-compliant time control
        /// </summary>
        public string TimeControl { get; set; }

        /// <summary>
        /// Time-per-move grouping, used for ratings
        /// </summary>
        public string TimeClass { get; set; }

        /// <summary>
        /// Game variant information (e.g., "chess960")
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// URL pointing to ECO opening (if available)
        /// </summary>
        public string Eco { get; set; }

        /// <summary>
        /// URL pointing to team match (if available)
        /// </summary>
        public string Match { get; set; }
    }
}
