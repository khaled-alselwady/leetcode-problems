internal class Program
{
    private static (int, int[]) RemoveDuplicates(int[] nums)
    {
        switch (nums.Length)
        {
            case 0:
                return (0, []);
            case 1:
                return (1, nums);
            case 2 when nums[0] != nums[1]:
                return (2, nums);
        }

        int k = 1;
        int currentDup = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != currentDup)
            {
                currentDup = nums[i];
                nums[k] = currentDup;
                k++;
            }
        }    

        return (k, nums);
    }

    private static void Main(string[] args)
    {
        // [0,0,1,1,1,2,2,3,3,4]
        // [1, 2, 2]
        // [1, 2, 3]
        int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
        var result = RemoveDuplicates(nums);

        Console.WriteLine(result.Item1);
        Console.WriteLine(string.Join(',', result.Item2));
    }
}