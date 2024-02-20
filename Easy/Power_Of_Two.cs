using System;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsPowerOfTwo_Method1(8));

        Console.ReadKey();
    }

    public static bool IsPowerOfTwo_Method1(int n)
    {
        if (n == 0)
            return false;

        if (n >= int.MaxValue || n <= int.MinValue)
            return false;

        return (n & (n - 1)) == 0;
    }

    public static bool IsPowerOfTwo_Method2(int n)
    {
        if (n == 0)
            return false;

        double result = Math.Round(Math.Log(n, 2));

        return Math.Pow(2, result) == n;       
    }
}

