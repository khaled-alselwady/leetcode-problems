using System;
using System.Linq;

public class Solution
{
    public static int LengthOfLIS(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return 1;
        }

        if (nums.Length == 2)
        {
            if (nums[0] < nums[1])
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        int[] dp = Enumerable.Repeat(1, nums.Length).ToArray();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                {
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
            }
        }

        return dp.Max();
    }

    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, 6, 7, 9, 4, 10, 5, 6 };

        Console.WriteLine(LengthOfLIS(nums));

        Console.ReadKey();
    }
}

