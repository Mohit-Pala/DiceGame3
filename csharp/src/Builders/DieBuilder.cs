using DiceGame3.Enums;
using DiceGame3.Models;

namespace DiceGame3.Builders
{
  public class DieBuilder
  {
    private readonly List<DieFace> _faces = new();

    public DieBuilder AddFace(DieFaceValues value, int weight = 1)
    {
      _faces.Add(new DieFace(value, weight));
      return this;
    }

    // default die
    public DieBuilder BuildNormalDie()
    {
      _faces.Add(new DieFace(DieFaceValues.One, 1));
      _faces.Add(new DieFace(DieFaceValues.Two, 1));
      _faces.Add(new DieFace(DieFaceValues.Three, 1));
      _faces.Add(new DieFace(DieFaceValues.Four, 1));
      _faces.Add(new DieFace(DieFaceValues.Five, 1));
      _faces.Add(new DieFace(DieFaceValues.Six, 1));
      return this;
    }

    // dice from kcd
    public DieBuilder BuildBiasedDie()
    {
      _faces.Add(new DieFace(DieFaceValues.One, 250));
      _faces.Add(new DieFace(DieFaceValues.Two, 333));
      _faces.Add(new DieFace(DieFaceValues.Three, 83));
      _faces.Add(new DieFace(DieFaceValues.Four, 83));
      _faces.Add(new DieFace(DieFaceValues.Five, 167));
      _faces.Add(new DieFace(DieFaceValues.Six, 83));
      return this;
    }

    public DieBuilder BuildEvenNumberDie()
    {
      _faces.Add(new DieFace(DieFaceValues.One, 67));
      _faces.Add(new DieFace(DieFaceValues.Two, 267));
      _faces.Add(new DieFace(DieFaceValues.Three, 67));
      _faces.Add(new DieFace(DieFaceValues.Four, 267));
      _faces.Add(new DieFace(DieFaceValues.Five, 67));
      _faces.Add(new DieFace(DieFaceValues.Six, 267));
      return this;
    }

    public DieBuilder BuildLuckyDie()
    {
      _faces.Add(new DieFace(DieFaceValues.One, 273));
      _faces.Add(new DieFace(DieFaceValues.Two, 45));
      _faces.Add(new DieFace(DieFaceValues.Three, 91));
      _faces.Add(new DieFace(DieFaceValues.Four, 136));
      _faces.Add(new DieFace(DieFaceValues.Five, 182));
      _faces.Add(new DieFace(DieFaceValues.Six, 273));
      return this;
    }
    public Die Build()
    {
      if (_faces.Count == 0)
        throw new InvalidOperationException("mf trying to make a dice without faces 💀");

      return new Die([.. _faces]);
    }
  }
}
