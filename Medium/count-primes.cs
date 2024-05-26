public class Solution
{
    #region First Approach (Using Helper Function)
    private static bool _IsPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }

        if (n == 2 || n == 3)
        {
            return true;
        }

        if (n % 2 == 0 || n % 3 == 0)
        {
            return false;
        }

        for (int i = 5; i * i <= n; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static int CountPrimes(int n)
    {
        if (n <= 1)
        {
            return 0;
        }

        int counter = 0;
        for (int i = 2; i < n; i++)
        {
            if (_IsPrime(i))
            {
                counter++;
            }
        }

        return counter;
    }
    #endregion

    #region Second Approach (Using Sieve of Eratosthenes)
    public static int CountPrimes2(int n)
    {
        // If n is less than or equal to 2, there are no prime numbers less than 2
        if (n <= 2)
        {
            return 0;
        }

        // Create a boolean array to track prime numbers
        // true means the number is prime, false means it is not
        bool[] primes = Enumerable.Repeat(true, n).ToArray();
        primes[0] = primes[1] = false;

        // Implement the Sieve of Eratosthenes
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            // If primes[i] is true, then i is a prime number
            if (primes[i])
            {
                // Mark all multiples of i as non-prime
                // Start from i * i to avoid redundant operations
                for (int j = i * i; j < n; j += i)
                {
                    primes[j] = false;
                }
            }
        }

        // Count the number of true values in the primes array
        // Each true value corresponds to a prime number
        return primes.Count(p => p);
    }
    #endregion

    static void Main()
    {
        Console.WriteLine(CountPrimes2(3));
    }
}

