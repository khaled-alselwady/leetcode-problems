using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] prices = { 2, 4, 1 };

        Console.WriteLine(MaxProfit(prices));

        Console.ReadKey();
    }

    public static int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length <= 1)
            return 0;

        int CheaperPrice = prices[0];
        int MaxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            CheaperPrice = Math.Min(CheaperPrice, prices[i]);
            MaxProfit = Math.Max(MaxProfit, prices[i] - CheaperPrice);
        }

        return MaxProfit;
    }

}

