using System;


public class Solution
{
    public static void Main(string[] args)
    {
        int x = 1463847412;

        Console.WriteLine(Reverse(x));

        Console.ReadKey();
    }

    public static int Reverse(int x)
    {        
        int ReverseNumber = 0;
        sbyte CurrentDigit = 0;

        while (x != 0)
        {
            CurrentDigit = (sbyte)(x % 10);
            x /= 10;

            // Check for overflow before appending the current digit to the result
            if (ReverseNumber > int.MaxValue / 10 || (ReverseNumber == int.MaxValue / 10 && CurrentDigit > 7)) return 0;
            if (ReverseNumber < int.MinValue / 10 || (ReverseNumber == int.MinValue / 10 && CurrentDigit < -8)) return 0;

            ReverseNumber = (ReverseNumber * 10) + CurrentDigit;
        }

        return ReverseNumber;
    }
}





