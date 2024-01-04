using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


public class Solution
{
    public static void Main(string[] args)
    {
        string OriginalText = "aabbadfbbaabb";

        Console.WriteLine(LongestPalindromeMethod1(OriginalText));

        Console.ReadKey();
    }

    private static bool _IsAlphanumeric(string input)
    {
        // Regular expression pattern for alphanumeric characters
        string pattern = "^[a-zA-Z0-9]+$";

        // Check if the input matches the pattern
        return Regex.IsMatch(input, pattern);
    }

    private static bool _IsSubstringPalindromic(StringBuilder sbText)
    {
        for (short i = 0; i < (sbText.Length / 2); i++)
        {
            if (sbText[i] != sbText[sbText.Length - i - 1])
                return false;
        }

        return true;
    }

    private static string _GetLongestPalindromicSubstringInDictionary(Dictionary<string, short> PalindromicSubstringWithLength)
    {
        if (PalindromicSubstringWithLength.Count == 0)
            return null;

        short MaxKey = 0;
        StringBuilder sbLongestPalindromicSubstring = new StringBuilder();

        foreach (var PalindromicSubstring in PalindromicSubstringWithLength)
        {
            if (PalindromicSubstring.Value > MaxKey)
            {
                sbLongestPalindromicSubstring.Clear();

                MaxKey = PalindromicSubstring.Value;
                sbLongestPalindromicSubstring.Append(PalindromicSubstring.Key);
            }
        }

        return sbLongestPalindromicSubstring.ToString();
    }

    public static string LongestPalindromeMethod1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return null;

        if (s.Length > 1000)
            return s[0].ToString();

        if (!_IsAlphanumeric(s))
            return null;

        if (s.Length == 1)
            return s;

        StringBuilder sbText = new StringBuilder();
        StringBuilder sbTemp = new StringBuilder(s);

        Dictionary<string, short> PalindromicSubstringWithLength = new Dictionary<string, short>();

        while (sbTemp.Length > 0)
        {
            foreach (char Character in sbTemp.ToString())
            {
                sbText.Append(Character);

                if ((sbText.Length > 1) && _IsSubstringPalindromic(sbText))
                {
                    PalindromicSubstringWithLength[sbText.ToString()] = (short)sbText.Length;
                }
            }

            sbTemp = sbTemp.Remove(0, 1);
            sbText.Clear();
        }

        return _GetLongestPalindromicSubstringInDictionary(PalindromicSubstringWithLength) ?? s[0].ToString();
    }

    public static string LongestPalindromeMethod2(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > 1000 || !_IsAlphanumeric(s))
            return null;

        int start = 0, maxLength = 1;
        int n = s.Length;

        bool[,] dp = new bool[n, n];

        // All substrings of length 1 are palindromes
        for (int i = 0; i < n; i++)
            dp[i, i] = true;

        // Check substrings of length 2
        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                start = i;
                maxLength = 2;
            }
        }

        // Check substrings of length 3 and above
        for (int len = 3; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;

                // Check if the substring is a palindrome
                dp[i, j] = dp[i + 1, j - 1] && (s[i] == s[j]);

                if (dp[i, j] && len > maxLength)
                {
                    start = i;
                    maxLength = len;
                }
            }
        }

        return s.Substring(start, maxLength);
    }

    public static string LongestPalindromeMethod3(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > 1000 || !_IsAlphanumeric(s))
            return null;

        // Preprocess the string
        string processedString = PreprocessString(s);

        int n = processedString.Length;
        int[] P = new int[n];
        int center = 0, right = 0;

        for (int i = 0; i < n; i++)
        {
            int mirror = 2 * center - i;

            if (i < right)
                P[i] = Math.Min(right - i, P[mirror]);

            // Attempt to expand palindrome centered at i
            int a = i + (1 + P[i]);
            int b = i - (1 + P[i]);

            while (a < n && b >= 0 && processedString[a] == processedString[b])
            {
                P[i]++;
                a++;
                b--;
            }

            // If palindrome centered at i expands past right,
            // adjust center and right boundary
            if (i + P[i] > right)
            {
                center = i;
                right = i + P[i];
            }
        }

        // Find the maximum element in P
        int maxLen = P.Max();
        int centerIndex = Array.IndexOf(P, maxLen);

        // Extract the longest palindromic substring
        return s.Substring((centerIndex - maxLen) / 2, maxLen);
    }

    private static string PreprocessString(string s)
    {
        StringBuilder sb = new StringBuilder("#");
        foreach (char c in s)
        {
            sb.Append(c);
            sb.Append("#");
        }
        return sb.ToString();
    }

}





