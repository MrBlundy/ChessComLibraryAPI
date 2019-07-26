using ChessComLibraryAPI.Models.Clubs;
using ChessComLibraryAPI.Models.Games;
using ChessComLibraryAPI.Models.Misc;
using ChessComLibraryAPI.Models.Stats;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
            //    if (message.StatusCode != HttpStatusCode.OK) return null;
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
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}");
            var profile = JsonConvert.DeserializeObject<Profile>(json);
            return profile;
        }

        // retrieves player Profile Stats
        public static async Task<ProfileStats> GetPlayerStatsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/stats");
            var stats = JsonConvert.DeserializeObject<ProfileStats>(json);
            return stats;
        }

        // returns a string containing valid titles
        public static string GetChessTitleOptions()
        {
            return "GM, WGM, IM, WIM, FM, WFM, NM, WNM, CM, WCM";
        }

        // retrieves an array of usernames with given title
        public static async Task<string[]> LookupPlayersWithTitleAsync(string title)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/titled/{title}");
            var players = JObject.Parse(json)["players"].ToObject<string[]>();
            return players;
        }

        // checks if player is online
        public static async Task<bool> IsPlayerOnlineAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/is-online");
            var jObject = JObject.Parse(json);
            if ((bool)jObject["online"]) return true;
            else return false;

        }

        // retrieves all clubs player is part of
        public static async Task<Club[]> GetPlayerClubsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/clubs");
            var clubs = JObject.Parse(json)["clubs"].ToObject<Club[]>();
            return clubs;
        }

        // List of Team matches the player has attended, is partecipating or is currently registered. 
        public static async Task<ClubMatches> GetTeamMatchesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/matches");
            var matches = JsonConvert.DeserializeObject<ClubMatches>(json);
            return matches;
        }


        // retrieve the daily puzzle
        public static async Task<DailyPuzzle> GetDailyPuzzleAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/puzzle");
            var puzzle = JsonConvert.DeserializeObject<DailyPuzzle>(json);
            return puzzle;
        }

        // retrieve the list of streamers, filter by currently live or not
        public static async Task<Streamer[]> GetStreamersAsync(bool live = false)
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/streamers");
            var streamers = JObject.Parse(json)["streamers"].ToObject<Streamer[]>();

            if (live) return streamers.Where(s => s.IsLive).ToArray();
            else return streamers;

        }

        // retrieves all the leaderboards, top 50 players
        public static async Task<Leaderboard> GetLeaderboardsAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/leaderboards");
            var leaderBoard = JsonConvert.DeserializeObject<Leaderboard>(json);
            return leaderBoard;
        }

        // retrieve leaderboard for selected format
        public static async Task<LeaderboardPlayer[]> GetPlayersOfLeaderboard(GameVariants gameType)
        {
            var leaderBoards = await GetLeaderboardsAsync();
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
                //case GameVariants.Rapid960:
                //    break;
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
                //case GameVariants.FourPlayer:
                //    return leaderBoards.FourPlayer;
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
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games");
            var jObject = JObject.Parse(json);
            var games = jObject["games"].ToObject<DailyGame[]>();
            return games;
        }

        // Array of Daily Chess games where it is the player's turn to act.
        public static async Task<DailyGame[]> GetDailyGamesPlayerToMoveAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/to-move");
            var jObject = JObject.Parse(json);
            var games = jObject["games"].ToObject<DailyGame[]>();
            return games;
        }

        // Array of monthly archives available for this player.
        public static async Task<string[]> GetAvailableMonthlyArchivesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/archives");
            var jObject = JObject.Parse(json);
            var archives = jObject["archives"].ToObject<string[]>();
            return archives;
        }
                      

        // Array of Live and Daily Chess games that a player has finished for a given year/month.
        public static async Task<ArchivedGame[]> GetMonthlyArchiveAsync(string username, int year, int month)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/games/{year}/{month}");
            var jObject = JObject.Parse(json);
            var archive = jObject["games"].ToObject<ArchivedGame[]>();
            return archive;

        }
        public static async Task<ArchivedGame[]> GetMonthlyArchiveAsync(string url)
        {
            var json = await GetJsonFromUrlAsync(url);
            var jObject = JObject.Parse(json);
            var archive = jObject["games"].ToObject<ArchivedGame[]>();
            return archive;
        }

        // standard multi-game format PGN containing all games for a month
        public static async Task GetMonthlyArchivePgnDownloadAsync(string username, int year, int month, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                var url = new Uri($"https://api.chess.com/pub/player/{username}/games/{year}/{month}/pgn");
                await client.DownloadFileTaskAsync(url, fileName);
            }
        }

        // standard multi-game format PGN containing all games for a month
        public static async Task GetMonthlyArchivePgnDownloadAsync(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                var uri = new Uri(url);
                await client.DownloadFileTaskAsync(uri, fileName);
            }
        }

       
    }
}
