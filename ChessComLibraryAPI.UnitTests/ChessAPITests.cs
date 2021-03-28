using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChessComLibraryAPI.UnitTests
{
    [TestClass]
    public class ChessAPITests
    {

        [TestMethod]
        public async Task GetJsonFromUrl_ReturnsString()
        {
            // Arrange
            // var class = new MyClass();
            // Act
            var result = await ChessAPI.GetJsonFromUrlAsync("https://api.chess.com/pub/player/calculatedblunder");
            // Assert
            Assert.AreNotEqual(string.Empty, result);
        }

        #region Player Data

        [TestMethod]
        public async Task GetPlayerProfileAsync_ReturnsPlayer()
        {
            var result = await ChessAPI.GetPlayerProfileAsync("calculatedblunder");
            Assert.AreEqual(41, result.PlayerID);
        }


        [TestMethod]
        public async Task LookupPlayersWithTitleAsync_ReturnsStringArray()
        {
            var result = await ChessAPI.GetPlayersWithTitleAsync("GM");
            Assert.AreNotEqual(new string[0], result);
        }


        [TestMethod]
        public async Task GetPlayerStats_ReturnsProfileStats()
        {
            var result = await ChessAPI.GetPlayerStatsAsync("calculatedblunder");
            Assert.IsNotNull(result.ChessBullet);
        }


        [TestMethod]
        public async Task IsPlayerOnlineAsync_PlayerIsOnline_ReturnsTrue()
        {
            var result = await ChessAPI.IsPlayerOnlineAsync("calculatedblunder");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public async Task IsPlayerOnlineAsync_PlayerIsOffline_ReturnsFalse()
        {
            var result = await ChessAPI.IsPlayerOnlineAsync("calculatedblunder");
            Assert.IsTrue(!result);
        }


        #endregion

        #region Games

        [TestMethod]
        public async Task GetDailyGames_ReturnsDailyGameArray()
        {
            var result = await ChessAPI.GetDailyGamesAsync("calculatedblunder");
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task GetDailyGamesPlayerToMove_ReturnsDailyGameArray()
        {
            var result = await ChessAPI.GetDailyGamesPlayerToMoveAsync("erik");
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task GetAvailableMonthlyArchives_ReturnsStringArray()
        {
            var result = await ChessAPI.GetAvailableMonthlyArchivesAsync("calculatedblunder");
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task GetMonthlyArchive_ReturnsArchiveGameArray()
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

        #endregion

        #region Participation

        [TestMethod]
        public async Task GetPlayerClubs_ReturnsClubArray()
        {
            var result = await ChessAPI.GetPlayerClubsAsync("calculatedblunder");
            Assert.AreNotEqual(string.Empty, result[0].Name);
        }
        [TestMethod]
        public async Task GetTeamMatchs_ReturnsClubMatchs()
        {
            var result = await ChessAPI.GetTeamMatchesAsync("erik");
            Assert.AreNotEqual(string.Empty, result.FinishedMatchs[0].Name);
        }

        #endregion

        #region Clubs

        [TestMethod]
        public async Task GetClubProfile_ReturnsClubProfile()
        {
            var result = await ChessAPI.GetClubProfileAsync("chess-com-developer-community");
            Assert.IsTrue(result.ID > 0);
        }


        [TestMethod]
        public async Task GetClubMembers_ReturnsClubMembers()
        {
            var result = await ChessAPI.GetClubMembersAsync("chess-com-developer-community");
            Assert.IsTrue(result.Weekly.Length > 0);
        }

        #endregion

        #region Tournaments
        #endregion

        #region Team Matches
        #endregion

        #region Countries
        #endregion

        #region Daily Puzzle

        [TestMethod]
        public async Task GetDailyPuzzle_ReturnsDailyPuzzle()
        {
            var result = await ChessAPI.GetDailyPuzzleAsync();
            Assert.AreNotEqual(string.Empty, result.Title);
        }

        #endregion

        #region Streamers

        [TestMethod]
        public async Task GetStreamers_ReturnsStreamerArray()
        {
            var result = await ChessAPI.GetStreamersAsync();
            Assert.AreNotEqual(string.Empty, result[0].Username);
        }

        #endregion

        #region Leaderboard

        [TestMethod]
        public async Task GetLeaderboards_ReturnsLeaderboard()
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

        #endregion







    }
}
