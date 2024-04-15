using System;
using System.Collections.Generic;
using System.Globalization;

public class Solution
{
    public static void Main(string[] args)
    {
        IList<string> LetterPhoneCombinations = LetterCombinations("5678");

        Console.WriteLine("[ " + string.Join(", ", LetterPhoneCombinations) + " ]");

        Console.ReadKey();
    }

    private static bool _IsStringContainOnlyNumbersFromTwoToNine(string Word)
    {
        byte Digit = 0;

        foreach (char Letter in Word)
        {
            if (!Char.IsDigit(Letter))
                return false;

            Digit = (byte)(Letter - '0');

            if (Digit < 2 || Digit > 9)
                return false;
        }

        return true;
    }

    private static IList<string> _LetterPhoneCombinations(string Word)
    {
        IList<string> WordCombinations = new List<string>();

        for (int i = 0; i < Word.Length; i++)
        {
            WordCombinations.Add((Word[i]).ToString());
        }

        return WordCombinations;
    }

    private static IList<string> _LetterPhoneCombinations(string Word1, string Word2)
    {
        IList<string> WordCombinations = new List<string>();

        for (int i = 0; i < Word1.Length; i++)
        {

            for (int j = 0; j < Word2.Length; j++)
            {
                WordCombinations.Add(Word1[i].ToString() + Word2[j]);
            }

        }

        return WordCombinations;
    }

    private static IList<string> _LetterPhoneCombinations(string Word1, string Word2, string Word3)
    {
        IList<string> WordCombinations = new List<string>();

        for (int i = 0; i < Word1.Length; i++)
        {

            for (int j = 0; j < Word2.Length; j++)
            {

                for (int k = 0; k < Word3.Length; k++)
                {
                    WordCombinations.Add((Word1[i].ToString() + Word2[j] + Word3[k]).ToString());
                }

            }

        }

        return WordCombinations;
    }

    private static IList<string> _LetterPhoneCombinations(string Word1, string Word2, string Word3, string Word4)
    {
        IList<string> WordCombinations = new List<string>();

        for (int i = 0; i < Word1.Length; i++)
        {

            for (int j = 0; j < Word2.Length; j++)
            {

                for (int k = 0; k < Word3.Length; k++)
                {

                    for (int l = 0; l < Word4.Length; l++)
                    {


                        WordCombinations.Add((Word1[i].ToString() + Word2[j] + Word3[k] + Word4[l]).ToString());
                    }

                }

            }

        }

        return WordCombinations;
    }

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits == null || digits.Length == 0 ||
            (digits.Length < 1 || digits.Length > 4) ||
             !_IsStringContainOnlyNumbersFromTwoToNine(digits))
            return new List<string>();

        IList<string> LetterCombinations = new List<string>();

        Dictionary<char, string> KeyValueLetterCombinations = new Dictionary<char, string>
        {
            {'2', "abc" },
            {'3', "def" },
            {'4', "ghi" },
            {'5', "jkl" },
            {'6', "mno" },
            {'7', "pqrs" },
            {'8', "tuv" },
            {'9', "wxyz" }
        };

        switch (digits.Length)
        {
            case 1:
                LetterCombinations = _LetterPhoneCombinations(KeyValueLetterCombinations[digits[0]]);
                break;

            case 2:
                LetterCombinations = _LetterPhoneCombinations
                    (KeyValueLetterCombinations[digits[0]], KeyValueLetterCombinations[digits[1]]);
                break;

            case 3:
                LetterCombinations = _LetterPhoneCombinations
                    (KeyValueLetterCombinations[digits[0]], KeyValueLetterCombinations[digits[1]],
                    KeyValueLetterCombinations[digits[2]]);
                break;

            case 4:
                LetterCombinations = _LetterPhoneCombinations
                    (KeyValueLetterCombinations[digits[0]], KeyValueLetterCombinations[digits[1]],
                    KeyValueLetterCombinations[digits[2]], KeyValueLetterCombinations[digits[3]]);
                break;
        }

        return LetterCombinations;
    }

}

