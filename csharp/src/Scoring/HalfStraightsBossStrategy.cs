namespace DiceGame3.Scoring
{
  public class HalfStraightStrategy : BaseFarkleScoringStrategy
  {
    public override string Name        => "HalfStraightStrategy";
    public override string Description => "half score on straights";

    protected override int FullStraightScore => 750;
    protected override int HighStraightScore => 375;
    protected override int LowStraightScore  => 250;
  }
}
