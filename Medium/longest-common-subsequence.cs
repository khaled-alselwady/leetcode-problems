using System;

public class Solution
{
    private static int[,] _FillMatrix(string text1, string text2)
    {
        int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--)
        {
            for (int j = text2.Length - 1; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                {
                    matrix[i, j] = 1 + matrix[i + 1, j + 1];
                }
                else
                {
                    matrix[i, j] = Math.Max(matrix[i, j + 1], matrix[i + 1, j]);
                }
            }
        }

        return matrix;
    }

    public static int LongestCommonSubsequence(string text1, string text2)
    {
        if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
        {
            return 0;
        }

        if (text1 == text2)
        {
            return text1.Length;
        }

        int[,] matrix = _FillMatrix(text1, text2);

        return matrix[0, 0];
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(LongestCommonSubsequence("zxabcdezy", "yzabcdezx"));

        Console.ReadKey();
    }
}

