using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        IList<string> lstParenthesis = GenerateParenthesis2(3);

        foreach (string Parenthesis in lstParenthesis)
        {
            Console.WriteLine(Parenthesis);
        }

        Console.ReadKey();
    }

    public static IList<string> GenerateParenthesis2(int n)
    {
        IList<string> res = new List<string>();
        StringBuilder sbParentheses = new StringBuilder();

        void BackTrack(byte Open, byte Close)
        {
            if (Open == Close && Open == n)
            {
                res.Add(sbParentheses.ToString());
                return;
            }

            if (Open < n)
            {
                sbParentheses.Append("(");
                BackTrack((byte)(Open + 1), Close);
                sbParentheses.Length--;
            }

            if (Close < Open)
            {
                sbParentheses.Append(")");
                BackTrack(Open, (byte)(Close + 1));
                sbParentheses.Length--;
            }
        }

        // we'll start with zero `(` and zero `)` 
        BackTrack(0, 0);

        return res;
    }

}

