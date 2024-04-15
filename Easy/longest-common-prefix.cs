using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] arrTexts = { "flower", "flow", "flight" };

        Console.WriteLine(LongestCommonPrefix_Method1(arrTexts));

        Console.ReadKey();
    }

    public static string IsTwoStringHavePrefix(string str1, string str2)
    {
        // this method will search about prefix in the two string, and return it

        if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
            return "";

        StringBuilder sbPrefix = new StringBuilder();

        int minLength = Math.Min(str1.Length, str2.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (str1[i] != str2[i])
                break;

            sbPrefix.Append(str1[i]);
        }

        return sbPrefix.ToString();
    }

    public static string LongestCommonPrefix_Method1(string[] strs)
    {
        List<string> lstPrefix = new List<string>();

        if (strs.Length == 0)
            return "";

        if (strs.Length == 1)
            return strs[0];

        for (int i = 0; i < strs.Length; i++)
        {
            if ((i + 1) < strs.Length)
            {
                lstPrefix.Add(IsTwoStringHavePrefix(strs[i], strs[i + 1]));

                if (lstPrefix.Count > 1)
                {
                    // check the last two prefix in the list and return the prefix of them, I will save it and remove the two prefix
                    lstPrefix.Add(IsTwoStringHavePrefix(lstPrefix[0], lstPrefix[1]));
                    lstPrefix.Remove(lstPrefix[0]);
                    lstPrefix.Remove(lstPrefix[0]);
                }

            }
        }

        return lstPrefix.Last();
    }

    public static string LongestCommonPrefix_Method2(string[] strs)
    {
        if (strs.Length == 0)
            return "";

        //Sort the array lexicographically. This step is necessary because the common prefix
        //should be common to all the strings, so we just need to find the common prefix of the first
        //and last string in the sorted list.
        Array.Sort(strs);

        return IsTwoStringHavePrefix(strs[0], strs[strs.Length - 1]);
    }
}





