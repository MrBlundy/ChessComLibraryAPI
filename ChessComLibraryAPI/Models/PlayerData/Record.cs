﻿using Newtonsoft.Json;

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
        [JsonProperty("win")] public float Wins { get; set; }

        /// <summary>
        /// Loss Count
        /// </summary>
        [JsonProperty("loss")] public float Loses { get; set; }

        /// <summary>
        /// Draw Count
        /// </summary>
        [JsonProperty("draw")] public float Draws { get; set; }

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
