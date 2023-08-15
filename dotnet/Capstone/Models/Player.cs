namespace Capstone.Models
{
    public class Player
    {
        public int PlayerId { get; set; } 
        public string Username { get; set; }
        public string SelectedCharacter { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        public bool IsRolled { get; set; }
        public bool IsTurn { get; set; }
    }
}
