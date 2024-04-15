using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        TestHasCycle();

        Console.ReadKey();
    }

    #region Test Solution
    // Test method
    public static void TestHasCycle()
    {
        // Create a linked list with a cycle
        int[] inputArray1 = { 3, 2, 0, -4 };
        ListNode headWithCycle = _CreateLinkedListWithCycle(inputArray1, 1);

        Console.WriteLine("Linked List with Cycle:");
        _PrintList(headWithCycle);

        // Check if the linked list has a cycle
        bool hasCycle = HasCycle(headWithCycle);
        Console.WriteLine("Has Cycle: " + hasCycle);

        // Create a linked list without a cycle
        int[] inputArray2 = { 3, 2, 0, -4 };
        ListNode headWithoutCycle = _CreateLinkedList(inputArray2);

        Console.WriteLine("Linked List without Cycle:");
        _PrintList(headWithoutCycle);

        // Check if the linked list has a cycle
        bool hasCycle2 = HasCycle(headWithoutCycle);
        Console.WriteLine("Has Cycle: " + hasCycle2);
    }

    // Utility method to create a linked list from an array with a cycle
    private static ListNode _CreateLinkedListWithCycle(int[] arr, int pos)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        ListNode cycleStart = null;

        for (int i = 0; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
            if (i == pos)
                cycleStart = current;
        }
        // Create the cycle
        current.next = cycleStart;

        return dummy.next;
    }

    // Utility method to create a linked list from an array
    private static ListNode _CreateLinkedList(int[] arr)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        foreach (int num in arr)
        {
            current.next = new ListNode(num);
            current = current.next;
        }
        return dummy.next;
    }

    // Utility method to print the linked list
    private static void _PrintList(ListNode head)
    {
        ListNode current = head;
        int count = 0;
        while (current != null && count < 10) // To avoid infinite loop for cyclic lists
        {
            Console.Write(current.val + " ");
            current = current.next;
            count++;
        }
        Console.WriteLine();
    }

    #endregion

    #region Appraoch 1
    public static bool HasCycle(ListNode head)
    {
        if (head == null || head.next == null)
            return false;

        ListNode Slow = head, Fast = head;

        while (Fast != null && Fast.next != null)
        {
            Slow = Slow.next;
            Fast = Fast.next.next;

            if (Slow.Equals(Fast))
                return true;
        }

        return false;
    }
    #endregion

    #region Approach 2
    public static bool HasCycle2(ListNode head)
    {
        if (head == null || head.next == null)
            return false;

        HashSet<ListNode> SeenNodes = new HashSet<ListNode>();

        while (head != null)
        {
            if (SeenNodes.Contains(head))
                return true;

            SeenNodes.Add(head);

            head = head.next;
        }

        return false;
    }
    #endregion
}

