namespace DiceGame3.Models
{
  public class DieScoringResult
  {
    public int Score { get; set; } = 0;
    public int AlreadyScoredDieCount { get; set; } = 0;
    public bool IsBust => Score == 0;
    public bool CanContinueScoring(int diceNotScored) => AlreadyScoredDieCount == diceNotScored;
  }
}