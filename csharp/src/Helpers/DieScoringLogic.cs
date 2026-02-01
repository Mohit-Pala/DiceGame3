using System.Collections.Generic;
using DiceGame3.Models;

namespace DiceGame3.Helpers
{
  public static class DieScoringCalculator
  {
    public static DieScoringResult CalcScore(List<int> diceValues)
    {
      int[] freqMap = new int[7];
      SetupFrequencies(diceValues, freqMap);
      return new DieScoringResult();
    }

    // pop the freq map, inc one for each face value, need to find a wa y to store wildcards nexy
    private static void SetupFrequencies(List<int> diceValues, int[] freqMap)
    {
      foreach (var faceValue in diceValues)
      {
        // store each frequency in the array in the end there should be 1 to 6 
        freqMap[faceValue]++;
      }
    }

    // checl if all faces are present atleast once in the range
    private static bool FacesPresentInRange(int[] freqMap, int start, int end)
    {
      for (int i = start; i <= end; i++)
      {
        if (freqMap[i] == 0) return false;
      }
      return true;
    }

    // secrease the vount of each face in the ranfe by one
    private static void DecreaseFrequencies(int[] freqMap, int start, int end)
    {
      for (int i = start; i <= end; i++)
      {
        freqMap[i]--;
      }
    }

    private static DieScoringResult CalcScoreForStraight(int[] freqMap)
    {
      DieScoringResult result = new DieScoringResult();

      // do full staright first, basically from 1 to 6
      if (FacesPresentInRange(freqMap, 1, 6))
      {
        DecreaseFrequencies(freqMap, 1, 6); // svored, remove from freq map
        result.Score += 1500;
        result.AlreadyScoredDieCount += 6;



        // in normal farkle stop here, but this mf upgraded they hand size
        DieScoringResult remainingScore = CalcScoreForStraight(freqMap);
        result.Score += remainingScore.Score;
        result.AlreadyScoredDieCount += remainingScore.AlreadyScoredDieCount;
        return result;
      }

      // check high straight, cus ts score more points
      if (FacesPresentInRange(freqMap, 2, 6))
      {
        DecreaseFrequencies(freqMap, 2, 6); 
        result.Score += 750;
        result.AlreadyScoredDieCount += 5;

        DieScoringResult remainingScore = CalcScoreForStraight(freqMap);
        result.Score += remainingScore.Score;
        result.AlreadyScoredDieCount += remainingScore.AlreadyScoredDieCount;
        return result;
      }

      // check low straight
      if (FacesPresentInRange(freqMap, 1, 5))
      {
        DecreaseFrequencies(freqMap, 1, 5); 
        result.Score += 500;
        result.AlreadyScoredDieCount += 5;

        DieScoringResult remainingScore = CalcScoreForStraight(freqMap);
        result.Score += remainingScore.Score;
        result.AlreadyScoredDieCount += remainingScore.AlreadyScoredDieCount;
        return result;
      }

      // no straights, check for face values
      // break this to a new method
      DieScoringResult faceValueResult = CalcScoreForFaceValues(freqMap, 1);
      result.Score += faceValueResult.Score;
      result.AlreadyScoredDieCount += faceValueResult.AlreadyScoredDieCount;

      return result;
    }

    private static DieScoringResult CalcScoreForFaceValues(int[] freqMap, int faceValue)
    {
      DieScoringResult result = new DieScoringResult();

      // keep track of the current dice face being scored
      int count = freqMap[faceValue];

      // 3 of a king or better
      if (count >= 3)
      {
        // calc score for three of a kind, then mult by 2 4 8 for 4 5 6 of a kind
        var baseScoreForMultiples = faceValue == 1 ? 1000 : faceValue * 100;

        var multiplier = 1;
        if (count == 4) multiplier = 2;
        if (count == 5) multiplier = 4;
        if (count == 6) multiplier = 8;

        result.Score += baseScoreForMultiples * multiplier;
        result.AlreadyScoredDieCount += count;
        count = 0;
      }

      // 1 and 5 spwcial casw
      if (count > 0)
      {
        if (faceValue == 1)
        {
          result.Score += count * 100;
          result.AlreadyScoredDieCount += count;
        }
        else if (faceValue == 5)
        {
          result.Score += count * 50;
          result.AlreadyScoredDieCount += count;
        }
      }


      // move to next face value
      DieScoringResult remainingScore = CalcScoreForFaceValues(freqMap, faceValue + 1);
      result.Score += remainingScore.Score;
      result.AlreadyScoredDieCount += remainingScore.AlreadyScoredDieCount;
      
      return result;
    }
  }
}