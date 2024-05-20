using System;

public class Solution
{
    private static int[] _FibonacciSeries(int n)
    {
        if (n == 0)
        {
            return null;
        }

        if (n == 1)
        {
            return new int[] { 1 };
        }

        int[] result = new int[n];
        result[0] = 0;
        result[1] = 1;

        int num1 = 0;
        int num2 = 1;

        for (int i = 2; i < n; i++)
        {
            int sum = num1 + num2;
            num1 = num2;
            num2 = sum;

            result[i] = sum;
        }

        return result;
    }

    public static int Fib(int n)
    {
        int[] result = _FibonacciSeries(n);

        if (result == null || result.Length == 0)
        {
            return 0;
        }

        if (result.Length >= 2)
        {
            return result[result.Length - 1] + result[result.Length - 2];
        }
        else
        {
            return result[result.Length - 1];
        }
    }

    public static void Main(string[] args)
    {
        int[] result = _FibonacciSeries(2);

        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine(Fib(2));

        Console.ReadKey();
    }
}

