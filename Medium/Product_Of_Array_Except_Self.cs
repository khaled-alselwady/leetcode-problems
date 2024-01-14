using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4 };

        int[] nums2 = ProductExceptSelf_Method2(nums);

        foreach (int num in nums2)
            Console.Write(num + " ");

        Console.ReadKey();
    }

    public static int[] ProductExceptSelf_Method1(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null;

        if (nums.Length == 1)
            return nums;

        int[] PrefixProduct = new int[nums.Length];

        PrefixProduct[0] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            PrefixProduct[i] = PrefixProduct[i - 1] * nums[i - 1];
        }

        int[] SuffixProduct = new int[nums.Length];
        SuffixProduct[nums.Length - 1] = 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            SuffixProduct[i] = SuffixProduct[i + 1] * nums[i + 1];
        }

        int[] Result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            Result[i] = PrefixProduct[i] * SuffixProduct[i];
        }

        return Result;
    }

    public static int[] ProductExceptSelf_Method2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null;

        if (nums.Length == 1)
            return nums;

        int[] Result = new int[nums.Length];
        Result[0] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            Result[i] = Result[i - 1] * nums[i - 1];
        }

        int SuffixProduct = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            Result[i] *= SuffixProduct;
            SuffixProduct *= nums[i];
        }

        return Result;
    }

}