using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        char[][] validSudoku = new char[][]
{
    new char[] {'5','3','.','.','7','.','.','.','.'},
    new char[] {'6','.','.','1','9','5','.','.','.'},
    new char[] {'.','9','8','.','.','.','.','6','.'},
    new char[] {'8','.','.','.','6','.','.','.','3'},
    new char[] {'4','.','.','8','.','3','.','.','1'},
    new char[] {'7','.','.','.','2','.','.','.','6'},
    new char[] {'.','6','.','.','.','.','2','8','.'},
    new char[] {'.','.','.','4','1','9','.','.','5'},
    new char[] {'.','.','.','.','8','.','.','7','9'}
};

        Console.WriteLine(IsValidSudoku(validSudoku));

        Console.ReadKey();
    }

    public static bool IsValidSudoku(char[][] board)
    {
        if (board.Length != 9 || board[0].Length != 9)
            return false;

        foreach (char[] row in board)
        {
            if (!IsValidRow(row))
                return false;
        }

        if (!IsValidColumn(board))
            return false;

        for (byte startRow = 0; startRow < 9; startRow += 3)
        {
            for (byte startCol = 0; startCol < 9; startCol += 3)
            {
                if (!IsValidSubgrid(board, startRow, startCol))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool IsValidRow(char[] Characters)
    {
        HashSet<char> setCharacters = new HashSet<char>(9);

        foreach (char Character in Characters)
        {
            if (Character != '.' && !setCharacters.Add(Character))
                return false;
        }

        return true;
    }

    public static bool IsValidColumn(char[][] board)
    {
        HashSet<char> setNumbers;

        for (byte col = 0; col < 9; col++)
        {
            setNumbers = new HashSet<char>(9);

            for (byte row = 0; row < 9; row++)
            {
                if (board[row][col] != '.' && !setNumbers.Add(board[row][col]))
                    return false;
            }
        }

        return true;
    }

    private static bool IsValidSubgrid(char[][] board, int startRow, int startCol)
    {
        HashSet<char> setNumbers = new HashSet<char>(9);

        for (byte row = (byte)startRow; row < startRow + 3; row++)
        {
            for (byte col = (byte)startCol; col < startCol + 3; col++)
            {
                if (board[row][col] != '.' && !setNumbers.Add(board[row][col]))
                {
                    return false;
                }
            }
        }

        return true;
    }
}