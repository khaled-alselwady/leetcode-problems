using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, 4, 2, 4 };

        Console.WriteLine(ContainsDuplicate_Method3(nums));
        Console.ReadKey();
    }

    public static bool ContainsDuplicate_Method1(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return false;

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (((i + 1) < nums.Length) && (nums[i] == nums[i + 1]))
                return true;
        }

        return false;
    }

    public static bool ContainsDuplicate_Method2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return false;

        HashSet<int> setNumbers = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!setNumbers.Add(nums[i]))
                return true;
        }

        return false;
    }

    public static bool ContainsDuplicate_Method3(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return false;

        Dictionary<int, short> occurrences = new Dictionary<int, short>();

        foreach (int num in nums)
        {
            if (occurrences.TryGetValue(num, out short count))
            {
                if (++count > 1)
                    return true;
            }
            else
            {
                occurrences[num] = 1;
            }
        }

        return false;
    }

}





