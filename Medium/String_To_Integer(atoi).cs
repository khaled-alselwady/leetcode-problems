using System;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        string s = "-2147483649";

        Console.WriteLine(MyAtoi(s));

        Console.ReadKey();
    }

    public static int MyAtoi(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        StringBuilder sb = new StringBuilder(s.Trim());

        bool IsPositive = true;
        byte Index = 0;

        if (Index < sb.Length && (sb[Index] == '+' || sb[Index] == '-'))
        {
            IsPositive = (sb[Index] == '+');
            Index++;
        }

        int Number = 0;

        for (; Index < sb.Length; Index++)
        {
            if (!char.IsDigit(sb[Index]))
                break;

            // The current digit is => (sb[Index] - '0')

            if (IsPositive)
            {
                if (Number > int.MaxValue / 10 ||
                    (Number == int.MaxValue / 10 && (sb[Index] - '0') > 7))
                    return int.MaxValue;
            }
            else
            {
                if ((Number * -1) < int.MinValue / 10 ||
                    ((Number * -1) == int.MinValue / 10 && ((sb[Index] - '0') * -1) < -8))
                    return int.MinValue;
            }

            Number = Number * 10 + (sb[Index] - '0');
        }

        return (IsPositive) ? (Number) : (Number * -1);
    }
}





