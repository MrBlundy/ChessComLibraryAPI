using ChessComLibraryAPI.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessComLibraryAPI
{
    public static class ExtendedChessApi
    {
        public static PgnGame ConvertArchiveToPgn(ArchivedGame game)
        {
            var regex = new Regex(@"\[Date \W+(\d{4}\.\d{2}\.\d{2}).*White\W+(\w+).*Black\W+(\w+).*Result\W+(\d-\d).*WhiteElo\W+(\d{3,4}).*BlackElo\W+(\d{3,4}).*StartTime \W+(\d{2}:\d{2}:\d{2}.*EndTime\W+(\d{2}:\d{2}:\d{2}))");
            var match = regex.Match(game.CurrentPGN);
            if (match.Success)
            {
                return new PgnGame()
                {
                    Date = match.Groups[1].Value,

                    WhitePlayer = match.Groups[2].Value,
                    BlackPlayer = match.Groups[3].Value,

                    GameResult = match.Groups[4].Value,

                    WhiteElo = int.Parse(match.Groups[5].Value),
                    BlackElo = int.Parse(match.Groups[6].Value),

                    StartTime = match.Groups[7].Value,
                    EndTime = match.Groups[8].Value,

                    TimeClass = game.TimeClass
                };
            }

            return null;
        }

        public static PgnGame[] ConvertMultipleArchivesPGN(ArchivedGame[] games)
        {
            var list = new List<PgnGame>();
            foreach (var game in games)
            {
                var pgn = ConvertArchiveToPgn(game);
                if (pgn != null) list.Add(ConvertArchiveToPgn(game));
            }
            return list.ToArray();
        }
        public static int MovesCount(this ArchivedGame game)
        {
            // regex pattern to match
            string pattern = @"\d{1,3}\.\.\.";

            // get all regex matches
            var matches = Regex.Matches(game.CurrentPGN, pattern);

            // return the number of matches
            return matches.Count;
        }
        public static double CheckPercentageShortGames(ArchivedGame[] games)
        {
            // retrieve list of games with less than 15 moves
            var short_games = games.Where(game => game.MovesCount() < 15);

            // get the percentage of short games to total games
            double short_percent = (double)short_games.Count() * 100 / games.Count();
            
            return Math.Ceiling(short_percent);
        }

        public static double CheckPercentageLostGames(string username, ArchivedGame[] games)
        {
            // retrieve games lost by username
            var lost_games = games.Where(game => (game.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.WhitePlayer.GameResult != GameResult.Win)
                                  || (game.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.BlackPlayer.GameResult != GameResult.Win));

            // get the percentage of lost games to total games
            double lost_percent = (double)lost_games.Count() * 100 / games.Count();

            return Math.Ceiling(lost_percent);
        }

        public static double CheckPercentageWonGames(string username, ArchivedGame[] games)
        {
            // retrieve games lost by username
            var won_games = games.Where(game => (game.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.WhitePlayer.GameResult == GameResult.Win)
                                  || (game.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.BlackPlayer.GameResult == GameResult.Win));

            // get the percentage of lost games to total games
            double lost_percent = (double)won_games.Count() * 100 / games.Count();

            return Math.Ceiling(lost_percent);
        }

        public static ArchivedGame[] RetrieveGamesByResult(this ArchivedGame[] games, GameResult result, string username = "")
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                return games.Where(game => (game.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.WhitePlayer.GameResult == GameResult.Win)
                      || (game.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.BlackPlayer.GameResult == GameResult.Win)).ToArray();
            }
            
            return games.Where(game => game.WhitePlayer.GameResult == result || game.BlackPlayer.GameResult == result).ToArray();
        }

        public static ArchivedGame[] QueryArchivedGames(this ArchivedGame[] games, string username, GameResult userResult, GameResult oppResult)
        {
            var list = new List<ArchivedGame>();

            list.AddRange(games.Where(game => game.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                   && game.WhitePlayer.GameResult == userResult && game.BlackPlayer.GameResult == oppResult));

            list.AddRange(games.Where(game => game.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                       && game.BlackPlayer.GameResult == userResult && game.WhitePlayer.GameResult == oppResult));

            return list.ToArray();
        }


        public static async Task<bool> CheckPlayer(string username)
        {
            // grab all available monthly archives
            var availMonths = await ChessAPI.GetAvailableMonthlyArchivesAsync(username);

            // grab archive for last month of games
            var games = await ChessAPI.GetMonthlyArchiveAsync(availMonths[availMonths.Length - 1]);

            // perform check to see percentage of games which are 'short'
            var check1 = CheckPercentageShortGames(games);

            // perform check to see percentage of games which user lost
            var check2 = CheckPercentageLostGames(username, games);

            // if either percentage is over 50% raise red flag
            if (check1 > 50 || check2 > 50) return true;
            
            // the user passed the check
            else return false;
            
        }
        

    }
}
