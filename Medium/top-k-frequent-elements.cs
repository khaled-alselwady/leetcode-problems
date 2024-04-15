using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 3, 1, 2, 3, 2, 1, 4, 4, 5 };

        int[] nums2 = TopKFrequent_Method1(nums, 4);

        foreach (int num in nums2)
            Console.Write(num + " ");

        Console.ReadKey();
    }

    public static int[] TopKFrequent_Method1(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            return null;

        if (nums.Length == 1)
            return nums;

        int[] result = new int[k];

        Dictionary<int, int> dicFrequentItems = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            dicFrequentItems.TryGetValue(num, out int Count);
            dicFrequentItems[num] = Count + 1;
        }

        int MaxValue = 0;
        for (int i = 0; i < k && dicFrequentItems.Count != 0; i++)
        {
            KeyValuePair<int, int> maxItem = dicFrequentItems.First();

            foreach (var kvp in dicFrequentItems)
            {
                if (kvp.Value > maxItem.Value)
                    maxItem = kvp;
            }

            result[i] = maxItem.Key;

            dicFrequentItems.Remove(maxItem.Key);
        }

        return result;
    }

    public static int[] TopKFrequent_Method2(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            return null;

        if (nums.Length == 1)
            return nums;

        Dictionary<int, int> dicFrequentNumbers = new Dictionary<int, int>();
        List<int>[] arrLstFrequent = new List<int>[nums.Length + 1];

        for (int i = 0; i < arrLstFrequent.Length; i++)
        {
            arrLstFrequent[i] = new List<int>();
        }

        foreach (int num in nums)
        {
            dicFrequentNumbers.TryGetValue(num, out int Count);
            dicFrequentNumbers[num] = Count + 1;
        }

        foreach (var Item in dicFrequentNumbers)
        {
            // The index of the array represents the number of times the key is repeated :)
            arrLstFrequent[Item.Value].Add(Item.Key);
        }

        int[] Result = new int[k];
        int Index = 0;
        for (int i = arrLstFrequent.Length - 1; i > 0 && Index < k; i--)
        {

            foreach (int Number in arrLstFrequent[i])
            {
                Result[Index++] = Number;

                if (Index == k)
                    return Result;
            }

        }

        return Result;
    }

}





