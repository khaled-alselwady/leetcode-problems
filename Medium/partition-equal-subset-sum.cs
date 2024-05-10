using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private static bool _IsOdd(int num) => (num % 2 != 0);

    private static bool _IsThereSubsetContainsTheTarget(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
        {
            return false;
        }

        HashSet<int> dp = new HashSet<int>();
        dp.Add(0);

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            HashSet<int> nextDP = new HashSet<int>();
            foreach (int t in dp)
            {
                if (t + nums[i] == target)
                {
                    return true;
                }

                nextDP.Add(t + nums[i]);
                nextDP.Add(t);
            }

            dp = nextDP;
        }

        return dp.Max() == target;
    }

    public static bool CanPartition(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return false;
        }

        int totalAll = nums.Sum();

        if (_IsOdd(totalAll))
        {
            return false;
        }

        if (nums.Length == 2)
        {
            return (nums[0] == nums[1]);
        }

        return _IsThereSubsetContainsTheTarget(nums, totalAll / 2);
    }

    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

        Console.WriteLine(CanPartition(nums));

        Console.ReadKey();
    }
}

