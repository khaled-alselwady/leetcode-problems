using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[][] matrix =
        {
            new int[] { 1,3,5,7 },
            new int[] { 10,11,16,20 },
            new int[] { 23, 30, 34, 50 }
        };

        Console.WriteLine(SearchMatrix(matrix, 12));
        Console.WriteLine(SearchMatrix2(matrix, 12));

        Console.ReadKey();
    }

    private static int _BinarySearch(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            int medium = start + ((end - start) / 2);

            if (nums[medium] > target)
                end = medium - 1;
            else if (nums[medium] < target)
                start = medium + 1;
            else
                return medium;
        }

        return -1;
    }

    #region Approach 1 (Search Matrix Linear)
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0)
            return false;

        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == target)
                return true;

            if (matrix[i][0] > target)
            {
                if (i == 0)
                    return false; // in this case, the first element in the first row is greater than the target, so it does not exist in the matrix.

                // if it doesn't in the first row, and the first element of the current row is greater than the target, so of course the target cannot be in the next rows, it may exist in the previous row, so I will search only in it.
                return (_BinarySearch(matrix[i - 1], target) != -1);
            }

            if (i == matrix.Length - 1)
                return (_BinarySearch(matrix[i], target) != -1);
        }

        return false;
    }
    #endregion

    #region Approach 1 (Search Matrix Binary)
    public static bool SearchMatrix2(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0)
            return false;

        int rows = matrix.Length, cols = matrix[0].Length;
        int mediumRow = 0;
        int top = 0, bot = rows - 1; // Variables for the top and bottom bounds of the binary search.

        // Perform binary search to find the potential row where the target might exist.
        while (top <= bot)
        {
            mediumRow = top + ((bot - top) / 2);

            // Check if the target is greater than the last element of the current row.
            // If so, update the top bound to search in the lower half of the matrix.
            if (target > matrix[mediumRow][cols - 1])
                top = mediumRow + 1;
            // Check if the target is less than the first element of the current row.
            // If so, update the bottom bound to search in the upper half of the matrix.
            else if (target < matrix[mediumRow][0])
                bot = mediumRow - 1;
            // If the target falls within the range of the current row, exit the loop.
            else
                break;
        }

        // If the top bound exceeds the bottom bound, the target is not present in the matrix.
        if (top > bot)
            return false;

        // Perform binary search within the potential row to find the target.
        return (_BinarySearch(matrix[mediumRow], target) != -1);
    }
    #endregion
}

