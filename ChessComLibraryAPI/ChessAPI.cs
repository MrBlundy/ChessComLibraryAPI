using ChessComLibraryAPI.Models.Clubs;
using ChessComLibraryAPI.Models.Games;
using ChessComLibraryAPI.Models.Misc;
using ChessComLibraryAPI.Models.Stats;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChessComLibraryAPI
{
    public static class ChessAPI
    {
        static HttpClient _client;

        static ChessAPI()
        {
            _client = new HttpClient();
            //ApiClient.BaseAddress = new Uri("https://api.chess.com/");
            _client.DefaultRequestHeaders.Accept.Clear();
            //_client.DefaultRequestHeaders.Add("User-Agent", "ChessComLibraryAPI//chesscom=CalculatedBlunder");

        }

        // gets json string from api endpoint
        public static async Task<string> GetJsonFromUrlAsync(string url)
        {
            //using (var client = new HttpClient())
            //{
            //    HttpResponseMessage message = await client.GetAsync(url);
            //    if (message.StatusCode != HttpStatusCode.OK) return string.Empty;
            //    return await message.Content.ReadAsStringAsync();
            //}

            using (HttpResponseMessage response = await _client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return string.Empty;
            }
        }

        // return player Profile
        public static async Task<Profile> LookupPlayerAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Profile>(json);
            
        }

        // retrieves player Profile Stats
        public static async Task<ProfileStats> GetPlayerStatsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/stats").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProfileStats>(json);
        }

        // returns a string containing valid titles
        public static string GetChessTitleOptions()
        {
            return "GM, WGM, IM, WIM, FM, WFM, NM, WNM, CM, WCM";
        }


        // retrieves an array of usernames with given title
        public static async Task<string[]> LookupPlayersWithTitleAsync(string title)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/titled/{title}").ConfigureAwait(false);
            return JObject.Parse(json)["players"].ToObject<string[]>();
        }

        // checks if player is online
        public static async Task<bool> IsPlayerOnlineAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/is-online").ConfigureAwait(false);
            var jObject = JObject.Parse(json);
            if ((bool)jObject["online"])
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // retrieves all clubs player is part of
        public static async Task<Club[]> GetPlayerClubsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/clubs").ConfigureAwait(false);
            return JObject.Parse(json)["clubs"].ToObject<Club[]>();
        }

        // List of Team matches the player has attended, is partecipating or is currently registered. 
        public static async Task<ClubMatches> GetTeamMatchesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/matches").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ClubMatches>(json);
        }


        // retrieve the daily puzzle
        public static async Task<DailyPuzzle> GetDailyPuzzleAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/puzzle").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DailyPuzzle>(json);
        }

        // retrieve the list of streamers, filter by currently live or not
        public static async Task<Streamer[]> GetStreamersAsync(bool live = false)
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/streamers").ConfigureAwait(false);
            var streamers = JObject.Parse(json)["streamers"].ToObject<Streamer[]>();

            if (live)
            {
                return streamers.Where(s => s.IsLive).ToArray();

            }
            else
            {
                return streamers;
            }
        }

        // retrieves all the leaderboards, top 50 players
        public static async Task<Leaderboard> GetLeaderboardsAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/leaderboards").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Leaderboard>(json);
        }

        // retrieve leaderboard for selected format
        public static async Task<LeaderboardPlayer[]> GetPlayersOfLeaderboard(GameVariants gameType)
        {
            var leaderBoards = await GetLeaderboardsAsync().ConfigureAwait(false);
            switch (gameType)
            {
                case GameVariants.Bullet:
                    return leaderBoards.Bullet;
                case GameVariants.Blitz:
                    return leaderBoards.Blitz;
                case GameVariants.Blitz960:
                    return leaderBoards.Blitz960;
                case GameVariants.Rapid:
                    return leaderBoards.Rapid;
                case GameVariants.Daily:
                    return leaderBoards.Daily;
                case GameVariants.Daily960:
                    return leaderBoards.Daily960;
                case GameVariants.Bughouse:
                    return leaderBoards.Bughouse;
                case GameVariants.ThreeCheck:
                    return leaderBoards.ThreeCheck;
                case GameVariants.Crazyhouse:
                    return leaderBoards.Crazyhouse;
                case GameVariants.KingOfTheHill:
                    return leaderBoards.KingOfTheHill;
                case GameVariants.Lessons:
                    return leaderBoards.Lessons;
                case GameVariants.Tactics:
                    return leaderBoards.Tactics;
                //case GameTypes.PuzzleRush:
                //    return leaderBoards.PuzzleRush;
                default:
                    return null;
            }
        }
               
        public static async Task<DailyGame[]> GetDailyGamesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games").ConfigureAwait(false);
            var jObject = JObject.Parse(json);
            return jObject["games"].ToObject<DailyGame[]>();
        }

        // Array of Daily Chess games where it is the player's turn to act.
        public static async Task<DailyGame[]> GetDailyGamesPlayerToMoveAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/to-move").ConfigureAwait(false);
            var jObject = JObject.Parse(json);
            return jObject["games"].ToObject<DailyGame[]>();
        }

        // Array of monthly archives available for this player.
        public static async Task<string[]> GetAvailableMonthlyArchivesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/archives").ConfigureAwait(false);
            var jObject = JObject.Parse(json);

            if (jObject.ContainsKey("archives"))
            {
                return jObject["archives"].ToObject<string[]>();
            }

            return new string[] { "invalid username" };
        }
                      

        // Array of Live and Daily Chess games that a player has finished for a given year/month.
        public static async Task<ArchivedGame[]> GetMonthlyArchiveAsync(string username, int year, int month)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/{year}/{month}").ConfigureAwait(false);
            var jObject = JObject.Parse(json);
            return jObject["games"].ToObject<ArchivedGame[]>();
        }
        public static async Task<ArchivedGame[]> GetMonthlyArchiveAsync(string url)
        {
            var json = await GetJsonFromUrlAsync(url).ConfigureAwait(false);
            var jObject = JObject.Parse(json);
            return jObject["games"].ToObject<ArchivedGame[]>();
        }

        // standard multi-game format PGN containing all games for a month
        public static async Task GetMonthlyArchivePgnDownloadAsync(string username, int year, int month, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                var url = new Uri($"https://api.chess.com/pub/player/{username}/games/{year}/{month}/pgn");
                await client.DownloadFileTaskAsync(url, fileName).ConfigureAwait(false);
            }
        }

        // standard multi-game format PGN containing all games for a month
        public static async Task GetMonthlyArchivesPgnDownloadAsync(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(new Uri(url), fileName).ConfigureAwait(false);
            }
        }
       
    }
   
}
