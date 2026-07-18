using Xunit;
using PokemonAnalysisProject.Core.Probability;

namespace PokemonAnalysisProject.Core.Tests.Probability
{
    public class MulliganCalculatorTests
    {
        [Fact]
        public void MulliganOdds_Matches_ProbabilityEngine_None()
        {
            double expected = ProbabilityEngine.None(60, 8, 7);
            double actual = MulliganCalculator.MulliganOdds(basicCount: 8);
            Assert.Equal(expected, actual, precision: 10);
        }
    }
}