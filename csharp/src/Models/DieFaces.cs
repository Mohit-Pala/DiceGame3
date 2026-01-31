using System;
using DiceGame3.Enums;

namespace DiceGame3.Models
{
  public class DieFace
  {
    public DieFaceValues FaceValue { get; set; }

    public bool IsWildCard { get; set; }

    public float Weight { get; set; }

    public DieFace(DieFaceValues faceValue, float weight)
    {
      if (weight < 0 || weight > 1)
        throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be between 0 and 1.");
      FaceValue = faceValue;
      Weight = weight;
    }

    public DieFace(DieFaceValues faceValue, bool isWildCard, float weight)
    {
      if (weight < 0 || weight > 1)
        throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be between 0 and 1.");
      FaceValue = faceValue;
      IsWildCard = isWildCard;
      Weight = weight;
    }
  }
}
