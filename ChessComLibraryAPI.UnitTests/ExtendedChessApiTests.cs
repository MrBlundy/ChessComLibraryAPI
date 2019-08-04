using ChessComLibraryAPI.Models.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChessComLibraryAPI.UnitTests
{
    [TestClass]
    public class ExtendedChessApiTests
    {
        [TestMethod]
        public static void MovesCount_ReturnsInt()
        {
            var pgn = @"n1. e4 {[%clk 0:02:59.9]} 1... c6 {[%clk 0:02:59.5]} 2. Nf3 {[%clk 0:02:59.8]} 2... d5 {[%clk 0:02:58.9]} 3. Nc3 {[%clk 0:02:59.7]} 3... dxe4 {[%clk 0:02:57.5]} 4. Nxe4 {[%clk 0:02:59.6]} 4... Nf6 {[%clk 0:02:57.1]} 5. Bd3 {[%clk 0:02:56.9]} 5... Bg4 {[%clk 0:02:50.4]} 6. h3 {[%clk 0:02:52.2]} 6... Bh5 {[%clk 0:02:48.3]} 7. Ng3 {[%clk 0:02:49.1]} 7... Bg6 {[%clk 0:02:44.5]} 8. Bxg6 {[%clk 0:02:47.6]} 8... hxg6 {[%clk 0:02:44.4]} 9. Qe2 {[%clk 0:02:47.2]} 9... e6 {[%clk 0:02:43.5]} 10. d4 {[%clk 0:02:45.4]} 10... Nbd7 {[%clk 0:02:42.6]} 11. c3 {[%clk 0:02:44.4]} 11... Bd6 {[%clk 0:02:37.9]} 12. Ne5 {[%clk 0:02:43.9]} 12... c5 {[%clk 0:02:29.8]} 13. Nxd7 {[%clk 0:02:33.1]} 13... Qxd7 {[%clk 0:02:26.8]} 14. dxc5 {[%clk 0:02:32.4]} 14... Bxc5 {[%clk 0:02:26.7]} 15. Bg5 {[%clk 0:02:31]} 15... O-O-O {[%clk 0:02:09.8]} 16. Bxf6 {[%clk 0:02:19.9]} 16... gxf6 {[%clk 0:02:08.2]} 17. Ne4 {[%clk 0:02:19.8]} 17... Be7 {[%clk 0:01:59.2]} 18. Nd2 {[%clk 0:02:18.7]} 18... f5 {[%clk 0:01:50.1]} 19. O-O-O {[%clk 0:02:17.6]} 19... Bg5 {[%clk 0:01:47.2]} 20. Kc2 {[%clk 0:02:16.9]} 20... Bxd2 {[%clk 0:01:45.9]} 21. Rxd2 {[%clk 0:02:16.8]} 21... Qxd2+ {[%clk 0:01:45.4]} 22. Qxd2 {[%clk 0:02:16.1]} 22... Rxd2+ {[%clk 0:01:45.3]} 23. Kxd2 {[%clk 0:02:16]} 23... Kd7 {[%clk 0:01:44.6]} 24. c4 {[%clk 0:02:14.3]} 24... e5 {[%clk 0:01:44]} 25. h4 {[%clk 0:02:10.8]} 25... Kc6 {[%clk 0:01:37.9]} 26. b4 {[%clk 0:02:09.8]} 26... b5 {[%clk 0:01:34.8]} 27. c5 {[%clk 0:02:07.8]} 27... Rd8+ {[%clk 0:01:34.3]} 28. Kc3 {[%clk 0:02:06]} 28... a5 {[%clk 0:01:19.3]} 29. a3 {[%clk 0:02:04.6]} 29... axb4+ {[%clk 0:01:13.7]} 30. axb4 {[%clk 0:02:04.5]} 30... e4 {[%clk 0:01:13.2]} 31. h5 {[%clk 0:01:59.4]} 31... Rd3+ {[%clk 0:01:08.1]} 32. Kc2 {[%clk 0:01:58.4]} 32... Rd4 {[%clk 0:01:07.7]} 33. h6 {[%clk 0:01:57]} 33... Rd8 {[%clk 0:01:06.8]} 34. h7 {[%clk 0:01:54.3]} 34... Rh8 {[%clk 0:01:05.7]} 35. Kd2 {[%clk 0:01:53]} 35... Kd5 {[%clk 0:01:04.8]} 36. Ke3 {[%clk 0:01:48.1]} 36... g5 {[%clk 0:01:01.1]} 37. g3 {[%clk 0:01:46.3]} 37... Ke5 {[%clk 0:00:55.4]} 38. Rh5 {[%clk 0:01:44.5]} 38... f6 {[%clk 0:00:54.2]} 39. c6 {[%clk 0:01:36.1]} 39... Kd6 {[%clk 0:00:52.4]} 40. Rh6 {[%clk 0:01:35.7]} 40... Kxc6 {[%clk 0:00:45.5]} 41. Rxf6+ {[%clk 0:01:33.8]} 41... Kc7 {[%clk 0:00:33]} 42. Rxf5 {[%clk 0:01:33.7]} 42... Rxh7 {[%clk 0:00:31.8]} 43. Rxb5 {[%clk 0:01:32.9]} 1-0";
            var game = new ArchivedGame() { CurrentPGN = pgn };

            var moveCount = game.MovesCount();

            //Assert.IsTrue(moveCount > 0);
            Assert.AreEqual(42, moveCount);

        }

        [TestMethod]
        public static async Task CheckPercentageShortGames_ReturnsDouble()
        {
            var games = await ChessAPI.GetMonthlyArchiveAsync("https://api.chess.com/pub/player/calculatedblunder/games/2019/04");
            var percentage = GameChecker.CheckPercentageShortGames(games);

            Assert.IsTrue(percentage > 0);
        }

        [TestMethod]
        public static async Task CheckPercentageLostGames_ReturnsDouble()
        {
            var games = await ChessAPI.GetMonthlyArchiveAsync("https://api.chess.com/pub/player/calculatedblunder/games/2018/08");
            var percentage = GameChecker.CheckPercentageLostGames(games, "calculatedblunder");

            Assert.IsTrue(percentage > 0);
        }

        //public static async Task CheckPlayer_ReturnsTrue()
        //{

        //}

    }


}
