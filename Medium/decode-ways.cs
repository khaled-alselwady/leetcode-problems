using System;
using System.Linq;

public class Solution
{
    public static int NumDecodings(string s)
    {
        if (string.IsNullOrWhiteSpace(s) || s[0] == '0')
        {
            return 0;
        }

        if (s.Length == 1)
        {
            if (s[0] == '0')
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        int[] dp = Enumerable.Repeat(1, s.Length + 1).ToArray();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '0')
            {
                dp[i] = 0;
            }
            else
            {
                dp[i] = dp[i + 1];
            }

            if ((i + 1) < s.Length &&
                ((s[i] == '1') || (s[i] == '2' && "0123456".Contains(s[i + 1])))
               )
            {
                dp[i] += dp[i + 2];
            }
        }

        return dp[0];
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(NumDecodings("11106"));

        Console.ReadKey();
    }
}

