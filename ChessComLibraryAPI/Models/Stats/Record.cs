using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessComLibraryAPI.Models.Stats
{
    /// <summary>
    /// Class used to represent a Record
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Win Count
        /// </summary>
        [JsonProperty("win")] public int Wins { get; set; }

        /// <summary>
        /// Loss Count
        /// </summary>
        [JsonProperty("loss")] public int Loses { get; set; }

        /// <summary>
        /// Draw Count
        /// </summary>
        [JsonProperty("draw")] public int Draws { get; set; }

        /// <summary>
        /// Average Time spent per move
        /// </summary>
        [JsonProperty("time_per_move")] public int TimePerMove { get; set; }

        /// <summary>
        /// Timeout Percentage
        /// </summary>
        [JsonProperty("timeout_percent")] public int TimeoutPercent { get; set; }
    }
}
