using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        IList<IList<int>> lstResult = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });

        foreach (IList<int> lst in lstResult)
        {

            Console.Write("[" + string.Join(", ", lst) + "]");
            Console.Write("  ");

        }

        Console.WriteLine();

        Console.ReadKey();
    }

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        if (nums == null || nums.Length < 3)
            return new List<IList<int>>();

        Array.Sort(nums);

        IList<IList<int>> Result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue; // Skip duplicates

            IList<IList<int>> TwoSumResult = TwoSum(nums, i + 1, -nums[i]);

            foreach (var lst in TwoSumResult)
            {
                lst.Insert(0, nums[i]);
                Result.Add(lst);
            }
        }

        return Result;
    }

    public static IList<IList<int>> TwoSum(int[] nums, int Start, int Target)
    {
        IList<IList<int>> Result = new List<IList<int>>();
        int End = nums.Length - 1;

        while (Start < End)
        {
            if (nums[Start] + nums[End] == Target)
            {
                Result.Add(new List<int> { nums[Start], nums[End] });

                while (Start < End && nums[Start] == nums[Start + 1]) Start++;
                while (Start < End && nums[End] == nums[End - 1]) End--;

                Start++;
                End--;
            }
            else if (nums[Start] + nums[End] > Target)
            {
                End--;
            }
            else
            {
                Start++;
            }
        }

        return Result;
    }
}

