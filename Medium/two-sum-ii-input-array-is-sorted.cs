using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] numbers = { 0, 1, 2, 3, 4, 7, 8 };

        int[] NewNumbers = TwoSum(numbers, 6);

        foreach (int num in NewNumbers)
        {
            Console.WriteLine(num);
        }


        Console.ReadKey();
    }

    private static int[] _GetTwoIndices(int[] numbers, int target)
    {
        int Start = 0;
        int End = numbers.Length - 1;

        while (Start < End)
        {
            if (numbers[End] + numbers[Start] > target)
            {
                End--;
                continue;
            }

            if (numbers[End] + numbers[Start] < target)
            {
                Start++;
                continue;
            }

            if (numbers[End] + numbers[Start] == target)
                return new int[] { Start + 1, End + 1 };
        }

        return null;
    }

    public static int[] TwoSum(int[] numbers, int target)
    {
        if (numbers == null || numbers.Length < 2)
            return null;

        return _GetTwoIndices(numbers, target);
    }
}

