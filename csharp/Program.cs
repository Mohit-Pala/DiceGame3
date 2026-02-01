// using System;
// using System.Collections.Generic;
// using DiceGame3.Enums;
// using DiceGame3.Models;

// var numSides = 6;
// float prob = 1.0f / numSides;
// var dieFacesList = new List<DieFace>();
// for (int i = 0; i < numSides; i++)
// {
//   dieFacesList.Add(new DieFace(DieFaceValues.One, prob));
//   dieFacesList.Add(new DieFace(DieFaceValues.Two, prob));
//   dieFacesList.Add(new DieFace(DieFaceValues.Three, prob));
//   dieFacesList.Add(new DieFace(DieFaceValues.Four, prob));
//   dieFacesList.Add(new DieFace(DieFaceValues.Five, prob));
//   dieFacesList.Add(new DieFace(DieFaceValues.Six, prob));
// }

// var die = new Die(dieFacesList);

// for (int i = 0; i < 10; i++)
// {
//   Console.WriteLine(die.Roll().FaceValue);
// }


using System;
using System.Collections.Generic;

var diceValues = new List<int> { 1,1,1, 5,5,5, 5,  1,1,1,1,1,1 };
var result = DiceGame3.Helpers.DieScoringCalculator.CalcScore(diceValues);
Console.WriteLine(result.Score);
Console.WriteLine(result.AlreadyScoredDieCount);
Console.WriteLine(result.IsBust);
Console.WriteLine(result.CanContinueScoring(diceValues.Count));