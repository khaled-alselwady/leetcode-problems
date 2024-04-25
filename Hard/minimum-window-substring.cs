using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
        Console.WriteLine(MinWindow2("ADOBECODEBANC", "ABC"));

        Console.ReadKey();
    }

    #region Approach 1 (Brute Force)
    private static bool _IsSubstringIncludingText(string substring, string text)
    {
        if (string.IsNullOrWhiteSpace(substring) ||
            string.IsNullOrWhiteSpace(text) ||
            (substring.Length < text.Length))
        {
            return false;
        }

        for (int i = 0; i < text.Length; i++)
        {
            if (!substring.Contains(text[i].ToString()))
            {
                return false;
            }

            int indexToDelete = substring.IndexOf(text[i]);
            substring = substring.Remove(indexToDelete, 1);
        }

        return true;
    }

    public static string MinWindow(string s, string t)
    {
        if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t) || (s.Length < t.Length))
        {
            return "";
        }

        int startLengthOfWindow = 0;
        int minEndLengthOfWindow = t.Length;
        string windowSubstring = "";
        string result = s + t;
        bool takeNextLetter = true;

        for (int i = startLengthOfWindow; i < s.Length; i++)
        {
            if (takeNextLetter)
            {
                windowSubstring += s[i];
            }

            if (windowSubstring.Length >= minEndLengthOfWindow)
            {
                if (_IsSubstringIncludingText(windowSubstring, t))
                {
                    result = (windowSubstring.Length < result.Length) ? windowSubstring : result;

                    if (result.Length == minEndLengthOfWindow)
                    {
                        return result;
                    }

                    windowSubstring = windowSubstring.Substring(1);
                    i--;
                    takeNextLetter = false;
                }
                else
                {
                    takeNextLetter = true;
                }
            }

        }

        return result == (s + t) ? "" : result;
    }
    #endregion

    #region Approach 2
    public static string MinWindow2(string s, string t)
    {
        if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t) || (s.Length < t.Length))
        {
            return "";
        }

        var countT = InitializeDictionary(t);
        var window = new Dictionary<char, int>();
        int have = 0;
        int need = countT.Count;
        int left = 0;
        int[] result = new[] { -1, -1 };
        int minLength = int.MaxValue;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            AddCharToDictionary(c, window);

            if (countT.ContainsKey(c) && window[c] == countT[c])
            {
                have++;
            }

            while (have == need)
            {
                int windowSize = right - left + 1;
                if (windowSize < minLength)
                {
                    result = new[] { left, right };
                    minLength = windowSize;
                }

                AdjustWindow(s, left, window, countT, ref have);
                left++;
            }
        }

        return minLength == int.MaxValue
            ? string.Empty
            : s.Substring(result[0], result[1] - result[0] + 1);
    }

    private static void AddCharToDictionary(char character, Dictionary<char, int> dict)
    {
        if (dict.ContainsKey(character))
        {
            dict[character]++;
        }
        else
        {
            dict.Add(character, 1);
        }
    }

    private static Dictionary<char, int> InitializeDictionary(string t)
    {
        var countT = new Dictionary<char, int>();
        foreach (char c in t)
        {
            AddCharToDictionary(c, countT);
        }
        return countT;
    }

    // Function to adjust the sliding window
    private static void AdjustWindow(string s, int left, Dictionary<char, int> window, Dictionary<char, int> countT, ref int have)
    {
        window[s[left]]--;
        if (countT.ContainsKey(s[left]) && window[s[left]] < countT[s[left]])
        {
            have--;
        }
    }
    #endregion
}

