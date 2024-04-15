using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsIsomorphic("badc", "baba"));

        Console.ReadKey();
    }

    private static bool _IsValueAlreadyExistInDictionary(Dictionary<char, char> Maps, char Value)
        => Maps.FirstOrDefault(kvp => kvp.Value == Value).Value == Value;

    public static bool IsIsomorphic(string s, string t)
    {
        if (s == null || t == null)
            return false;

        if (t.Length != s.Length)
            return false;

        if (s.Length == 0 && t.Length == 0)
            return true;

        Dictionary<char, char> Maps = new Dictionary<char, char>();

        for (int i = 0; i < s.Length && i < t.Length; i++)
        {
            if (!Maps.ContainsKey(s[i]))
            {
                if (_IsValueAlreadyExistInDictionary(Maps, t[i]))
                    return false;

                Maps.Add(s[i], t[i]);
            }

            if (Maps[s[i]] != t[i])
                return false;
        }

        return true;
    }


}

