using System;
using System.Linq;

public class Solution
{
    private static int[] _InitializeDP(int amount)
    {
        // Set an impossible value for all amounts to indicate they haven't been solved yet
        int[] dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();

        dp[0] = 0; // No coins are needed to make 0
        return dp;
    }

    private static void _CalculateMinCoins(int[] coins, int[] dp)
    {
        for (int i = 1; i < dp.Length; i++)
        {
            foreach (int coin in coins)
            {
                if (i >= coin) // equals to (i - coin >= 0)
                {
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
        }
    }

    private static int _GetCoinChangeResult(int[] dp, int amount)
    {
        return (dp[amount] > amount) ? -1 : dp[amount];
    }

    public static int CoinChange(int[] coins, int amount)
    {
        if (coins == null || coins.Length == 0)
        {
            return -1;
        }

        if (amount == 0)
        {
            return 0;
        }

        int[] dp = _InitializeDP(amount);
        _CalculateMinCoins(coins, dp);   // Calculate the minimum coins for each amount
        return _GetCoinChangeResult(dp, amount);
    }

    public static void Main(string[] args)
    {
        int[] coins = { 1, 6, 7, 9, 11 };

        Console.WriteLine(CoinChange(coins, 13));

        Console.ReadKey();
    }
}

