using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 7, 2, 4 };

        //int[] result = MaxSlidingWindow(nums, 2);
        int[] result = MaxSlidingWindow2(nums, 2);

        Console.Write("[ ");
        foreach (int number in result)
        {
            Console.Write(number + ", ");
        }
        Console.WriteLine(" ]");

        Console.ReadKey();
    }

    #region Approach 1 brute force
    private static int _GetMaxInCollection(IEnumerable<int> collection)
    {
        if (collection == null || collection.Count() == 0)
            return 0;

        return collection.Max();
    }

    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k == 0 || k > nums.Length)
            return null;

        if (k == 1)
            return nums;

        List<int> result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i + k > nums.Length)
            {
                break;
            }

            int maxNumber = _GetMaxInCollection(nums.Skip(i).Take(k));
            result.Add(maxNumber);
        }

        return result.ToArray();
    }
    #endregion

    #region Approach 2
    public static int[] MaxSlidingWindow2(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k == 0 || k > nums.Length)
            return null;

        if (k == 1)
            return nums;

        List<int> result = new List<int>();
        LinkedList<int> queue = new LinkedList<int>();
        int left = 0, right = 0;

        while (right < nums.Length)
        {
            // pop smaller values from queue
            while (queue.Count > 0 && nums[queue.Last.Value] < nums[right])
                queue.RemoveLast();
            queue.AddLast(right);

            // remove left val from the window
            if (left > queue.First.Value)
                queue.RemoveFirst();

            if (right + 1 >= k)
            {
                result.Add(nums[queue.First.Value]);
                left++;
            }

            right++;
        }

        return result.ToArray();
    }
    #endregion
}

