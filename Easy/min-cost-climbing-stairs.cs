using System;

public class Solution
{
    public static int MinCostClimbingStairs(int[] cost)
    {
        if (cost == null || cost.Length < 2)
        {
            return 0;
        }

        for (int i = cost.Length - 3; i >= 0; i--)
        {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }

        return Math.Min(cost[0], cost[1]); // Because I can either start from the step with index 0 or 1.
    }

    public static void Main(string[] args)
    {
        int[] cost = { 10, 50 };

        Console.WriteLine(MinCostClimbingStairs(cost));

        Console.ReadKey();
    }
}

