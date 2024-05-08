using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private static bool[] _InitializeDP(int length)
    {
        bool[] dp = Enumerable.Repeat(false, length).ToArray();

        dp[length - 1] = true;
        return dp;
    }

    private static void _SearchInList(string s, IList<string> wordDict, bool[] dp, int i)
    {
        foreach (string word in wordDict)
        {
            if ((i + word.Length <= s.Length) &&
                (s.Substring(i, word.Length) == word))
            {
                dp[i] = dp[i + word.Length];
            }

            if (dp[i])
            {
                break;
            }
        }
    }

    public static bool WordBreak(string s, IList<string> wordDict)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return true;
        }

        if (wordDict == null || wordDict.Count == 0)
        {
            return false;
        }

        bool[] dp = _InitializeDP(s.Length + 1);

        for (int i = s.Length - 1; i >= 0; i--)
        {
            _SearchInList(s, wordDict, dp, i);
        }

        return dp[0];
    }

    public static void Main(string[] args)
    {
        IList<string> list = new List<string>()
        {
          "bc","ca"
        };

        Console.WriteLine(WordBreak("cbca", list));

        Console.ReadKey();
    }
}

