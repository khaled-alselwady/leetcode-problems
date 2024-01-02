using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string OriginalText = "pwwkew";

        Console.WriteLine(LengthOfLongestSubstring(OriginalText));

        Console.ReadKey();
    }

    public static int LengthOfLongestSubstring(string s)
    {
        if (s == null || s.Length == 0)
            return 0;

        int Start = 0; // Start pointer
        int End = 0;   // End pointer
        int MaxLength = 0;

        HashSet<char> CharSet = new HashSet<char>();

        while (End < s.Length)
        {
            if (!CharSet.Contains(s[End]))
            {
                // Expand the window
                CharSet.Add(s[End]);
                End++;
                MaxLength = Math.Max(MaxLength, End - Start);
            }
            else
            {
                // Shrink the window
                CharSet.Remove(s[Start]);
                Start++;
            }
        }

        return MaxLength;
    }

}


