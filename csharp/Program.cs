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


// using System;
// using System.Collections.Generic;

// var diceValues = new List<int> { 2,3,4,5,6, 2,3,4,5,6, 2,3,4,5,6,1,1,1 };
// var result = DiceGame3.Helpers.DieScoringCalculator.CalcScore(diceValues);
// Console.WriteLine(result.Score);
// Console.WriteLine(result.AlreadyScoredDieCount);
// Console.WriteLine(result.IsBust);
// Console.WriteLine(result.CanContinueScoring(diceValues.Count));



// container: use a dictionary keyed by the UUID
using DiceGame3.Enums;
using DiceGame3.Models;

var diceStore = new Dictionary<Guid, DieContainer>();

// default faces & weights (adjust to your Die constructor/signature)
var defaultFaces = new List<DieFace>{
    new DieFace(DieFaceValues.One, 1),
    new DieFace(DieFaceValues.Two, 1),
    new DieFace(DieFaceValues.Three, 1),
    new DieFace(DieFaceValues.Four, 1),
    new DieFace(DieFaceValues.Five, 1),
    new DieFace(DieFaceValues.Six, 1)
};

for (int i = 0; i < 6; i++)
{
    // create a Die (assumes a constructor Die(string[] faces, double[] weights))
    var die = new Die(defaultFaces);

    // name / color / upgrades can be added to DieContainer later if you extend it
    var container = new DieContainer($"Die {i + 1}", die);

    diceStore.Add(container.DiceId, container);
}

// example: show the created dice ids
foreach (var kv in diceStore)
    Console.WriteLine($"Created {kv.Value.DiceName} -> {kv.Key}");

foreach (var kv in diceStore)
{
    var face = kv.Value.Die.Roll();
    Console.WriteLine($"Rolled {kv.Value.DiceName} -> {face.FaceValue} (WildCard: {face.IsWildCard}, Weight: {face.Weight})");
}
