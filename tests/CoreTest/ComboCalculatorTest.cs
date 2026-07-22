using Xunit;
using PokemonAnalysisProject.Core.Probability;

namespace PokemonAnalysisProject.Core.Tests.Probability
{
    public class ComboCalculatorTests
    {
        [Fact]
        public void OddsOfBoth_Is_Lower_Than_Either_Individual_Card()
        {
            double bothOdds = ComboCalculator.OddsOfBoth(copiesOfA: 4, copiesOfB: 3, cardsDrawn: 7);
            double oddsA = ProbabilityEngine.AtLeast(60, 4, 7, 1);
            double oddsB = ProbabilityEngine.AtLeast(60, 3, 7, 1);

            Assert.True(bothOdds < oddsA);
            Assert.True(bothOdds < oddsB);
        }
    }
}