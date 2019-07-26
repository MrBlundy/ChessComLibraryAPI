using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Games
{
    /// <summary>
    /// Class used to represent an Archived Game on chess.com
    /// </summary>
    public class ArchivedGame : DailyGame
    {
        /// <summary>
        /// Overrides DailyGame.WhitePlayer, Contains Username/Rating/Result
        /// </summary>
        [JsonProperty("white")] public new GamePlayer WhitePlayer { get; set; }

        /// <summary>
        /// Overrides DailyGame.BlackPlayer, Contains Username/Rating/Result
        /// </summary>
        [JsonProperty("black")] public new GamePlayer BlackPlayer { get; set; }
    }
}
