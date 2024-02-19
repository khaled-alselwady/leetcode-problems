using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 0, 1, 1 };

        Console.WriteLine(ContainsNearbyDuplicate_Method1(nums, 1));

        Console.ReadKey();
    }

    public static bool ContainsNearbyDuplicate_Method1(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            return false;

        if (nums.Length == 1 && k > 0)
            return false;

        Dictionary<int, int> NumberMapsIndex = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {

            if (!NumberMapsIndex.ContainsKey(nums[i]))
            {
                NumberMapsIndex.Add(nums[i], i);
            }
            else
            {
                if (Math.Abs(NumberMapsIndex[nums[i]] - i) <= k)
                    return true;
                else
                    NumberMapsIndex[nums[i]] = i; // update the index
            }
        }


        return false;

    }

    public static bool ContainsNearbyDuplicate_Method2(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            return false;

        if (nums.Length == 1 && k > 0)
            return false;

        HashSet<int> SeenNumbers = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (SeenNumbers.Contains(nums[i]))
                return true;

            SeenNumbers.Add(nums[i]);

            if (SeenNumbers.Count > k)
                SeenNumbers.Remove(nums[i - k]);
        }

        return false;
    }

}

