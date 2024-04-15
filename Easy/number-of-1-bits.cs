using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(13);

        Console.ReadKey();
    }

    public static int HammingWeight(uint n)
    {
        // Convert the integer to its binary representation as a string, then count each 1 using LINQ
        return Convert.ToString(n, 2).Count(Digit => Digit == '1');
    }
}

