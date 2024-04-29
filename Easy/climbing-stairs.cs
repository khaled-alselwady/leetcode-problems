using System;

public class Solution
{
    private static int _GetFibonacciNumber(int n)
    {
        int prev = 1;
        int curr = 1;
        for (int i = 0; i < n - 1; i++)
        {
            int temp = curr;
            curr += prev;
            prev = temp;
        }

        return curr;
    }

    public static int ClimbStairs(int n)
    {
        if (n < 1 || n > 45)
        {
            return 0;
        }

        return _GetFibonacciNumber(n);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(ClimbStairs(4));

        Console.ReadKey();
    }
}

