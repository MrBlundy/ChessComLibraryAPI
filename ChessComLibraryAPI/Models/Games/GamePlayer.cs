using ChessComLibraryAPI.Converters;
using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Games
{
    /// <summary>
    /// Class used to represent a player of a game on chess.com
    /// </summary>
    public class GamePlayer
    {
        /// <summary>
        /// Rating of the player
        /// </summary>
        [JsonProperty("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Enum representing the result for the player of the game
        /// </summary>
        [JsonProperty("result")]
        [JsonConverter(typeof(GameResultConverter))]
        public GameResult GameResult { get; set; }

        /// <summary>
        /// Username of the player
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

    }
}
