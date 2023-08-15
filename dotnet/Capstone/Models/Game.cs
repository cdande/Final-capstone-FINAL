namespace Capstone.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public bool IsInProgress { get; set; }
        public int MaxTurns { get; set; }
        public int CurrentTurn { get; set; }
        public int UserId { get; set; }

    }
}
