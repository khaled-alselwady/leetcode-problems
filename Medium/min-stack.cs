using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        MinStack minStack = new MinStack();
        minStack.Push(2);
        minStack.Push(0);
        minStack.Push(3);
        minStack.Push(0);
        Console.WriteLine($"{minStack.GetMin()}"); // return 0
        minStack.Pop();
        Console.WriteLine($"{minStack.GetMin()}"); // return 0
        minStack.Pop();    // return 0
        Console.WriteLine($"{minStack.GetMin()}"); // return 0
        minStack.Pop();    // return 0
        Console.WriteLine($"{minStack.GetMin()}"); // return 2


        Console.ReadKey();
    }
}

public class MinStack
{
    private Stack<int> _TempStack;
    private Stack<int> _TempMinStack;

    public MinStack()
    {
        _TempStack = new Stack<int>();
        _TempMinStack = new Stack<int>();
    }

    public void Push(int val)
    {
        _TempStack.Push(val);

        int MinNumber = (_TempMinStack.Count > 0) ? Math.Min(val, _TempMinStack.Peek()) : val;

        _TempMinStack.Push(MinNumber);
    }

    public void Pop()
    {
        _TempStack.Pop();
        _TempMinStack.Pop();
    }

    public int Top() => _TempStack.Peek();

    public int GetMin() => _TempMinStack.Peek();
}
