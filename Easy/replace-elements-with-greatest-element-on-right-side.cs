public class Solution
{
    #region Approach 1 (Brute Force [O(n²)])
    private static int _GetMaxStartingByIndex(int[] arr, int index)
    {
        if (arr == null || arr.Length == 0)
        {
            return 0;
        }

        int max = int.MinValue;

        for (int i = index; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    public static int[] ReplaceElements(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return [];
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (i == arr.Length - 1)
            {
                arr[i] = -1;
                break;
            }
            int maxAtRightSide = _GetMaxStartingByIndex(arr, i + 1);
            arr[i] = maxAtRightSide;
        }

        return arr;
    }
    #endregion

    #region Approach 2 (Optimal Solution [O(n)])
    public static int[] ReplaceElements2(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return [];
        }

        int rightMax = -1;
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int newMax = Math.Max(rightMax, arr[i]);
            arr[i] = rightMax;
            rightMax = newMax;
        }

        return arr;
    }
    #endregion

    private static void Main()
    {
        int[] arr = [4, 3, 2, 1];

        Console.WriteLine(string.Join(", ", ReplaceElements2(arr)));
    }
}