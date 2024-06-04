public class Solution
{
    #region Approach 1 [O(n^2)]
    public static int SumDigitInNumber(string num, int digitToSearch)
    {
        int counter = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int currentDigit = num[i] - '0';

            if (currentDigit == digitToSearch)
            {
                counter++;
            }
        }

        return counter;
    }

    public static bool DigitCount(string num)
    {
        if (string.IsNullOrWhiteSpace(num))
        {
            return false;
        }

        for (int i = 0; i < num.Length; i++)
        {
            int currentDigit = num[i] - '0';
            if (currentDigit != SumDigitInNumber(num, i))
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Approach 2 [O(n)]
    private static Dictionary<int, int> _FillDictionaryWithCountDigits(string num)
    {
        Dictionary<int, int> digitCounts = new Dictionary<int, int>();

        for (int i = 0; i < num.Length; i++)
        {
            int digit = num[i] - '0';

            if (!digitCounts.TryAdd(digit, 1))
            {
                digitCounts[num[i] - '0']++;
            }
        }

        return digitCounts;
    }

    public static bool DigitCount2(string num)
    {
        if (string.IsNullOrWhiteSpace(num))
        {
            return false;
        }

        Dictionary<int, int> digitCounts = _FillDictionaryWithCountDigits(num);

        // Check if each digit count matches the digit in the corresponding position
        for (byte i = 0; i < num.Length; i++)
        {
            int expectedCount = num[i] - '0'; // The digit at position i

            if (digitCounts.ContainsKey(i))
            {
                int actualCount = digitCounts[i];
                if (actualCount != expectedCount)
                {
                    return false;
                }
            }
            else
            {
                if (expectedCount != 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion

    static void Main()
    {
        Console.WriteLine(DigitCount("1210"));
        Console.WriteLine(DigitCount2("1210"));
    }
}

