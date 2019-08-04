namespace ChessComLibraryAPI.Models.Stats
{
    public class MonthlyStats
    {
        public int WonByFlag { get; set; }
        public int WonByResign { get; set; }
        public int WonByCheckmate { get; set; }
        public int WonByAbandoned { get; set; }



        public int LostByFlag { get; set; }
        public int LostByResign { get; set; }
        public int LostByCheckmate { get; set; }
        public int LostByAbandoned { get; set; }



        public int DrawByRepetition { get; set; }
        public int DrawByAgreed { get; set; }
        public int DrawByStalemate { get; set; }
        public int DrawByFiftyMove { get; set; }
        public int DrawByTimeoutVsInsufficient { get; set; }



        public int ShortGamesWon { get; set; }
        public int ShortGamesLost { get; set; }


    }
}
