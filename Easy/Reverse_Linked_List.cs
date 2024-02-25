using System;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        TestReverseList();

        Console.ReadKey();
    }

    #region Test Solution

    private static void _PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

    // Test method
    public static void TestReverseList()
    {
        int[] inputArray = { 1, 2, 3, 4, 5 };
        ListNode head = _CreateLinkedList(inputArray);

        Console.WriteLine("Original List:");
        _PrintList(head);

        head = ReverseList2(head);

        Console.WriteLine("Reversed List:");
        _PrintList(head);
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
    #endregion

    #region approach 1

    private static void _InsertAtBeginning(ListNode MyNode, int Value)
    {
        if (MyNode == null) return;

        ListNode FirstNode = new ListNode { val = Value, next = MyNode.next };

        MyNode.next = FirstNode;
    }

    public static ListNode ReverseList(ListNode head)
    {
        if (head == null) return null;

        if (head.next == null) return head;

        ListNode TempNode = new ListNode(0);

        while (head != null)
        {
            _InsertAtBeginning(TempNode, head.val);
            head = head.next;
        }

        return TempNode.next;
    }

    #endregion

    #region approach 2
    public static ListNode ReverseList2(ListNode head)
    {
        if (head == null) return null;

        if (head.next == null) return head;

        ListNode Current = head;
        ListNode Previous = null;
        ListNode TempNode = null;

        while (Current != null)
        {
            TempNode = Current.next;
            Current.next = Previous;
            Previous = Current;
            Current = TempNode;
        }

        return Previous;
    }
    #endregion
}

