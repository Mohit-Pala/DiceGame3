using System;
using Xunit;
using DiceGame3.Models;
using DiceGame3.Enums;

namespace DiceGame3.Tests
{
    public class DieFaceTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var diceFace = new DieFace(DieFaceValues.Two, 0.3f);
            Assert.Equal(DieFaceValues.Two, diceFace.FaceValue);
            Assert.False(diceFace.IsWildCard);
            Assert.Equal(0.3f, diceFace.Weight);
        }

        [Fact]
        public void Constructor_WithWildCardFlag_SetsIsWildCard()
        {
            var df = new DieFace(DieFaceValues.WildCard, true, 0.2f);
            Assert.Equal(DieFaceValues.WildCard, df.FaceValue);
            Assert.True(df.IsWildCard);
            Assert.Equal(0.2f, df.Weight);
        }
    }
}
