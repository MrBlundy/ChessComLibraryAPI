using Newtonsoft.Json;

namespace ChessComLibraryAPI.Model.Stats
{
    public class Stat
    {
        [JsonProperty("rating")] public int Rating { get; set; }
        [JsonProperty("date")] public long Date { get; set; }
        [JsonProperty("rd")] public int RD { get; set; }
        [JsonProperty("game")] public string GameURL { get; set; }
    }

}
