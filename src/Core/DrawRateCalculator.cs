namespace PokemonAnalysisProject.Core.Probability
{
    public static class DrawRateCalculator
    {
        // TODO: Odds of at least 1 copy in your OPENING HAND (7 cards)
        public static double OpeningHandOdds(int copiesInDeck, int deckSize = 60)
        {
            return ProbabilityEngine.AtLeast(deckSize, copiesInDeck, 7, 1);
        }

        // TODO: Odds of at least 1 copy BY A CERTAIN TURN
        public static double OddsByTurn(int copiesInDeck, int turn, bool goingFirst, int deckSize = 60)
        {
            int cardsDrawn = CardsDrawnByTurn(turn, goingFirst);
            return ProbabilityEngine.AtLeast(deckSize, copiesInDeck, cardsDrawn, 1);
        }

        // Helper: how many total cards you've seen by a given turn
        private static int CardsDrawnByTurn(int turn, bool goingFirst)
        {
            // Going first: skip turn-1 draw step, so extra draws = turn - 1
            // Going second: draw every turn, so extra draws = turn
            int extraDraws = goingFirst ? turn - 1 : turn;

            if (extraDraws < 0) 
            {
                extraDraws = 0;
            }

            return 7 + extraDraws;
        }
    }
}