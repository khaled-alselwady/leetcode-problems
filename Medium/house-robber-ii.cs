using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private static int _RobHelper(IEnumerable<int> collection)
    {
        if (collection == null || collection.Count() == 0)
            return 0;

        int rob1 = 0;
        int rob2 = 0;

        foreach (int n in collection)
        {
            int temp = Math.Max(rob1 + n, rob2);
            rob1 = rob2;
            rob2 = temp;
        }

        return rob2;
    }

    public static int Rob(int[] nums)
    {
        if (nums == null || nums.Length < 1)
            return 0;

        if (nums.Length <= 3) // when array is like this {1, 2, 3} , of course the result will be the max of them, because I can't rob the first and last houses
            return nums.Max();

        int maxRobWithoutLastHouse = _RobHelper(nums.Take(nums.Length - 1)); // take all the items but the last one
        int maxRobWithoutFirstHouse = _RobHelper(nums.Skip(1)); // take all the items but the first one

        return Math.Max(maxRobWithoutFirstHouse, maxRobWithoutLastHouse);
    }

    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3 };

        Console.WriteLine(Rob(nums));

        Console.ReadKey();
    }
}

