using System;
using System.Collections.Generic;

public class LRUCache
{
    private readonly int _Capacity;

    private Dictionary<int, LinkedListNode<(int key, int value)>> _KeyValuePairs =
        new Dictionary<int, LinkedListNode<(int key, int value)>>();

    private LinkedList<(int key, int value)> _Values =
        new LinkedList<(int key, int value)>();

    public LRUCache(int capacity)
    {
        if (capacity < 1)
            capacity = 1;

        if (capacity > 3000)
            capacity = 3000;

        _Capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_KeyValuePairs.ContainsKey(key))
            return -1;

        var Node = _KeyValuePairs[key];

        _Values.Remove(Node);
        _Values.AddFirst(Node); // the first node in the linked list is the most recently used

        return Node.Value.value; // the value of the dictionary is a node and the value of the node is a tuple contains (key and value)
    }

    public void Put(int key, int value)
    {
        if (key < 0 || value < 0)
            return;

        if (!_KeyValuePairs.ContainsKey(key) && _KeyValuePairs.Count >= _Capacity)
        {
            var LRU_Node = _Values.Last;
            _KeyValuePairs.Remove(LRU_Node.Value.key);
            _Values.Remove(LRU_Node);
        }

        if (_KeyValuePairs.TryGetValue(key, out var Node))
        {
            if (Node != null)
            {
                _Values.Remove(Node);
            }
        }

        _Values.AddFirst((key, value));
        _KeyValuePairs[key] = _Values.First;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        LRUCache lRUCache = new LRUCache(2);

        lRUCache.Put(1, 1);
        lRUCache.Put(2, 2);
        Console.WriteLine(lRUCache.Get(1));
        lRUCache.Put(3, 3);
        Console.WriteLine(lRUCache.Get(2));
        lRUCache.Put(4, 4);
        Console.WriteLine(lRUCache.Get(1));
        Console.WriteLine(lRUCache.Get(3));
        Console.WriteLine(lRUCache.Get(4));

        //lRUCache.Put(2, 1);
        //lRUCache.Put(2, 2);
        //Console.WriteLine(lRUCache.Get(2));
        //lRUCache.Put(1, 1);
        //lRUCache.Put(4, 1);
        //Console.WriteLine(lRUCache.Get(2));


        Console.ReadKey();
    }

}

