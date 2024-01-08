using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


public class Solution
{
    public static void Main(string[] args)
    {
        string s = "helloworld";

        Console.WriteLine("Method 1:");
        Console.WriteLine(ConvertMethod1(s, 4));

        Console.WriteLine("\nMethod 2:");
        Console.WriteLine(ConvertMethod2(s, 4));

        Console.ReadKey();
    }

    public static string ConvertMethod1(string s, int numRows)
    {
        if (s == null || numRows <= 0)
            return null;

        if (numRows == 1)
            return s;

        char[,] arrZigZag = new char[numRows, s.Length];
        int numColumns = 1;
        int Counter = 0;
        int TargetIndex = 0;
        int Reset = -1;
        bool IsCompleteColumn = false;

        for (short i = 0; i < numColumns; i++)
        {
            for (short j = 0; j < numRows; j++)
            {
                if (s.Length <= Counter)
                    break;

                if (i == 0 || IsCompleteColumn)
                    arrZigZag[j, i] = s[Counter++];

                else
                {
                    if (i < numRows)
                        Reset = i;

                    TargetIndex = numRows - (Reset + 1);

                    if (TargetIndex == 0)
                    {
                        j = -1;
                        Reset = 0;
                        IsCompleteColumn = true;

                        continue;
                    }

                    if (TargetIndex == j)
                        arrZigZag[TargetIndex, i] = s[Counter++];
                    else
                        arrZigZag[j, i] = ' ';
                }
            }

            IsCompleteColumn = false;

            if (s.Length > Counter)
            {
                Reset++;
                numColumns++;
            }
            else
                break;
        }
        PrintArrayZigZag(arrZigZag);
        Console.WriteLine();
        return GetStringArrayZigZag(arrZigZag);
    }

    public static string ConvertMethod2(string s, int numRows)
    {
        if (s == null || numRows <= 0)
            return null;

        if (numRows == 1)
            return s;

        StringBuilder result = new StringBuilder();
        int cycleLen = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j + i < s.Length; j += cycleLen)
            {
                result.Append(s[j + i]);

                if (i != 0 && i != numRows - 1 && j + cycleLen - i < s.Length)
                    result.Append(s[j + cycleLen - i]);
            }
        }

        return result.ToString();
    }

    public static void PrintArrayZigZag(char[,] array)
    {

        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        // Print the array elements
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write($"{array[row, col]}  ");
            }
            Console.WriteLine();
        }
    }

    public static string GetStringArrayZigZag(char[,] array)
    {
        StringBuilder sbZigZag = new StringBuilder();

        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        // Print the array elements
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (array[row, col] != ' ' && array[row, col] != '\0')

                    sbZigZag.Append(array[row, col]);
            }
        }

        return sbZigZag.ToString();
    }
}