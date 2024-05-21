public class Solution
{
    private static void _Rotate(int[][] matrix, int left, int right, int i)
    {
        (int top, int bottom) = (left, right);

        // Save the top left
        int topLeft = matrix[top][left + i];

        // Move bottom left into top left
        matrix[top][left + i] = matrix[bottom - i][left];

        // Move bottom right into bottom left
        matrix[bottom - i][left] = matrix[bottom][right - i];

        // Move top right into bottom right
        matrix[bottom][right - i] = matrix[top + i][right];

        // Move top left into top right
        matrix[top + i][right] = topLeft;
    }

    public static void Rotate(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return;
        }

        (int left, int right) = (0, matrix.Length - 1);

        while (left < right)
        {

            foreach (int i in Enumerable.Range(0, right - left))
            {
                _Rotate(matrix, left, right, i);
            }

            left++;
            right--;
        }
    }

    private static void _PrintMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[][] matrix =
        [
           [5,1,9,11],
           [2,4,8,10],
           [13,3,6,7],
           [15,14,12,16]
        ];

        Console.WriteLine("Original matrix:");
        _PrintMatrix(matrix);

        Rotate(matrix);

        Console.WriteLine("Matrix after rotation:");
        _PrintMatrix(matrix);
    }
}

