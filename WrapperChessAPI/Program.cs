using ChessComLibraryAPI;
using System;
using System.Threading.Tasks;


namespace WrapperChessAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CodeChecks
            //WORKS
            var profile = ChessComLibraryAPI.ChessAPI.LookupPlayerAsync("calculatedblunder");

            //WORKS
            //var profileStats = ChessAPI.ChessAPI.GetPlayerStats("calculatedblunder");

            //WORKS
            //var players = ChessAPI.ChessAPI.LookupPlayersWithTitleAsync("GM");

            //WORKS
            //var isPlayerOnline = ChessAPI.ChessAPI.IsPlayerOnlineAsync("calculatedblunder");

            //WORKS
            //var clubs = ChessAPI.ChessAPI.GetPlayerClubs("calculatedblunder");

            //WORKS
            //var clubMatches = ChessAPI.ChessAPI.GetTeamMatches("erik");

            //WORKS
            //var dailyPuzzle = ChessAPI.ChessAPI.GetDailyPuzzle();

            //WORKS
            //var streamers = ChessAPI.ChessAPI.GetStreamers(true);

            //WORKS -- FIXED IN DLL PROJECT////////////////////////////////////////////////////////////////////////////
            //var leaderBoards = ChessAPI.ChessAPI.GetLeaderboards();

            //////////////////////////////////////////////////////////////////////////////////////
            //var leaderBoard = ChessAPI.ChessAPI.GetLeaderboard(ChessAPI.Games.GameTypes.Bullet);

            //WORKS////////////////////////////////////////////////////////////////////////////
            //var dailyGames = ChessAPI.ChessAPI.GetDailyGames("erik");

            //WORKS////////////////////////////////////////////////////////////////////////////
            //var dailyGamesPlayerToMove = ChessAPI.ChessAPI.GetDailyGamesPlayerToMove("erik");

            //WORKING ////////////////////////////////////////////////////////////////////////////
            //var availMonthlyArchives = ChessAPI.ChessAPI.GetAvailableMonthlyArchives("calculatedblunder");

            //WORKING ////////////////////////////////////////////////////////////////////////////
            //var monthlyArchive = ChessAPI.ChessAPI.GetMonthlyArchive("calculatedblunder", 2017, 12);

            //var monthlyArchivePGN = ChessAPI.ChessAPI.GetMonthlyArchivePGN("calculatedblunder", 2019, 06, @"C:\Temp\chessapi_test_pgn");
            #endregion

            //var twitch_blank_space = "⠀⠀⠀";

            blah();

            

            Console.ReadLine();
        }

        static async void blah()
        {
            await ChessAPI.GetMonthlyArchivePGNAsync("hikaru", 2019, 07, @"C:\Temp\TEST_PGN.pgn");

            //var games = await ChessComLibraryAPI.ChessAPI.GetMonthlyArchiveAsync("https://api.chess.com/pub/player/german_pawnstar/games/2019/03");
            //var short_percentage = ChessComLibraryAPI.ExtendedChessApi.CheckPercentageShortGames(games);
            //var lost_percentage = ChessComLibraryAPI.ExtendedChessApi.CheckPercentageLostGames("german_pawnstar", games);

            //Console.WriteLine($"german_pawnstar has lost {lost_percentage}% of {games.Length} games and {short_percentage}% of {games.Length} games are under 15 moves");

            //games = await ChessComLibraryAPI.ChessAPI.GetMonthlyArchiveAsync("https://api.chess.com/pub/player/furkoska/games/2019/06");
            //short_percentage = ChessComLibraryAPI.ExtendedChessApi.CheckPercentageShortGames(games);
            //lost_percentage = ChessComLibraryAPI.ExtendedChessApi.CheckPercentageLostGames("furkoska", games);

            //Console.WriteLine($"furkoska has lost {lost_percentage}% of {games.Length} games and {short_percentage}% of {games.Length} games are under 15 moves");

        }
    }
}
