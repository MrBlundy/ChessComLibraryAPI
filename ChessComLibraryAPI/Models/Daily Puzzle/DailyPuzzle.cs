using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Misc
{
    /// <summary>
    /// Class representing a Daily Puzzle
    /// </summary>
    public class DailyPuzzle
    {
        /// <summary>
        /// Title of the puzzle
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; }

        /// <summary>
        /// Url of the Puzzle
        /// </summary>
        [JsonProperty("url")] public string PuzzleUrl { get; set; }

        /// <summary>
        /// Time puzzle was published
        /// </summary>
        [JsonProperty("publish_time")] public long PublishedTime { get; set; }

        /// <summary>
        /// Puzzle FEN
        /// </summary>
        [JsonProperty("fen")] public string FEN { get; set; }

        /// <summary>
        /// Puzzle PGN
        /// </summary>
        [JsonProperty("pgn")] public string PGN { get; set; }

        /// <summary>
        /// Url of Puzzle Image
        /// </summary>
        [JsonProperty("image")] public string ImageUrl { get; set; }
    }
}
