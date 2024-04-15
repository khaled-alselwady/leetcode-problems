using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { -1, 0, 3, 5, 9, 12, 14 };

        Console.WriteLine(Search(nums, 14));

        Console.ReadKey();
    }

    public static int Search(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            int medium = start + ((end - start) / 2); // ((end - start) / 2) ===> gives the medium of the current range, so I have to add (start) to it to add the rest of the array and get the correct medium

            if (nums[medium] == target)
                return medium;
            else if (nums[medium] > target)
                end = medium - 1;
            else
                start = medium + 1;
        }

        return -1;
    }
}

