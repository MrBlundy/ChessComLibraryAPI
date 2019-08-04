using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChessComLibraryAPI.UnitTests
{
    [TestClass]
    public class ChessAPITests
    {
        [TestMethod]
        public static async Task GetJsonFromUrl_ReturnsString()
        {
            // Arrange
            // var class = new MyClass();
            // Act
            var result = await ChessAPI.GetJsonFromUrlAsync("https://api.chess.com/pub/player/calculatedblunder");
            // Assert
            Assert.AreNotEqual(string.Empty, result);
        }

        [TestMethod]
        public static async Task LookupPlayerAsync_ReturnsPlayer()
        {
            var result = await ChessAPI.LookupPlayerAsync("erik");
            Assert.AreEqual(41, result.PlayerID);
        }

        [TestMethod]
        public static async Task GetPlayerStats_ReturnsProfileStats()
        {
            var result = await ChessAPI.GetPlayerStatsAsync("calculatedblunder");
            Assert.IsNotNull(result.ChessBullet);
        }

        [TestMethod]
        public static async Task LookupPlayersWithTitleAsync_ReturnsStringArray()
        {
            var result = await ChessAPI.LookupPlayersWithTitleAsync("GM");
            Assert.AreNotEqual(new string[0], result);
        }
        [TestMethod]
        public static async Task IsPlayerOnlineAsync_PlayerIsOnline_ReturnsTrue()
        {
            var result = await ChessAPI.IsPlayerOnlineAsync("calculatedblunder");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public static async Task IsPlayerOnlineAsync_PlayerIsOffline_ReturnsFalse()
        {
            var result = await ChessAPI.IsPlayerOnlineAsync("calculatedblunder");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public static async Task GetPlayerClubs_ReturnsClubArray()
        {
            var result = await ChessAPI.GetPlayerClubsAsync("calculatedblunder");
            Assert.AreNotEqual(string.Empty, result[0].Name);
        }
        [TestMethod]
        public static async Task GetTeamMatchs_ReturnsClubMatchs()
        {
            var result = await ChessAPI.GetTeamMatchesAsync("erik");
            Assert.AreNotEqual(string.Empty, result.FinishedMatchs[0].Name);
        }
        [TestMethod]
        public static async Task GetDailyPuzzle_ReturnsDailyPuzzle()
        {
            var result = await ChessAPI.GetDailyPuzzleAsync();
            Assert.AreNotEqual(string.Empty, result.Title);
        }
        [TestMethod]
        public static async Task GetStreamers_ReturnsStreamerArray()
        {
            var result = await ChessAPI.GetStreamersAsync();
            Assert.AreNotEqual(string.Empty, result[0].Username);
        }
        [TestMethod]
        public static async Task GetLeaderboards_ReturnsLeaderboard()
        {
            var result = await ChessAPI.GetLeaderboardsAsync();
            Assert.AreNotEqual(null, result.Bullet);
            
        }
        //[TestMethod]
        //public async Task GetLeaderboard_ReturnsLeaderboardItemArray()
        //{
        //    //var result = ChessAPI.LookupPlayerAsync("calculatedblunder");
        //    //Assert.IsNotNull(result);
        //    Assert.Fail();
        //}
        [TestMethod]
        public static async Task GetDailyGames_ReturnsDailyGameArray()
        {
            var result = await ChessAPI.GetDailyGamesAsync("erik");
            Assert.IsNotNull(result);
            
        }
        [TestMethod]
        public static async Task GetDailyGamesPlayerToMove_ReturnsDailyGameArray()
        {
            var result = await ChessAPI.GetDailyGamesPlayerToMoveAsync("erik");
            Assert.IsNotNull(result);
           
        }
        [TestMethod]
        public static async Task GetAvailableMonthlyArchives_ReturnsStringArray()
        {
            var result = await ChessAPI.GetAvailableMonthlyArchivesAsync("calculatedblunder");
            Assert.IsNotNull(result);
            
        }
        [TestMethod]
        public static async Task GetMonthlyArchive_ReturnsArchiveGameArray()
        {
            var result = await ChessAPI.GetMonthlyArchiveAsync("calculatedblunder", 2017, 12);
            Assert.IsNotNull(result);
            
        }
        //[TestMethod]
        //public async Task GetMonthlyArchivePGN_WritesGamesToFile()
        //{
        //    //var result = ChessAPI.LookupPlayerAsync("calculatedblunder");
        //    //Assert.IsNotNull(result);
        //    Assert.Fail();
        //}
    }
}
