using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string s = "arr", t = "rar";

        Console.WriteLine(IsAnagram(s, t));
        Console.ReadKey();
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, short> keyValuePairs = new Dictionary<char, short>();

        foreach (char Letter in s)
        {
            keyValuePairs.TryGetValue(Letter, out var count);
            keyValuePairs[Letter] = (short)(count + 1);
        }

        foreach (char Letter in t)
        {
            if (!keyValuePairs.ContainsKey(Letter))
                return false;

            keyValuePairs[Letter]--;

            if (keyValuePairs[Letter] < 0)
                return false;
        }

        return true;
    }


}





