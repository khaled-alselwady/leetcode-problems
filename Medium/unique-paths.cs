using System;
using System.Linq;

public class Solution
{
    #region Approach 1 (Dynamic Programming Using Matrix)
    public static int UniquePaths_UsingMatrix(int m, int n)
    {
        if (m < 1 || m > 100 || n < 1 || n > 100)
        {
            return 0;
        }

        int[,] matrixPaths = new int[m + 1, n + 1];
        matrixPaths[m - 1, n - 1] = 1;

        for (int row = m - 1; row >= 0; row--)
        {
            for (int col = n - 1; col >= 0; col--)
            {
                matrixPaths[row, col] = matrixPaths[row + 1, col] + matrixPaths[row, col + 1];

                if (matrixPaths[row, col] == 0)
                {
                    matrixPaths[row, col] = 1;
                }
            }
        }

        return matrixPaths[0, 0];
    }
    #endregion

    #region Approach 2 (Dynamic Programming Using Array)
    public static int UniquePaths_UsingArray(int m, int n)
    {
        if (m < 1 || m > 100 || n < 1 || n > 100)
        {
            return 0;
        }

        int[] row = Enumerable.Repeat(1, n).ToArray();

        foreach (int i in Enumerable.Range(0, m - 1))
        {
            var newRow = Enumerable.Repeat(1, n).ToArray();

            for (int j = n - 2; j >= 0; j--)
            {
                newRow[j] = newRow[j + 1] + row[j];
            }

            row = newRow;
        }

        return row[0];
    }
    #endregion

    public static void Main(string[] args)
    {
        Console.WriteLine(UniquePaths_UsingArray(1, 1));

        Console.ReadKey();
    }
}

