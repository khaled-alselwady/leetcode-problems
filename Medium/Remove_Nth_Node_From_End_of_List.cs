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
        TestRemoveNthFromEndList();

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
    public static void TestRemoveNthFromEndList()
    {
        int[] inputArray1 = { 1, 2, 3, 4, 5 };
        ListNode head = _CreateLinkedList(inputArray1);

        Console.WriteLine("Original List:");
        _PrintList(head);

        head = RemoveNthFromEnd2(head, 2);

        Console.WriteLine("Reorder List:");
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

    #region Approach 1
    private static byte _GetTheLengthOfLikedList(ListNode head)
    {
        byte Length = 0;

        while (head != null)
        {
            Length++;
            head = head.next;
        }

        return Length;
    }

    private static ListNode _RemoveAt(ListNode head, byte Position)
    {
        if (head == null)
            return head;

        byte Counter = 0;

        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (head != null)
        {
            Counter++;

            if (Counter == Position)
            {
                head = head.next;
                continue;
            }

            current.next = new ListNode(head.val);
            current = current.next;

            head = head.next;
        }

        return dummy.next;
    }

    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head == null || head.next == null || n == 0)
            return null;

        byte Length = _GetTheLengthOfLikedList(head);

        if (n > Length)
            return head;

        byte PositionToDelete = (byte)(Length - n + 1);

        return _RemoveAt(head, PositionToDelete);
    }
    #endregion

    #region Approach 2
    public static ListNode RemoveNthFromEnd2(ListNode head, int n)
    {
        if (head == null || head.next == null || n == 0)
            return null;

        ListNode Dummy = new ListNode(0, head);
        ListNode Start = Dummy;
        ListNode End = head;

        for (byte i = 0; i < n && End != null; i++)
        {
            End = End.next;
        }

        while (End != null)
        {
            Start = Start.next;
            End = End.next;
        }

        // Delete the required node
        Start.next = Start.next.next;

        return Dummy.next;
    }
    #endregion
}

