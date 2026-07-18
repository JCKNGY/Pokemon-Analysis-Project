using Xunit;
using PokemonAnalysisProject.Core.Probability;

namespace PokemonAnalysisProject.Core.Tests.Probability
{
    public class ProbabilityEngineTests
    {
        [Theory]
        [InlineData(5, 2, 10)]
        [InlineData(6, 0, 1)]
        [InlineData(6, 6, 1)]
        public void Combinations_Returns_Expected_Value(int n, int r, double expected)
        {
            double result = ProbabilityEngine.Combinations(n, r);
            Assert.Equal(expected, result, precision: 6);
        }

        [Fact]
        public void Pmf_Matches_Known_Hand_Calculated_Value()
        {
            // TODO: Arrange - use your N=60, K=4, n=7, k=1 sanity check numbers

            double answer = ProbabilityEngine.Pmf(60, 4, 7, 1);

            Assert.Equal(0.3363,answer, precision: 4);
        }

        [Theory]
        [InlineData(60, 4, 7, 5)]  
        [InlineData(60, 10, 7, 8)] 
        [InlineData(10, 8, 5, 1)]  
        
        public void Pmf_Returns_Zero_For_Impossible_Cases(int N, int K, int n, int k)
        {
           double result = ProbabilityEngine.Pmf(N, K, n, k);
           Assert.Equal(0.0, result); 
        }
            
        [Fact]
        public void AtLeast_Matches_Known_Hand_Calculated_Value()
        {
            // TODO: same idea as Pmf test above, but for AtLeast
            double answer = ProbabilityEngine.AtLeast(60, 4, 7, 1);
            Assert.Equal(0, answer, precision: 4);
        }
        [Fact]
        public void None_With_Zero_Copies_Always_Returns_One()
        {
            double answer = ProbabilityEngine.None(60, 0, 7);
            Assert.Equal(1.0, answer);
        }
        
    }
}