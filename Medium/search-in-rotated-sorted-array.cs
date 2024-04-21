using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 3, 1 };
        Console.WriteLine(Search(nums, 1));

        Console.ReadKey();
    }

    public static int Search(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int medium = left + ((right - left) / 2);

            if (nums[medium] == target)
                return medium;

            // Left Sorted Portion
            else if (nums[medium] >= nums[left])
            {
                if (target < nums[medium] && target >= nums[left])
                    right = medium - 1;
                else
                    left = medium + 1;
            }

            // Right Sorted Portion
            else
            {
                if (target > nums[medium] && target <= nums[right])
                    left = medium + 1;
                else
                    right = medium - 1;
            }

        }

        return -1;
    }
}

