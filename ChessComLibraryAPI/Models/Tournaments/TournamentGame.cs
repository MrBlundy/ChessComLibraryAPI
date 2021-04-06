using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Tournaments
{
    public class TournamentGame
    {
        /// <summary>
        /// URL of this game
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Current PGN
        /// </summary>
        public string Pgn { get; set; }

        /// <summary>
        /// Current FEN
        /// </summary>
        public string Fen { get; set; }

        /// <summary>
        /// PGN-compliant time control
        /// </summary>
        public string TimeControl { get; set; }

        /// <summary>
        /// Player to move
        /// </summary>
        public string Turn { get; set; }

        /// <summary>
        /// Timestamp of when the next move must be made
        /// This is "0" if the player-to-move is on vacation
        /// </summary>
        public int MoveBy { get; set; }

        /// <summary>
        /// (Optional) Player who has made a draw offer
        /// </summary>
        public string DrawOffer { get; set; }

        /// <summary>
        /// Timestamp of the last activity on the game
        /// </summary>
        public int LastActivity { get; set; }

        /// <summary>
        /// Timestamp of the game start (Daily Chess only)
        /// </summary>
        public int StartTime { get; set; }

        /// <summary>
        /// Time-per-move grouping, used for ratings
        /// </summary>
        public string TimeClass { get; set; }

        /// <summary>
        /// Game variant information (e.g., "chess960")
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// (If Available) URL pointing to ECO opening 
        /// </summary>
        public string Eco { get; set; }

        /// <summary>
        /// (If Available) URL pointing to tournament 
        /// </summary>
        public string Tournament { get; set; }

    }
}
