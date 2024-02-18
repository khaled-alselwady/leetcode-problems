using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, 5, 1, 4, 2 };
   
        Console.WriteLine(MajorityElement_Method1(nums));

        Console.ReadKey();
    }

    #region Method 1
    private static int _GetMaximumValueInDictionary(Dictionary<int, int> dictionary)
    {
        int MaxRepeatedValue = dictionary.First().Value;

        foreach (var KeyValue in dictionary)
        {
            if (KeyValue.Value > MaxRepeatedValue)
                MaxRepeatedValue = KeyValue.Value;
        }

        return MaxRepeatedValue;
    }

    private static int _GetMajorityElementInDictionary(Dictionary<int, int> dictionary)
    {
        if (dictionary == null || dictionary.Count == 0)
            return 0;

        int MaxRepeatedValue = _GetMaximumValueInDictionary(dictionary);

        return dictionary.FirstOrDefault(kvp => kvp.Value == MaxRepeatedValue).Key;
    }

    private static Dictionary<int, int> _CountHowManyAreElementsRepeated(int[] nums)
    {
        Dictionary<int, int> RepeatedNumbers = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (!RepeatedNumbers.ContainsKey(num))
            {
                RepeatedNumbers.Add(num, 0);
            }

            RepeatedNumbers[num]++;
        }

        return RepeatedNumbers;
    }

    public static int MajorityElement_Method1(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        Dictionary<int, int> RepeatedNumbers = _CountHowManyAreElementsRepeated(nums);

        return _GetMajorityElementInDictionary(RepeatedNumbers);
    }
    #endregion

    #region Method 2
    private static int _GetMajorityElement(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        int Majority = 0;
        int Result = 0;

        Dictionary<int, int> RepeatedNumbers = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (!RepeatedNumbers.ContainsKey(num))
                RepeatedNumbers.Add(num, 0);

            if (RepeatedNumbers[num] > Majority)
            {
                Majority = RepeatedNumbers[num];
                Result = num;
            }

            RepeatedNumbers[num]++;
        }

        return Result;
    }

    public static int MajorityElement_Method2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        return _GetMajorityElement(nums);
    }
    #endregion
}

