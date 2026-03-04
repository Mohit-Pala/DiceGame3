namespace DiceGame3.Models
{
    public class Round(int roundNumber, int targetScore, Boss? boss = null)
    {
        public Guid RoundId { get; } = Guid.NewGuid();
        public int RoundNumber { get; } = roundNumber;
        public int TargetScore { get; } = targetScore;

        public bool IsBossRound => Boss != null;
        public Boss? Boss { get; } = boss;
    }
}
