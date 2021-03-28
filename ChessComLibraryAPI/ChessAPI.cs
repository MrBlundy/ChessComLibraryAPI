﻿using ChessComLibraryAPI.Models.Clubs;
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
        private static HttpClient _client;

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

        #region Player Data

        // Get additional details about a player in a game.
        public static async Task<PlayerProfile> GetPlayerProfileAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerProfile>(json);

        }

        // String of valid titles.
        public static string GetChessTitleOptionsString()
        {
            return "GM, WGM, IM, WIM, FM, WFM, NM, WNM, CM, WCM";
        }


        // Array of valid titles.
        public static string[] GetChessTitleOptionsArray()
        {
            return new string[] { "GM", "WGM", "IM", "WIM", "FM", "WFM", "NM", "WNM", "CM", "WCM" };
        }


        // List of titled-player usernames.
        public static async Task<string[]> GetPlayersWithTitleAsync(string title)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/titled/{title}").ConfigureAwait(false);
            return JObject.Parse(json)["players"].ToObject<string[]>();
        }

        // Get ratings, win/loss, and other stats about a player's game play, tactics, lessons and Puzzle Rush score.
        public static async Task<ProfileStats> GetPlayerStatsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/stats").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProfileStats>(json);
        }

        // Tells if an unser has been online in the last five minutes.
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

        #endregion

        #region Games

        // Array of Daily Chess games that a player is currently playing.
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

            return new[] { "invalid username" };
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

        // Standard multi-game format PGN containing all games for a month.
        public static async Task GetMonthlyArchivePgnDownloadAsync(string username, int year, int month, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                var url = new Uri($"https://api.chess.com/pub/player/{username}/games/{year}/{month}/pgn");
                await client.DownloadFileTaskAsync(url, fileName).ConfigureAwait(false);
                client.DownloadFile(url, fileName);
            }
        }

        // Standard multi-game format PGN containing all games for a month.
        public static async Task GetMonthlyArchivesPgnDownloadAsync(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(new Uri(url), fileName).ConfigureAwait(false);
            }
        }


        public static async Task GetAllAvailableGamesDownloadAsync(string username, string directoryPath)
        {
            var availableArchives = await GetAvailableMonthlyArchivesAsync(username);
            foreach (var month in availableArchives)
            {
                var filePath = month.Substring(month.Length - 7);
                await GetMonthlyArchivesPgnDownloadAsync(month, directoryPath + @"\" + filePath);
            }
        }

        #endregion

        #region Participation

        // List of clubs the player is a member of, with joined date and last activity date.
        public static async Task<Club[]> GetPlayerClubsAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/clubs").ConfigureAwait(false);
            return JObject.Parse(json)["clubs"].ToObject<Club[]>();
        }

        // List of Team matches the player has attended, is participating or is currently registered.
        public static async Task<TeamMatches> GetTeamMatchesAsync(string username)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/player/{username}/matches").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TeamMatches>(json);
        }

        #endregion

        #region Clubs

        // Get additional details about a club.
        public static async Task<ClubProfile> GetClubProfileAsync(string url_id)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/club/{url_id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ClubProfile>(json);
        }


        public static async Task<ClubMembers> GetClubMembersAsync(string url_id)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/club/{url_id}/members").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ClubMembers>(json);
        }

        // List of daily and club matches, grouped by status (registered, in progress, finished).
        public static async Task<ClubMembers> GetClubMatchesAsync(string url_id)
        {
            var json = await GetJsonFromUrlAsync($"https://api.chess.com/pub/club/{url_id}/matches").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ClubMembers>(json);
        }

        #endregion


        #region Tournaments
        #endregion

        #region Team Matches
        #endregion

        #region Countries
        #endregion

        #region Daily Puzzle

        // retrieve the daily puzzle
        public static async Task<DailyPuzzle> GetDailyPuzzleAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/puzzle").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DailyPuzzle>(json);
        }

        #endregion

        #region Streamers

        // retrieves a list of chess.com streamers
        public static async Task<Streamer[]> GetStreamersAsync()
        {
            var json = await GetJsonFromUrlAsync("https://api.chess.com/pub/streamers").ConfigureAwait(false);
            return JObject.Parse(json)["streamers"].ToObject<Streamer[]>();
        }

        // retrieves a list of 'live' chess.com streamers
        public static async Task<Streamer[]> GetStreamersAsync(bool live)
        {
            if (live)
            {
                var streamers = await GetStreamersAsync().ConfigureAwait(false);
                return streamers.Where(s => s.IsLive).ToArray();
            }

            return await GetStreamersAsync().ConfigureAwait(false);

        }

        #endregion

        #region Leaderboard

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

        #endregion











    }

}
