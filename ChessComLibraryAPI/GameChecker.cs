using ChessComLibraryAPI.Models.Games;
using ChessComLibraryAPI.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessComLibraryAPI
{

    public static class GameChecker
    {
        public static MonthlyStats RetrieveMonthlyStats(this ArchivedGame[] games, string username)
        {
            var stats = new MonthlyStats
            {
                WonByFlag = QueryArchivedGames(games, username, GameResult.Win, GameResult.Timeout).Count(),
                WonByResign = QueryArchivedGames(games, username, GameResult.Win, GameResult.Resigned).Count(),
                WonByCheckmate = QueryArchivedGames(games, username, GameResult.Win, GameResult.Checkmated).Count(),
                WonByAbandoned = QueryArchivedGames(games, username, GameResult.Win, GameResult.Abandoned).Count(),

                LostByFlag = QueryArchivedGames(games, username, GameResult.Timeout, GameResult.Win).Count(),
                LostByResign = QueryArchivedGames(games, username, GameResult.Resigned, GameResult.Win).Count(),
                LostByCheckmate = QueryArchivedGames(games, username, GameResult.Checkmated, GameResult.Win).Count(),
                LostByAbandoned = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),

                DrawByRepetition = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),
                DrawByAgreed = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),
                DrawByStalemate = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),
                DrawByFiftyMove = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),
                DrawByTimeoutVsInsufficient = QueryArchivedGames(games, username, GameResult.Abandoned, GameResult.Win).Count(),
               
            };

            if (games.Any(g => g.MovesCount() < 15))
            {
                stats.ShortGamesWon = games.Where(g => g.MovesCount() < 15)
                                           .Where(g => g.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                                       g.WhitePlayer.GameResult == GameResult.Win)
                                           .Count();

                stats.ShortGamesLost = games.Where(g => g.MovesCount() < 15)
                           .Where(g => g.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                       g.BlackPlayer.GameResult == GameResult.Win)
                           .Count();
            }

            return stats;
        }



        public static int MovesCount(this ArchivedGame game)
        {
            // regex pattern to match
            string pattern = @"\d{1,3}\.\.\.";
            if (game.CurrentPGN != null)
            {
                // get all regex matches
                var matches = Regex.Matches(game.CurrentPGN, pattern);

                // return the number of matches
                return matches.Count;
            }

            return 0;
        }

        public static double CheckPercentageShortGames(this ArchivedGame[] games)
        {
            // retrieve list of games with less than 15 moves
            var short_games = games.Where(game => game.MovesCount() < 15);

            // get the percentage of short games to total games
            double short_percent = (double)short_games.Count() * 100 / games.Count();

            return Math.Round(short_percent);
        }

        public static double CheckPercentageLostGames(this ArchivedGame[] games, string username)
        {
            // retrieve games lost by username
            var lost_games = games.Where(game => (game.WhitePlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.WhitePlayer.GameResult != GameResult.Win)
                                  || (game.BlackPlayer.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && game.BlackPlayer.GameResult != GameResult.Win));

            // get the percentage of lost games to total games
            double lost_percent = (double)lost_games.Count() * 100 / games.Count();

            return Math.Round(lost_percent);
        }

        public static double CheckPercentageWonGames(this ArchivedGame[] games, string username)
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
    }
}
