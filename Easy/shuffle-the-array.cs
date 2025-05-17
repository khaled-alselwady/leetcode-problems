using System.Linq;

internal class Program
{
    #region First Approach (Space Complexity O(n))
    public static int[] Shuffle_LinearSpaceComplexity(int[] nums, int n)
    {
        if (nums == null || nums.Length == 0 || nums.Length != (2 * n))
            return [];

        int[] result = new int[nums.Length];

        int resultIndex = 0;
        for (int i = 0; (i < nums.Length) && ((i + n) < nums.Length); i++)
        {
            int x = nums[i];
            int y = nums[i + n];

            result[resultIndex] = x;
            result[resultIndex + 1] = y;
            resultIndex += 2;
        }

        return result;
    }
    #endregion

    #region First Approach (Space Complexity O(1))
    public static int[] Shuffle_ConstantSpaceComplexity(int[] nums, int n)
    {
        if (nums == null || nums.Length == 0 || nums.Length != (2 * n))
            return [];

        // (1 <= nums[i] <= 1000), so we have to use a multiplier is grater than 1000 and (x + (y * multiplier)) must be less than int.MaxValue
        int multiplier = 10000; 

        // Encoding
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            int y = nums[i + n];

            nums[i] = x + (y * multiplier);
        }

        // Decoding
        for (int i = n - 1; i >= 0; i--)
        {
            int x = nums[i] % multiplier;
            int y = nums[i] / multiplier;

            nums[2 * i] = x;
            nums[2 * i + 1] = y;
        }

        return nums;
    }
    #endregion

    private static void Main(string[] args)
    {
        int[] nums = [2, 5, 1, 3, 4, 7];
        var result = Shuffle_ConstantSpaceComplexity(nums, 3);

        Console.WriteLine(string.Join(',', result));
    }
}