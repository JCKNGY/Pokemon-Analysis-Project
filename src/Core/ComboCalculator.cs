namespace PokemonAnalysisProject.Core.Probability
{
    public static class ComboCalculator
    {
        // TODO: Odds of drawing Card A AND Card B together (inclusion-exclusion)
        public static double OddsOfBoth(int copiesOfA, int copiesOfB, int cardsDrawn, int deckSize = 60)
        {
            double oddsNoA = ProbabilityEngine.None(deckSize, copiesOfA, cardsDrawn);
            double oddsNoB = ProbabilityEngine.None(deckSize, copiesOfB, cardsDrawn);
            double oddsNeither = ProbabilityEngine.None(deckSize, copiesOfA + copiesOfB, cardsDrawn);

            return 1.0 - oddsNoA - oddsNoB + oddsNeither;
        }
    }
}