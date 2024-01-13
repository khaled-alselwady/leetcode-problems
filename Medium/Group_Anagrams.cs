using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };

        IList<IList<string>> result = GroupAnagrams(strs);

        foreach (var group in result)
        {
            Console.WriteLine("[ " + string.Join(", ", group) + " ]");
        }

        Console.ReadKey();
    }

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return new List<IList<string>>();

        if (strs.Length == 1)
            return new List<IList<string>> { new List<string> { strs[0] } };

        Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            string sortedString = "";

            // in case empty string, no need to sort the word
            if (!string.IsNullOrEmpty(str))
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                sortedString = new string(charArray);
            }

            if (!anagramGroups.ContainsKey(sortedString))
            {
                anagramGroups[sortedString] = new List<string>();
            }

            anagramGroups[sortedString].Add(str);
        }

        return anagramGroups.Values.ToList<IList<string>>();
    }
}





