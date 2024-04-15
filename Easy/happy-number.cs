using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsHappy(100));

        Console.ReadKey();
    }

    private static int _GetSumSquaresDigitsOfNumber(int Number)
    {
        int Sum = 0;

        byte Remainder = 0;

        while (Number > 0)
        {
            Remainder = (byte)(Number % 10);
            Number /= 10;

            Sum += (Remainder * Remainder);
        }

        return Sum;
    }

    private static bool _IsNumberExistInHashSet(HashSet<int> Result, int NumberToSearch)
        => Result.Contains(NumberToSearch);

    public static bool IsHappy(int Number)
    {
        if (Number <= 0)
            return false;

        HashSet<int> SeenNumbers = new HashSet<int>();

        int SumSquaresDigits = Number;

        do
        {
            SumSquaresDigits = _GetSumSquaresDigitsOfNumber(SumSquaresDigits);

            if (SumSquaresDigits == 1)
                return true;

            if (_IsNumberExistInHashSet(SeenNumbers, SumSquaresDigits))
                return false;

            SeenNumbers.Add(SumSquaresDigits);

        } while (SumSquaresDigits != 1);

        return true;
    }
}

