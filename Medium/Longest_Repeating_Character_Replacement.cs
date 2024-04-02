using System;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(CharacterReplacement("AABABBA", 1));

        Console.ReadKey();
    }

    public static int CharacterReplacement(string s, int k)
    {
        if (s == null)
            return 0;

        int maxLength = 0, mostFrequentLetterCount = 0, start = 0;
        int[] charCounts = new int[26];

        for (int end = 0; end < s.Length; end++)
        {
            charCounts[s[end] - 'A']++;

            mostFrequentLetterCount = Math.Max(mostFrequentLetterCount, charCounts[s[end] - 'A']);

            int lengthWindow = (end - start + 1);

            if ((lengthWindow - mostFrequentLetterCount) > k)
            {
                // invalid window

                charCounts[s[start] - 'A']--;
                start++; // shrink the window
                lengthWindow--;
            }

            maxLength = Math.Max(maxLength, lengthWindow);
        }

        return maxLength;
    }
}

