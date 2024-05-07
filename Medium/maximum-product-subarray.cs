using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    #region Approach 1 (Brute Force)
    private static int _GetMaxProductOfArray(IEnumerable<int> nums)
    {
        if (nums == null || nums.Count() == 0)
        {
            return 0;
        }

        if (nums.Count() == 1)
        {
            return nums.FirstOrDefault();
        }

        //int maxProduct = 1;
        //foreach (int num in nums)
        //{
        //    maxProduct *= num;
        //}

        return nums.Aggregate(1, (acc, x) => acc * x);
    }
    public static int MaxProduct(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        int maxProduct = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j <= nums.Length; j++)
            {
                maxProduct = Math.Max(maxProduct, _GetMaxProductOfArray(nums.Skip(i).Take(j - i)));
            }
        }

        return maxProduct;
    }
    #endregion

    #region Approach 2 (Dynamic Programming)
    public static int MaxProduct2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        (int currMax, int currMin) = (1, 1);
        int maxProduct = nums.Max();

        foreach (int num in nums)
        {
            int tempMax = currMax;

            currMax = Math.Max(Math.Max(currMax * num, currMin * num), num);
            currMin = Math.Min(Math.Min(tempMax * num, currMin * num), num);

            maxProduct = Math.Max(maxProduct, currMax);
        }

        return maxProduct;
    }
    #endregion

    public static void Main(string[] args)
    {
        int[] nums = { 2, -3, -2, 4 };

        Console.WriteLine(MaxProduct(nums));
        Console.WriteLine(MaxProduct2(nums));

        Console.ReadKey();
    }
}

