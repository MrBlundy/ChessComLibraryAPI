using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.TeamMatches
{
    public class TeamMatchBoard
    {
        public object Scores { get; set; }

        public MatchGame[] Games { get; set; }

    }
}
