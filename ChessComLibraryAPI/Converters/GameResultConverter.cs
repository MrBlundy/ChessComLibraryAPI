using ChessComLibraryAPI.Models.Games;
using Newtonsoft.Json;
using System;

namespace ChessComLibraryAPI.Converters
{
    public class GameResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            switch (value)
            {
                case "win":
                    return GameResult.Win;
                case "checkmated":
                    return GameResult.Checkmated;
                case "agreed":
                    return GameResult.Agreed;
                case "repetition":
                    return GameResult.Repetition;
                case "timeout":
                    return GameResult.Timeout;
                case "resigned":
                    return GameResult.Resigned;
                case "stalemate":
                    return GameResult.Stalemate;
                case "lose":
                    return GameResult.Lose;
                case "insufficient":
                    return GameResult.Insufficient;
                case "50move":
                    return GameResult.FiftyMove;
                case "abandoned":
                    return GameResult.Abandoned;
                case "kingofthehill":
                    return GameResult.KingOfTheHill;
                case "threecheck":
                    return GameResult.ThreeCheck;
                case "timevsinsufficient":
                    return GameResult.TimeVsInsufficient;
                case "bughousepartnerlose":
                    return GameResult.BughousePartnerLose;

                default:
                    return GameResult.UNKNOWN;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            GameResult result = (GameResult)value;

            switch (result)
            {
                case GameResult.Win:
                    writer.WriteValue("win");
                    break;
                case GameResult.Checkmated:
                    writer.WriteValue("checkmate");
                    break;
                case GameResult.Agreed:
                    writer.WriteValue("agreed");
                    break;
                case GameResult.Repetition:
                    writer.WriteValue("repetition");
                    break;
                case GameResult.Timeout:
                    writer.WriteValue("timeout");
                    break;
                case GameResult.Resigned:
                    writer.WriteValue("resigned");
                    break;
                case GameResult.Stalemate:
                    writer.WriteValue("stalemate");
                    break;
                case GameResult.Lose:
                    writer.WriteValue("lose");
                    break;
                case GameResult.Insufficient:
                    writer.WriteValue("insufficient");
                    break;
                case GameResult.FiftyMove:
                    writer.WriteValue("50move");
                    break;
                case GameResult.Abandoned:
                    writer.WriteValue("abandoned");
                    break;
                case GameResult.KingOfTheHill:
                    writer.WriteValue("kingofthehill");
                    break;
                case GameResult.ThreeCheck:
                    writer.WriteValue("threecheck");
                    break;
                case GameResult.TimeVsInsufficient:
                    writer.WriteValue("timevsinsufficient");
                    break;
                case GameResult.BughousePartnerLose:
                    writer.WriteValue("bughousepartnerlose");
                    break;
                default:
                    break;
            }
        }
    }
}
