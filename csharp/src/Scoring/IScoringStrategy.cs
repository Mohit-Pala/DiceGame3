using DiceGame3.Enums;
using DiceGame3.Models;

namespace DiceGame3.Scoring
{
  public interface IScoringStrategy
  {
    // prob name, descc to and id, maybe let the boosses track the id 
    string Name { get; }
    string Description { get; }
    DieScoringResult CalcScore(List<DieFaceValues> diceFaces);
  }
}
