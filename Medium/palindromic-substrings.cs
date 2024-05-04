using System;
using System.Text;

public class Solution
{
    #region Brute Force
    private static bool _IsPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        if (s.Length == 1)
        {
            return true;
        }

        for (int i = 0; i <= s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
    public static int CountSubstrings(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        int count = s.Length;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            sb.Clear();
            sb.Append(s[i]);

            for (int j = i + 1; j < s.Length; j++)
            {
                sb.Append(s[j]);
                if (_IsPalindrome(sb.ToString()))
                {
                    count++;
                }
            }
        }

        return count;
    }
    #endregion

    #region Two-Pointers
    private static int _CountPalindrome(string s, int left, int right)
    {
        int count = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            count++;

            left--;
            right++;
        }

        return count;
    }
    public static int CountSubstrings2(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // Odd Length Palindrome
            count += _CountPalindrome(s, i, i);

            // Even Length Palindrome
            count += _CountPalindrome(s, i, i + 1);
        }

        return count;
    }
    #endregion

    public static void Main(string[] args)
    {
        Console.WriteLine(CountSubstrings("abaaba"));
        Console.WriteLine(CountSubstrings2("abaaba"));

        Console.ReadKey();
    }
}

