public class Solution
{
    #region First Approach

    private static void _SetZeroesOnRow(int[][] matrix, int row)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return;
        }

        Array.Fill(matrix[row], 0);
    }

    private static void _SetZeroesOnColumn(int[][] matrix, int col)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return;
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][col] = 0;
        }
    }

    private static void _SetZeroesInMatrix(int[][] matrix, List<(int row, int col)> rowColValues)
    {
        foreach (var (row, col) in rowColValues)
        {
            _SetZeroesOnRow(matrix, row);
            _SetZeroesOnColumn(matrix, col);
        }
    }

    private static List<(int row, int col)> _FillListWithIndexOfRowAndColumnZeroes(int[][] matrix)
    {
        List<(int row, int col)> rowColValues = new List<(int row, int col)>();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rowColValues.Add((row: i, col: j));
                }
            }
        }

        return rowColValues;
    }

    public static void SetZeroes(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return;
        }

        List<(int row, int col)> rowColValues = _FillListWithIndexOfRowAndColumnZeroes(matrix);

        _SetZeroesInMatrix(matrix, rowColValues);
    }

    #endregion

    #region Second Approach

    private static void _MarkFirstRowAndFirstColumnWithZeroes(int[][] matrix)
    {
        (int rows, int cols) = (matrix.Length, matrix[0].Length);

        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[0][j] = matrix[i][0] = 0;
                }
            }
        }
    }

    public static void SetZeroes2(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return;
        }

        (int rows, int cols) = (matrix.Length, matrix[0].Length);

        // Check if the first row has any zeros
        bool firstRowHasZeros = matrix[0].Contains(0);

        // Use the first row and first column to mark zeros
        _MarkFirstRowAndFirstColumnWithZeroes(matrix);

        // Set zeroes based on the markers in the first column
        for (int i = 1; i < rows; i++)
        {
            if (matrix[i][0] == 0)
            {
                _SetZeroesOnRow(matrix, i);
            }
        }

        // Set zeroes based on the markers in the first row
        for (int i = 0; i < cols; i++)
        {
            if (matrix[0][i] == 0)
            {
                _SetZeroesOnColumn(matrix, i);
            }
        }

        // Finally, handle the first row if it originally had any zeros
        if (firstRowHasZeros)
        {
            _SetZeroesOnRow(matrix, 0);
        }
    }

    #endregion

    #region Utility Methods

    private static void _PrintMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
        Console.WriteLine();
    }

    #endregion

    static void Main()
    {
        int[][] matrix =
        {
            [0,1,2,0],
            [3,4,5,2],
            [1,3,1,5]
        };

        Console.WriteLine("Original matrix:");
        _PrintMatrix(matrix);

        SetZeroes2(matrix);

        Console.WriteLine("Matrix after Set Zeroes:");
        _PrintMatrix(matrix);
    }
}

