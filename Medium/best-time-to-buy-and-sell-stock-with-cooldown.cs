using System;

public class Solution
{
    public static int MaxProfit(int[] prices)
    {
        int soldProfit = 0; // Profit when stock is sold today
        int restProfit = 0; // Profit when we do nothing today
        int holdProfit = int.MinValue; // Profit when we hold stock today

        for (int i = 0; i < prices.Length; i++)
        {
            int previousSoldProfit = soldProfit; // Store previous day's sold profit
            soldProfit = holdProfit + prices[i]; // Update sold profit by selling stock today
            holdProfit = Math.Max(holdProfit, restProfit - prices[i]); // Update hold profit
            restProfit = Math.Max(restProfit, previousSoldProfit); // Update rest profit
        }

        return Math.Max(soldProfit, restProfit); // Return the maximum profit possible
    }

    public static void Main(string[] args)
    {
        int[] prices = { 1, 2, 3, 0, 2 };

        Console.WriteLine(MaxProfit(prices));

        Console.ReadKey();
    }
}

