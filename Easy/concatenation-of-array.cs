public class Solution
{
    #region Approach 1 (Using Array)
    public static int[] GetConcatenation(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return [];
        }

        int[] result = new int[2 * nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            result[i + nums.Length] = result[i] = nums[i];
        }

        return result;
    }
    #endregion

    #region Approach 2 (Using List)
    public static int[] GetConcatenation2(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return [];
        }

        List<int> result = new List<int>(nums);

        foreach (int num in nums)
        {
            result.Add(num);
        }

        return result.ToArray();
    }
    #endregion

    private static void Main()
    {
        int[] nums = [1, 2, 1];
        int[] result = GetConcatenation(nums);

        Console.WriteLine(string.Join(", ", result));
    }
}