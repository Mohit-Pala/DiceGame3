using DiceGame3.Scoring;

namespace DiceGame3.Models
{
  public class Boss(int id, string name, string flavorText, IScoringStrategy scoringStrategy)
    {
        public int Id { get; set; } = id;
        public string Name { get; } = name;
        public string FlavorText { get; } = flavorText;
        public IScoringStrategy ScoringStrategy { get; } = scoringStrategy;
    }
}
