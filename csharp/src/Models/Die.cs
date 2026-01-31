using System;
using System.Collections.Generic;

namespace DiceGame3.Models;

public class Die(List<DieFace> faces)
{
  private List<DieFace> _faces = faces;
  private Random _random = new();

  public DieFace Roll()
  {
    // rand float bw p and q1 
    var randomVal = _random.NextDouble();

    var totalWeight = 0.0;
    foreach (var face in _faces)
    {
      totalWeight += face.Weight;
      if (randomVal < totalWeight)
      {
        return face;
      }
    } 
    // fallback to last face
    // didnt knwo we got python like indedcihgn, damn ivant tupe
    return _faces[^1];
  }
}