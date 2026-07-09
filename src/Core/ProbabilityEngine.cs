namespace PokemonAnalysisProject.Core.Probability
{

    /*

    N = total cards in your deck (60)
    K = how many copies of the card you're looking for are in that deck (e.g. you run 4 copies of Pikachu → K=4)
    n = how many cards you've drawn/seen so far (opening hand = 7, or more if it's a later turn)
    k = how many copies you want to know the odds of seeing (usually "at least 1")
    
    */
    public static class ProbabilityEngine
    {
        // TODO: Write Combinations(n, r) -> "n choose r"
        // Use the multiplicative formula (loop), NOT factorials directly,
        // to avoid overflow with N=60.
        // result = result * (n - i) / (i + 1) for i in [0, r)









        // TODO: Write Pmf(N, K, n, k) -> probability of EXACTLY k successes
        // N = deck size, K = copies of target card in deck,
        // n = cards drawn/seen, k = desired number drawn
        // formula: [C(K,k) * C(N-K, n-k)] / C(N,n)
        // guard: if k > K, k > n, or (n-k) > (N-K) return 0
        
        








        // TODO: Write AtLeast(N, K, n, k) -> probability of k OR MORE successes
        // sum Pmf from i = k to min(K, n)


        







        // TODO: Write None(N, K, n) -> probability of ZERO successes
        // shortcut: just call Pmf(N, K, n, 0)
        // you'll use this constantly (mulligans, combos, "whiff" odds)


        







        // TODO: Test this whole class by hand before building anything on top.
        // Sanity check example: N=60, K=4, n=7 
        // -> compare against an online hypergeometric calculator

        







    }
}