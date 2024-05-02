using System;

public class Solution
{
    public static int Rob(int[] nums)
    {
        if (nums == null || nums.Length < 1)
            return 0;

        int rob1 = 0, rob2 = 0;

        // [rab1, rab2, n, n+1, n+2, ...]
        foreach (int n in nums)
        {
            int temp = Math.Max(rob1 + n, rob2);
            rob1 = rob2;
            rob2 = temp;
        }

        return rob2;
    }

    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 1, 2 };

        Console.WriteLine(Rob(nums));

        Console.ReadKey();
    }
}

