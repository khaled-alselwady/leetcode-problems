using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] temperatures = { 73, 74, 75, 71, 69, 72, 76, 73 };

        int[] Results = DailyTemperatures_Method2(temperatures);

        foreach (int i in Results)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }

    public static int[] DailyTemperatures_Method1(int[] temperatures)
    {

        if (temperatures == null || temperatures.Length == 0)
            return null;

        if (temperatures.Length == 1)
            return new int[] { 0 };

        int[] Results = new int[temperatures.Length];
        int Counter = 0;

        for (int i = 0; i < temperatures.Length; i++)
        {

            if (((i + 1) < temperatures.Length))
            {
                if (temperatures[i] < temperatures[i + 1])
                {
                    Counter++;
                    Results[i] = Counter;
                    Counter = 0;
                }
                else
                {
                    Counter++;
                    for (int j = i + 2; j < temperatures.Length; j++)
                    {
                        if (temperatures[i] < temperatures[j])
                        {
                            Counter++;
                            Results[i] = Counter;
                            Counter = 0;
                            break;
                        }
                        else
                        {
                            Counter++;
                        }
                    }
                }
            }
            else
            {
                Results[i] = 0;
            }

            Counter = 0;
        }

        return Results;
    }

    public static int[] DailyTemperatures_Method2(int[] temperatures)
    {
        if (temperatures == null || temperatures.Length == 0)
            return null;

        if (temperatures.Length == 1)
            return new int[] { 0 };

        int[] result = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();

        for (int i = temperatures.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && temperatures[i] >= temperatures[stack.Peek()])
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                result[i] = stack.Peek() - i;
            }

            stack.Push(i);
        }

        return result;
    }

}

