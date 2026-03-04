using System;
using System.Collections.Generic;

namespace DiceGame3.Models;

public class Die(List<DieFace> faces)
{
  private List<DieFace> _faces = faces;
  private Random _random = new();

  public DieFace Roll()
  {
    var totalWeight = 0;
    foreach (var face in _faces)
      totalWeight += face.Weight;

    var randomVal = _random.Next(totalWeight);

    var cumulative = 0;
    foreach (var face in _faces)
    {
      cumulative += face.Weight;
      if (randomVal < cumulative)
        return face;
    }

    // fallback to last face
    // didnt knwo we got python like indedcihgn, damn ivant tupe
    return _faces[^1];
  }
}