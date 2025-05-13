internal class Program
{
    private static (int, int[]) RemoveElement(int[] nums, int val)
    {
        switch (nums.Length)
        {
            case 0:
                return (0, []);
            case 1:
                return (nums[0] == val) ? (0, nums) : (1, nums);
        }

        int k = 0;

        for (int i = 0; i < nums.Length && k < nums.Length; i++)
        {
            if (nums[i] == val)
                continue;

            nums[k] = nums[i]; 
            k++;
        }
        
        return (k, nums);
    }

    private static void Main(string[] args)
    {
        // [0,0,1,1,1,2,2,3,3,4]
        // [1, 2, 2]
        // [1, 2, 3]
        int[] nums = [3,1, 2, 2, 3,1];
        var result = RemoveElement(nums, 1);

        Console.WriteLine(result.Item1);
        Console.WriteLine(string.Join(',', result.Item2));
    }
}