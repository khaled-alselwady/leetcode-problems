public class Solution
{
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return [];
        }

        IList<int> result = new List<int>();
        int top = 0;
        int bottom = matrix.Length - 1;
        int left = 0;
        int right = matrix[0].Length - 1;

        while (true)
        {
            //Left to Right
            for (int i = left; i <= right; i++)
            {
                result.Add(matrix[top][i]);
            }
            top++;
            if (left > right || top > bottom) break;

            //Top to Bottom
            for (int i = top; i <= bottom; i++)
            {
                result.Add(matrix[i][right]);
            }
            right--;
            if (left > right || top > bottom) break;

            //Right to Left
            for (int i = right; i >= left; i--)
            {
                result.Add(matrix[bottom][i]);
            }
            bottom--;
            if (left > right || top > bottom) break;

            //Bottom to Top
            for (int i = bottom; i >= top; i--)
            {
                result.Add(matrix[i][left]);
            }
            left++;
            if (left > right || top > bottom) break;
        }

        return result;
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
           [1,2,3,4],
           [5,6,7,8],
           [9,10,11,12]
        ];

        IList<int> list = SpiralOrder(matrix);

        Console.WriteLine("Original matrix:");
        _PrintMatrix(matrix);


        Console.WriteLine("Matrix after rotation:");

        Console.WriteLine(string.Join(", ", list));
    }
}

