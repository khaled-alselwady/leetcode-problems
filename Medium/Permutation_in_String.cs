using System;
using System.Linq;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(CheckInclusion("adc", "danccda"));
        Console.WriteLine(CheckInclusion2("adc", "danccda"));

        Console.ReadKey();
    }

    #region Approach 1 (Brute Force)
    private static bool _IsTwoStringPermutation(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        StringBuilder sb1 = new StringBuilder(s1);

        for (int i = 0; i < s2.Length; i++)
        {
            int indexToDelete = sb1.ToString().IndexOf(s2[i]);

            if (indexToDelete == -1) // If the current character is not found in s1
                return false;

            sb1.Remove(indexToDelete, 1); // Remove the character from sb1
        }

        return true;
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        if (s1 == s2)
            return true;

        int end = 0;

        StringBuilder sbWindow = new StringBuilder();

        for (end = 0; end < s1.Length; end++)
            sbWindow.Append(s2[end]);

        for (; end <= s2.Length; end++)
        {
            if (sbWindow.Length == s1.Length)
            {
                if (_IsTwoStringPermutation(s1, sbWindow.ToString()))
                    return true;
                else
                {
                    sbWindow.Remove(0, 1);

                    if (end <= s2.Length - 1)
                        sbWindow.Append(s2[end]);
                }
            }

        }

        return false;
    }
    #endregion

    #region Approach 2
    public static bool CheckInclusion2(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;
        if (s1 == s2) return true;

        int[] s1Count = Enumerable.Repeat(0, 26).ToArray();
        int[] s2Count = Enumerable.Repeat(0, 26).ToArray();

        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        byte matches = 0;
        for (byte i = 0; i < 26; i++)
            if (s1Count[i] == s2Count[i]) matches++;

        int left = 0;
        for (int right = s1.Length; right < s2.Length; right++)
        {
            if (matches == 26) return true;

            int index = s2[right] - 'a'; ;
            s2Count[index]++;
            matches = _UpdateCountOfMatchesWhenAddingItemToWindow(s1Count, s2Count, matches, index);

            index = s2[left] - 'a';
            s2Count[index]--;
            matches = _UpdateCountOfMatchesWhenRemovingItemFromWindow(s1Count, s2Count, matches, index);

            left++;
        }

        return (matches == 26);
    }

    private static byte _UpdateCountOfMatchesWhenRemovingItemFromWindow(int[] s1Count, int[] s2Count, byte matches, int index)
    {
        if (s1Count[index] == s2Count[index])
            matches++;
        else if (s1Count[index] - 1 == s2Count[index])
            matches--;
        return matches;
    }

    private static byte _UpdateCountOfMatchesWhenAddingItemToWindow(int[] s1Count, int[] s2Count, byte matches, int index)
    {
        if (s1Count[index] == s2Count[index])
            matches++;
        else if (s1Count[index] + 1 == s2Count[index])
            matches--;
        return matches;
    }
    #endregion
}

