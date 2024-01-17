using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 101, 102, 103, 1, 2, 3, 104, 105, 106, 4, 5, 6, 7 };

        Console.WriteLine(LongestConsecutive(nums));

        Console.ReadKey();
    }

    public static int LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        if (nums.Length == 1)
            return 1;

        HashSet<int> setNumbers = new HashSet<int>(nums);

        int MaxLength = 0;
        int CurrentLength = 1;

        foreach (int Number in nums)
        {
            // check if the Number is not the start of a sequence
            if (setNumbers.Contains(Number - 1))
                continue;

            CurrentLength = 1;

            while (setNumbers.Contains(Number + CurrentLength))
                CurrentLength++;

            MaxLength = Math.Max(MaxLength, CurrentLength);

            // if the CurrentLength is greater than the Length of Array, so of course this is the Longest Consecutive
            if (CurrentLength > nums.Length / 2)
                break;
        }

        return MaxLength;
    }
}