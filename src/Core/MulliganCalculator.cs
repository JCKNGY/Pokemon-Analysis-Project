namespace PokemonAnalysisProject.Core.Probability
{
    public static class MulliganCalculator
    {
        // TODO: Odds of ZERO Basic Pokemon in opening hand

        public static double MulliganOdds(int basicCount, int deckSize = 60)
        {
            return ProbabilityEngine.None(deckSize, basicCount, 7);
        }
    }
}