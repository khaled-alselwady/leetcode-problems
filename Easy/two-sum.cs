using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 2, 7, 15, 11, 7 };

        int[] arrTowSum = TwoSum(nums, 14);

        Console.WriteLine($"[{arrTowSum[0]}, {arrTowSum[1]}]");

        Console.ReadKey();
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return null;

        Dictionary<int, int> numIndices = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (numIndices.ContainsKey(target - nums[i]))
                return new int[] { numIndices[target - nums[i]], i };

            if (!numIndices.ContainsKey(nums[i]))
                numIndices[nums[i]] = i;
        }

        return null;
    }

}





