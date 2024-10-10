
internal class Program
{
    private static string _GetRange(int first, int last)
    {
        return (Convert.ToInt32(first) != last) ? $"{first}->{last}" : $"{first}";
    }

    public static IList<string> SummaryRanges(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return [];
        }

        IList<string> result = new List<string>();
        string firstItemInRange = string.Empty;

        for (int i = 0; i < nums.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(firstItemInRange))
            {
                firstItemInRange = $"{nums[i]}";
            }

            if (nums[i] < int.MaxValue && nums.Contains(nums[i] + 1))
            {
                continue;
            }

            string range = _GetRange(Convert.ToInt32(firstItemInRange), nums[i]);

            result.Add(range);
            firstItemInRange = string.Empty;
        }

        return result;
    }

    private static void Main(string[] args)
    {
        int[] nums = [-2147483648, -2147483647, 2147483647];

        Console.WriteLine(string.Join(',', SummaryRanges(nums)));

        Console.ReadKey();
    }
}