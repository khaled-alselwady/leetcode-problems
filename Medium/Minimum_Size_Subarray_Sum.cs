using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 2, 3, 1, 2, 4, 3 };
        int target = 7;

        Console.WriteLine(MinSubArrayLen2(target, nums));

        Console.ReadKey();
    }

    #region Approach1
    public static int MinSubArrayLen(int target, int[] nums)
    {
        if (nums is null || nums.Length is 0 || target is 0)
            return 0;

        int sum = 0;
        int count = 0;
        SortedSet<int> lengthOfSubArrays = new SortedSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // the length in this case equals 1
            if (nums[i] >= target)
                return 1;

            sum += nums[i];
            count++;

            for (int j = i + 1; j < nums.Length && sum < target; j++)
            {
                sum += nums[j];
                count++;

                if (sum >= target)
                {
                    lengthOfSubArrays.Add(count);

                    if (lengthOfSubArrays.Count > 1)
                        lengthOfSubArrays.Remove(lengthOfSubArrays.Max);
                    break;
                }
            }

            sum = 0;
            count = 0;
        }

        return lengthOfSubArrays.Count is 0 ? 0 : lengthOfSubArrays.Min;
    }
    #endregion

    #region Approach2
    public static int MinSubArrayLen2(int target, int[] nums)
    {
        if (nums is null || nums.Length is 0 || target is 0)
            return 0;

        int currentWindowSum = nums[0];
        int startWindow = 0;
        int minWindowLength = int.MaxValue;

        for (int endWindow = 1; endWindow <= nums.Length; endWindow++)
        {
            // the length in this case equals 1
            if (nums[startWindow] >= target)
                return 1;

            if (endWindow < nums.Length)
                currentWindowSum += nums[endWindow];

            while (currentWindowSum >= target)
            {
                minWindowLength = Math.Min(minWindowLength, (endWindow - startWindow + 1));

                if (minWindowLength is 1)
                    return 1;

                currentWindowSum -= nums[startWindow];
                startWindow++;
            }
        }

        return minWindowLength is int.MaxValue ? 0 : minWindowLength;
    }
    #endregion

    #region Approach3
    public static int MinSubArrayLen3(int target, int[] nums)
    {
        int n = nums.Length;
        int[] preSum = _GetThePrefixSumArray(nums, n);

        int start = 1, end = n, ans = 0;
        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            if (_PerformBinarySearch(mid, nums, target, preSum))
            {
                ans = mid;
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        return ans;
    }

    private static int[] _GetThePrefixSumArray(int[] nums, int n)
    {
        int[] preSum = new int[n + 1];

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            preSum[i] = sum;
        }

        return preSum;
    }

    private static bool _PerformBinarySearch(int mid, int[] nums, int target, int[] presum)
    {
        if (presum[mid - 1] >= target)
            return true;

        for (int i = mid; i < nums.Length; i++)
        {
            if (presum[i] - presum[i - mid] >= target)
                return true;
        }

        return false;
    }
    #endregion
}

