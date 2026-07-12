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
        public static double Combinations(int n, int r)
        {
            if (r < 0 || r > n) 
                return 0.0;


            if (r == 0 || r == n) 
                return 1.0;


            if (r > n - r) 
                r = n - r;

            double result = 1.0;
            for (int i = 0; i < r; i++)
            {
                result = result * (n - i) / (i + 1);
            }

            return result;
        }
        // TODO: Write Pmf(N, K, n, k) -> probability of EXACTLY k successes
        public static double Pmf(int N, int K, int n, int k)
        {
            
            if (k > K) 
                return 0.0;
            if (k > n) 
                return 0.0;
            if ((n - k) > (N - K)) 
                return 0.0;
            if (k < 0 || n < 0 || N < 0 || K < 0) 
                return 0.0;
            if (n > N) 
                return 0.0;

            double numerator = Combinations(K, k) * Combinations(N - K, n - k);
            double denominator = Combinations(N, n);

            if (denominator == 0.0) 
                return 0.0;

            return numerator / denominator;
        }

        // TODO: Write AtLeast(N, K, n, k) -> probability of k OR MORE successes
        public static double AtLeast(int N, int K, int n, int k)
        {
            double total = 0.0;
            int upperBound = System.Math.Min(K, n);

            for (int i = k; i <= upperBound; i++)
            {
                total += Pmf(N, K, n, i);
            }

            return total;
        }
        // TODO: Write None(N, K, n) -> probability of ZERO successes
        // Probability of ZERO successes (mulligans)
        public static double None(int N, int K, int n)
        {
            return Pmf(N, K, n, 0);
        }
    }
}