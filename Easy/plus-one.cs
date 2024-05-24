using System.Numerics;

public class Solution
{
    #region First Approach
    private static BigInteger _ConvertToNumber(int[] digits)
    {
        if (digits is null || digits.Length == 0)
        {
            return 0;
        }

        BigInteger result = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            result = (result * 10) + digits[i];
        }

        return result;
    }

    private static int[] _ConvertToArray(BigInteger number)
    {
        List<int> digits = new();

        while (number > 0)
        {
            byte remainder = (byte)(number % 10);
            number /= 10;

            digits.Add(remainder);
        }

        digits.Reverse();
        return digits.ToArray();
    }

    public static int[] PlusOne(int[] digits)
    {
        if (digits is null || digits.Length == 0)
        {
            return [];
        }

        int[] result = [];

        BigInteger number = _ConvertToNumber(digits);
        number++;

        result = _ConvertToArray(number);

        return result;
    }
    #endregion

    #region Second Approach
    public static int[] PlusOne2(int[] digits)
    {
        if (digits is null || digits.Length == 0)
        {
            return [];
        }

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;

                return digits;
            }

            digits[i] = 0;
        }

        int[] result = new int[digits.Length + 1];

        result[0] = 1;

        return result;
    }
    #endregion

    static void Main()
    {
        int[] digits = [1, 9, 9, 9];

        Console.WriteLine(string.Join(", ", digits));

        int[] result = PlusOne(digits);
        int[] result2 = PlusOne2(digits);

        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine(string.Join(", ", result2));
    }
}

