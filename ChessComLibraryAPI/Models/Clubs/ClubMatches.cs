﻿using System;
using Newtonsoft.Json;


namespace ChessComLibraryAPI.Models.Clubs
{
    public class ClubMatches
    {

        [JsonProperty("finished")] public ClubMatch[] Finished { get; set; }

        [JsonProperty("in_progress")] public ClubMatch[] InProgress { get; set; }

        [JsonProperty("registered")] public ClubMatch[] Registered { get; set; }

    }

    public class ClubMatch
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Url { get; set; }

        [JsonProperty("opponent")] public string Opponent { get; set; }

        [JsonProperty("start_time")] public int startTime { get; set; }

        public DateTime StartTime { get { return DateTimeOffset.FromUnixTimeSeconds(startTime).DateTime; } }

        [JsonProperty("time_class")] public string Variant { get; set; }

        [JsonProperty("result")] public string Result { get; set; }
    }
}
