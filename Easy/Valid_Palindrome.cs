using System;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsPalindrome_WithoutUsingTwoPointers("A man, a plan, a canal: Panama"));
        Console.WriteLine(IsPalindrome_UsingTwoPointers("A man, a plan, a canal: Panama"));

        Console.ReadKey();
    }

    #region Without Two Poitors
    private static string _RemoveNonAlphanumericCharacters(string s)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char character in s.ToLower())
        {
            if (char.IsLetterOrDigit(character))
                sb.Append(character);
        }

        return sb.ToString();
    }

    private static bool _IsStringPalindrome_WithoutUsingTwoPointers(string s)
    {
        StringBuilder sb = new StringBuilder(s);

        for (int i = 0; i < sb.Length / 2; i++)
        {
            if (sb[i] != sb[sb.Length - i - 1])
                return false;
        }

        return true;
    }

    public static bool IsPalindrome_WithoutUsingTwoPointers(string s)
    {
        if (s == null)
            return false;

        string Text = _RemoveNonAlphanumericCharacters(s);

        return _IsStringPalindrome_WithoutUsingTwoPointers(Text);
    }
    #endregion

    #region With Two Pointers
    private static bool _IsStringPalindrome_UsingTwoPointers(string s)
    {
        int Start = 0;
        int End = s.Length - 1;
  
        while (Start < End)
        {
            if (!char.IsLetterOrDigit(s[Start]))
            {
                Start++;
                continue;
            }

            if (!char.IsLetterOrDigit(s[End]))
            {
                End--;
                continue;
            }

            if (char.ToLower(s[Start]) != char.ToLower(s[End]))
                return false;

            Start++;
            End--;
        }

        return true;
    }

    public static bool IsPalindrome_UsingTwoPointers(string s)
    {
        if (s == null)
            return false;

        return _IsStringPalindrome_UsingTwoPointers(s);
    }
    #endregion
}

