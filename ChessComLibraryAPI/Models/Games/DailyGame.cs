using ChessComLibraryAPI.Utilities;
using Newtonsoft.Json;
using System;

namespace ChessComLibraryAPI.Models.Games
{
    /// <summary>
    /// Class used to represent a daily game on chess.com
    /// </summary>
    public class DailyGame
    {
        /// <summary>
        /// Username who played as white
        /// </summary>
        [JsonProperty("white")] public virtual string WhitePlayer { get; set; }

        /// <summary>
        /// Username who played as black
        /// </summary>
        [JsonProperty("black")] public virtual string BlackPlayer { get; set; }

        /// <summary>
        /// Determines if game is rated
        /// </summary>
        [JsonProperty("rated")] public bool IsRatedGame { get; set; }

        /// <summary>
        /// Url of the game
        /// </summary>
        [JsonProperty("url")] public string GameUrl { get; set; }

        /// <summary>
        /// Current FEN of game
        /// </summary>
        [JsonProperty("fen")] public string CurrentFEN { get; set; }

        /// <summary>
        /// Current PGN of game
        /// </summary>
        [JsonProperty("pgn")] public string CurrentPGN { get; set; }

        /// <summary>
        /// Username of whos turn it is
        /// </summary>
        [JsonProperty("turn")] public string PlayerToMove { get; set; }
        
        /// <summary>
        /// unix time the player has to move by
        /// </summary>
        [JsonProperty("move_by")] public long moveBy { get; set; }

        /// <summary>
        /// Username of player(s) who offered draw
        /// </summary>
        [JsonProperty("draw_offer")] public string OfferedDraw { get; set; }

        /// <summary>
        /// Time player was last active on game
        /// </summary>
        [JsonProperty("last_activity")] public long lastActivity { get; set; }

        /// <summary>
        /// Time the game started
        /// </summary>
        [JsonProperty("start_time")] public long startTime { get; set; }

        /// <summary>
        /// Time the game ended
        /// </summary>
        [JsonProperty("end_time")] public long endTime { get; set; }

        /// <summary>
        /// Time Control eg, 1|0 1|1 3|0 3|2 etc
        /// </summary>
        [JsonProperty("time_control")] public string TimeControl { get; set; }

        /// <summary>
        /// Time format the game is in, Bullet/Blitz/Rapid
        /// </summary>
        [JsonProperty("time_class")] public string TimeClass { get; set; }

        /// <summary>
        /// Rules that get applied, 960/bughouse/kingofthehill
        /// </summary>
        [JsonProperty("rules")] public string Rules { get; set; }

        /// <summary>
        /// Url of the Tourament
        /// </summary>
        [JsonProperty("tournament")] public string TournamentUrl { get; set; }

        /// <summary>
        /// Url of the Team Match
        /// </summary>
        [JsonProperty("match")] public string TeamMatchUrl { get; set; }

        /// <summary>
        /// Converted(moveByDate) -> DateTime Player has to move by
        /// </summary>
        public DateTime MoveByDate { get { return moveBy.FromUnixTime(); } }

        /// <summary>
        /// Converted(lastActivity) -> DateTime Player was last active
        /// </summary>
        public DateTime LastActivity { get { return lastActivity.FromUnixTime(); } }

        /// <summary>
        /// Converted(startTime) -> DateTime the game started
        /// </summary>
        public DateTime GameStartTime { get { return startTime.FromUnixTime(); } }

        /// <summary>
        /// Converted(endTime) -> DateTime game ended
        /// </summary>
        public DateTime GameEndTime { get { return endTime.FromUnixTime(); } }
    }



    public class PgnGame
    {
        public string Date { get; set; }

        public string WhitePlayer { get; set; } // white username
        public string BlackPlayer { get; set; } // black username

        public int WhiteElo { get; set; } // white rating
        public int BlackElo { get; set; } // black rating

        public string GameResult { get; set; }  // result 0 = black won, 0.5 = draw, 1 = white won

        public string StartTime { get; set; } // time the game started
        public string EndTime { get; set; } // time the game ended

        public int MoveCount { get; set; } // how many moves were played

        public string TimeClass { get; set; } // time format - bullet/blitz/rapid
    }
}
