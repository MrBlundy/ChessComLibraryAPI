namespace ChessComLibraryAPI.Models.Games
{
    /// <summary>
    /// Enum representing the possible outcomes of a game
    /// </summary>
    public enum GameResult
    {
        Win, // Win
        Checkmated, //Checkmated
        Agreed,  //Draw agreed
        Repetition,  //Draw by repetition
        Timeout, //Timeout
        Resigned,  //Resigned
        Stalemate, //Stalemate
        Lose, //Lose
        Insufficient, //Insufficient material
        FiftyMove, //Draw by 50-move rule
        Abandoned, //Abandoned
        KingOfTheHill, //Opponent king reached the hill
        ThreeCheck, //Checked for the 3rd time
        TimeVsInsufficient, //Draw by timeout vs insufficient material
        BughousePartnerLose, //Bughouse partner lost
        UNKNOWN
    }

    
}
