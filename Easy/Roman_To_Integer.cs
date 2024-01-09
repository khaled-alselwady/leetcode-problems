using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(RomanToInt("CDXLIV"));

        Console.ReadKey();
    }

    public static int RomanToInt(string s)
    {
        if (s == null || s.Length > 15)
            return 0;

        short Sum = 0;
        Dictionary<char, short> RomanKeyValue = new Dictionary<char, short>
        {
            {'I',1 },
            { 'V',5},
            { 'X',10},
            { 'L',50},
            { 'C',100},
            { 'D',500},
            { 'M',1000}
        };

        for (byte i = 0; i < s.Length; i++)
        {
            if (_IsInvalidSubtractivePair(s, i))
                return 0;

            if (_IsSubtractivePair(s, i))
            {
                Sum += (short)(RomanKeyValue[s[i + 1]] - RomanKeyValue[s[i]]);
                i++;
            }
            else
            {
                Sum += RomanKeyValue[s[i]];
            }
        }

        return Sum;
    }

    private static bool _IsSubtractivePair(string s, byte Index)
    {
        if (Index + 1 < s.Length)
        {
            char Current = s[Index];
            char Next = s[Index + 1];

            return ((Current == 'I' && (Next == 'V' || Next == 'X')) ||
                    (Current == 'X' && (Next == 'L' || Next == 'C')) ||
                    (Current == 'C' && (Next == 'D' || Next == 'M')));
        }

        return false;
    }

    private static bool _IsInvalidSubtractivePair(string s, byte index)
    {
        if (index + 1 < s.Length)
        {
            char current = s[index];
            char next = s[index + 1];

            // Check for specific invalid subtractive pairs (e.g., "IL" and "XD")
            return (current == 'I' && (next == 'L' || next == 'C')) ||
                   (current == 'X' && (next == 'D' || next == 'M'));
        }

        return false;
    }
}





