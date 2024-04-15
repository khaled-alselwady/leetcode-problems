using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] words = { "word", "world", "row" };
        string order = "worldabcefghijkmnpqstuvxyz";

        Console.WriteLine(IsAlienSorted(words, order));

        Console.ReadKey();
    }

    private static sbyte _GetIndexOfLetter(char Letter, string Order)
        => (sbyte)Order.IndexOf(Letter);

    private static bool _IsTwoWordsSorted(string Word1, string Word2, string Order)
    {
        for (byte i = 0; i < Word1.Length && i < Word2.Length; i++)
        {
            sbyte Index1 = _GetIndexOfLetter(Word1[i], Order);
            sbyte Index2 = _GetIndexOfLetter(Word2[i], Order);

            if (Index1 < Index2)
                return true;
            else if (Index1 > Index2)
                return false;

            if (i >= Word1.Length - 1)
                return true;

            if (i >= Word2.Length - 1)
                return false;
        }

        return false;
    }

    public static bool IsAlienSorted(string[] words, string order)
    {
        if (words == null || words.Length == 0)
            return false;

        if (words.Length == 1)
            return true;

        for (byte i = 0; i < words.Length - 1; i++)
        {
            if (!words[i].Equals(words[i + 1]) && !_IsTwoWordsSorted(words[i], words[i + 1], order))
                return false;
        }

        return true;
    }

}

