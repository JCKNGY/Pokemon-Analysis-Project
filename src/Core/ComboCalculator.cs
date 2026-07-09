namespace PokemonAnalysisProject.Core.Probability
{
    public static class ComboCalculator
    {
        // TODO: Odds of drawing Card A AND Card B together
        // Steps:
        //   1. oddsNoA = None(60, copiesOfA, cardsDrawn)
        //   2. oddsNoB = None(60, copiesOfB, cardsDrawn)
        //   3. oddsNeither = None(60, copiesOfA + copiesOfB, cardsDrawn)
        //   4. answer = 1 - oddsNoA - oddsNoB + oddsNeither
        // (this is a known math trick called inclusion-exclusion,
        //  don't worry about why it works, just follow the steps)
    }
}