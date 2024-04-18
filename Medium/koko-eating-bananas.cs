using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] piles = { 805306368, 805306368, 805306368 };

        Console.WriteLine(MinEatingSpeed(piles, 1000000000));

        Console.ReadKey();
    }

    public static int MinEatingSpeed(int[] piles, int h)
    {
        if (piles == null || piles.Length == 0 || h == 0)
            return 0;

        int start = 1, end = piles.Max();
        int minEatingSpeed = end;

        while (start <= end)
        {
            int medium = start + ((end - start) / 2);

            long sumHours = piles.Sum(pile => (long)Math.Ceiling(pile / (double)medium));

            if (sumHours <= h)
            {
                minEatingSpeed = medium;
                end = medium - 1;
            }

            else
            {
                start = medium + 1;
            }
        }

        return minEatingSpeed;
    }
}

