using DiceGame3.Enums;
using DiceGame3.Models;

namespace DiceGame3.Scoring
{
  public abstract class BaseFarkleScoringStrategy : IScoringStrategy
  {
    public abstract string Name { get; }
    public abstract string Description { get; }

    public DieScoringResult CalcScore(List<DieFaceValues> diceFaces)
    {
      int[] freqMap = new int[7];
      SetupFrequencies(diceFaces, freqMap);
      return CalcScoreForStraight(freqMap);
    }

    protected virtual int FullStraightScore => 1500;
    protected virtual int HighStraightScore => 750;
    protected virtual int LowStraightScore => 500;

    private static void SetupFrequencies(List<DieFaceValues> diceFaces, int[] freqMap)
    {
      foreach (var face in diceFaces)
      {
        if (face == DieFaceValues.WildCard) continue;
        var v = (int)face;
        if (v is >= 1 and <= 6) freqMap[v]++;
      }
    }

    private static bool FacesPresentInRange(int[] freqMap, int start, int end)
    {
      for (var i = start; i <= end; i++)
        if (freqMap[i] == 0) return false;
      return true;
    }

    private static void DecreaseFrequencies(int[] freqMap, int start, int end)
    {
      for (var i = start; i <= end; i++)
        freqMap[i]--;
    }

    private DieScoringResult CalcScoreForStraight(int[] freqMap)
    {
      var result = new DieScoringResult();

      if (FacesPresentInRange(freqMap, 1, 6))
      {
        DecreaseFrequencies(freqMap, 1, 6);
        result.Score += FullStraightScore;
        result.AlreadyScoredDieCount += 6;
        var remaining = CalcScoreForStraight(freqMap);
        result.Score += remaining.Score;
        result.AlreadyScoredDieCount += remaining.AlreadyScoredDieCount;
        return result;
      }

      if (FacesPresentInRange(freqMap, 2, 6))
      {
        DecreaseFrequencies(freqMap, 2, 6);
        result.Score += HighStraightScore;
        result.AlreadyScoredDieCount += 5;
        var remaining = CalcScoreForStraight(freqMap);
        result.Score += remaining.Score;
        result.AlreadyScoredDieCount += remaining.AlreadyScoredDieCount;
        return result;
      }

      if (FacesPresentInRange(freqMap, 1, 5))
      {
        DecreaseFrequencies(freqMap, 1, 5);
        result.Score += LowStraightScore;
        result.AlreadyScoredDieCount += 5;
        var remaining = CalcScoreForStraight(freqMap);
        result.Score += remaining.Score;
        result.AlreadyScoredDieCount += remaining.AlreadyScoredDieCount;
        return result;
      }

      var faceResult = CalcScoreForFaceValues(freqMap, 1);
      result.Score += faceResult.Score;
      result.AlreadyScoredDieCount += faceResult.AlreadyScoredDieCount;
      return result;
    }

    private DieScoringResult CalcScoreForFaceValues(int[] freqMap, int faceValue)
    {
      if (faceValue > 6) return new DieScoringResult();

      var result = new DieScoringResult();
      var count = freqMap[faceValue];

      switch (count)
      {
        case >= 3:
          {
            var baseScore = faceValue == 1 ? 1000 : faceValue * 100;
            var diceToScore = Math.Min(count, 6);
            var residual = count - diceToScore;

            var multiplier = diceToScore switch { 4 => 2, 5 => 4, 6 => 8, _ => 1 };

            result.Score += baseScore * multiplier;
            result.AlreadyScoredDieCount += diceToScore;

            if (residual > 0)
            {
              var original = freqMap[faceValue];
              freqMap[faceValue] = residual;
              var residualResult = CalcScoreForFaceValues(freqMap, faceValue);
              result.Score += residualResult.Score;
              result.AlreadyScoredDieCount += residualResult.AlreadyScoredDieCount;
              freqMap[faceValue] = original;
            }

            var next = CalcScoreForFaceValues(freqMap, faceValue + 1);
            result.Score += next.Score;
            result.AlreadyScoredDieCount += next.AlreadyScoredDieCount;
            return result;
          }
        case > 0:
          switch (faceValue)
          {
            case 1:
              result.Score += count * 100;
              result.AlreadyScoredDieCount += count;
              break;
            case 5:
              result.Score += count * 50;
              result.AlreadyScoredDieCount += count;
              break;
          }
          break;
      }

      var remaining = CalcScoreForFaceValues(freqMap, faceValue + 1);
      result.Score += remaining.Score;
      result.AlreadyScoredDieCount += remaining.AlreadyScoredDieCount;
      return result;
    }
  }
}
