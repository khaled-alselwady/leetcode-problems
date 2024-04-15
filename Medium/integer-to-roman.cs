using System;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IntToRoman_Method3(1994));

        Console.ReadKey();
    }

    public static string IntToRoman_Method1(int num)
    {
        StringBuilder RomanNumber = new StringBuilder();

        while (num > 0)
        {
            if (num >= 1 && num < 5)
            {
                if (num >= 4)
                {
                    RomanNumber.Append("IV");
                    num -= 4;
                }
                else
                {
                    RomanNumber.Append('I');
                    num -= 1;
                }
                continue;
            }
            if (num >= 5 && num < 10)
            {
                if (num >= 9)
                {
                    RomanNumber.Append("IX");
                    num -= 9;
                }
                else
                {
                    RomanNumber.Append('V');
                    num -= 5;
                }
                continue;
            }
            if (num >= 10 && num < 50)
            {
                if (num >= 40)
                {
                    RomanNumber.Append("XL");
                    num -= 40;
                }
                else
                {
                    RomanNumber.Append('X');
                    num -= 10;
                }
                continue;
            }
            if (num >= 50 && num < 100)
            {
                if (num >= 90)
                {
                    RomanNumber.Append("XC");
                    num -= 90;
                }
                else
                {
                    RomanNumber.Append('L');
                    num -= 50;
                }
                continue;
            }
            if (num >= 100 && num < 500)
            {
                if (num >= 400)
                {
                    RomanNumber.Append("CD");
                    num -= 400;
                }
                else
                {
                    RomanNumber.Append('C');
                    num -= 100;
                }
                continue;
            }
            if (num >= 500 && num < 1000)
            {
                if (num >= 900)
                {
                    RomanNumber.Append("CM");
                    num -= 900;
                }
                else
                {
                    RomanNumber.Append('D');
                    num -= 500;
                }
                continue;
            }
            if (num >= 1000)
            {
                RomanNumber.Append('M');
                num -= 1000;

            }
        }

        return RomanNumber.ToString();
    }

    public static string IntToRoman_Method2(int num)
    {
        StringBuilder RomanNumber = new StringBuilder();

        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        for (int i = 0; i < values.Length; i++)
        {
            while (num >= values[i])
            {
                num -= values[i];
                RomanNumber.Append(symbols[i]);
            }
        }

        return RomanNumber.ToString();
    }

    public static string IntToRoman_Method3(int num)
    {
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return (thousands[num / 1000]) + (hundreds[(num % 1000) / 100]) + (tens[(num % 100) / 10]) + (ones[(num % 10)]);
    }
}





