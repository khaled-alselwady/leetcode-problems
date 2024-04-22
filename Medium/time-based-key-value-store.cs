using System;
using System.Collections.Generic;
using System.Linq;

#region Approach 1 (Linear Search of Values)
public class TimeMap
{
    private Dictionary<(string key, string value), int> _timeMap;

    public TimeMap()
    {
        _timeMap = new Dictionary<(string key, string value), int>();
    }

    public void Set(string key, string value, int timestamp)
    {
        _timeMap[(key, value)] = timestamp;
    }

    public string Get(string key, int timestamp)
    {
        foreach (var outerKeyValue in _timeMap)
        {
            if (key == outerKeyValue.Key.key)
            {
                if (timestamp == outerKeyValue.Value)
                    return outerKeyValue.Key.value;
                else
                    return _GetValueOfPreviousLargestTimestamp(key, timestamp);
            }
        }

        return "";
    }

    private string _GetValueOfPreviousLargestTimestamp(string key, int currentTimestamp)
    {
        int largestTimeStamp = _GetPreviousLargestTimestampOfKey(key, currentTimestamp);

        return _timeMap
               .Where(kvp => kvp.Key.key == key && kvp.Value == largestTimeStamp)
               .Select(kvp => kvp.Key.value)
               .FirstOrDefault() ?? "";
    }

    private int _GetPreviousLargestTimestampOfKey(string key, int currentTimestamp)
    {
        return _timeMap
               .Where(kvp => kvp.Key.key == key && currentTimestamp >= kvp.Value)
               .Select(kvp => kvp.Value) // Select the timestamp values
               .DefaultIfEmpty(0) // Provide a default value to avoid an empty sequence
               .Max();
    }
}
#endregion

#region Approach 2 (Binary Search of Values)
public class TimeMap2
{
    private readonly Dictionary<string, List<(int timestamp, string value)>> _dict;

    public TimeMap2()
    {
        _dict = new Dictionary<string, List<(int, string)>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        var values = new List<(int, string)>();
        if (!_dict.ContainsKey(key))
        {
            _dict.Add(key, values);
        }
        _dict[key].Add((timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        if (!_dict.ContainsKey(key))
        {
            return "";
        }

        return _GetValueUsingBinarySearch(key, timestamp);
    }

    private string _GetValueUsingBinarySearch(string key, int timestamp)
    {
        var value = _dict[key];

        var left = 0;
        var right = value.Count;
        var result = "";

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (value[mid].timestamp == timestamp)
            {
                return value[mid].value;
            }
            else if (value[mid].timestamp < timestamp)
            {
                left = mid + 1;
                result = value[mid].value;
            }
            else
            {
                right = mid;
            }
        }

        return result;
    }
}
#endregion

public class Solution
{
    public static void Main(string[] args)
    {
        //TimeMap timeMap = new TimeMap();
        //timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
        //Console.WriteLine(timeMap.Get("foo", 1));         // return "bar"
        //Console.WriteLine(timeMap.Get("foo", 3));         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        //timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
        //Console.WriteLine(timeMap.Get("foo", 4));         // return "bar2"
        //Console.WriteLine(timeMap.Get("foo", 5));         // return "bar2"


        TimeMap2 timeMap = new TimeMap2();
        timeMap.Set("love", "high", 10);  // store the key "foo" and value "bar" along with timestamp = 1.
        timeMap.Set("love", "low", 20);  // store the key "foo" and value "bar" along with timestamp = 1.
        Console.WriteLine(timeMap.Get("love", 5));         // return ""
        Console.WriteLine(timeMap.Get("love", 10));         // return "high", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        Console.WriteLine(timeMap.Get("love", 15));         // return "high", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        Console.WriteLine(timeMap.Get("love", 20));         // return "low", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        Console.WriteLine(timeMap.Get("love", 25));         // return "low", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".

        Console.ReadKey();
    }

}

