using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 3, 1, 3, 4, 2 };

        Console.WriteLine(FindDuplicate(nums));

        Console.ReadKey();
    }

    public static int FindDuplicate(int[] nums)
    {
        if (nums == null || nums.Length < 2)
            return -1;

        int Slow = nums[0];
        int Fast = nums[0];

        do
        {
            Slow = nums[Slow];
            Fast = nums[nums[Fast]];
        } while (Slow != Fast);

        Fast = nums[0];

        while (Slow != Fast)
        {
            Slow = nums[Slow];
            Fast = nums[Fast];
        }

        return Slow;
    }

}

