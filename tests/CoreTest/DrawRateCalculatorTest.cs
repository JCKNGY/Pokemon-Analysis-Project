using Xunit;
using PokemonAnalysisProject.Core.Probability;
public class DrawRateCalculatorTests
    {
        [Fact]
        public void OpeningHandOdds_Matches_ProbabilityEngine_AtLeast()
        {
            double expected = ProbabilityEngine.AtLeast(60, 4, 7, 1);
            double actual = DrawRateCalculator.OpeningHandOdds(copiesInDeck: 4);
            Assert.Equal(expected, actual, precision: 10);
        }

        [Theory]
        [InlineData(1, true, 7)]   // going first, turn 1 -> just opening hand
        [InlineData(1, false, 8)] // going second, turn 1 -> one extra draw
        public void OddsByTurn_Uses_Correct_Card_Count(int turn, bool goingFirst, int expectedCardsDrawn)
        {
            double expected = ProbabilityEngine.AtLeast(60, 4, expectedCardsDrawn, 1);
            double actual = DrawRateCalculator.OddsByTurn(copiesInDeck: 4, turn: turn, goingFirst: goingFirst);
            Assert.Equal(expected, actual, precision: 10);
        }
    }