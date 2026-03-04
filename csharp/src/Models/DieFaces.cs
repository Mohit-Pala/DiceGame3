using System;
using DiceGame3.Enums;

namespace DiceGame3.Models
{
  public class DieFace
  {
    public DieFaceValues FaceValue { get; set; }

    public bool IsWildCard { get; set; }

    public int Weight { get; set; }

    public DieFace(DieFaceValues faceValue, int weight)
    {
      if (weight < 0)
        throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be a non-negative integer.");
      FaceValue = faceValue;
      Weight = weight;
    }

    public DieFace(DieFaceValues faceValue, bool isWildCard, int weight)
    {
      if (weight < 0)
        throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be a non-negative integer.");
      FaceValue = faceValue;
      IsWildCard = isWildCard;
      Weight = weight;
    }
  }
}
