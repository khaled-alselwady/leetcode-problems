using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 2, 3, 4, 5, 6, 7, 1 };
        Console.WriteLine(FindMin(nums));
        Console.WriteLine(FindMin2(nums));

        Console.ReadKey();
    }

    #region Approach 1 (Linear Search)
    public static int FindMin(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        if ((nums.Length == 1) || (nums[0] < nums[nums.Length - 1]))
            return nums[0];

        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            if ((nums[start] <= nums[end]))
                return nums[start];
            else if ((nums[start] > nums[end]))
                start++;
        }

        return 0;
    }
    #endregion

    #region Approach 2 (Binary Search)
    public static int FindMin2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        if ((nums.Length == 1) || (nums[0] < nums[nums.Length - 1]))
            return nums[0];

        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            if ((nums[start] <= nums[end]))
                return nums[start];

            int medium = start + ((end - start) / 2);

            if ((nums[medium] >= nums[start]))
                start = medium + 1;
            else
                end = medium; // we include the medium and don't minus 1 because it could be the answer.
        }

        return 0;
    }
    #endregion
}

