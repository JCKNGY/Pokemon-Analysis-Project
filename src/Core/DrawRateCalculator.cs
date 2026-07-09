namespace PokemonAnalysisProject.Core.Probability
{
    public static class DrawRateCalculator
    {
        // TODO: Odds of at least 1 copy in your OPENING HAND (7 cards)
        // just call AtLeast(60, copiesInDeck, 7, 1)

        // TODO: Odds of at least 1 copy BY A CERTAIN TURN
        // figure out cardsDrawn first:
        //   cardsDrawn = 7 + how many extra draw steps happened
        //   going first? you skip your turn-1 draw, so draws = turn - 1
        //   going second? you draw every turn, so draws = turn
        // then call AtLeast(60, copiesInDeck, cardsDrawn, 1)
    }
}