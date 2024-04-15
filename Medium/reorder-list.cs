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
        TestReorderList();

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
    public static void TestReorderList()
    {
        int[] inputArray1 = { 1, 2, 3, 4, 5 };
        ListNode head = _CreateLinkedList(inputArray1);

        Console.WriteLine("Original List:");
        _PrintList(head);

        ReorderList2(head);

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

    #region Appraoch 1
    private static ListNode _ReverseList(ListNode head)
    {
        if (head == null) return null;
        if (head.next == null) return head;

        ListNode Current = head;
        ListNode Previous = null;
        ListNode Temp = null;

        while (Current != null)
        {
            Temp = Current.next;
            Current.next = Previous;
            Previous = Current;
            Current = Temp;
        }

        return Previous;
    }

    public static void ReorderList(ListNode head)
    {
        if (head == null || head.next == null) return;

        ListNode CurrentNode = head;
        ListNode ResultOfReverse = null;

        while (CurrentNode != null)
        {
            ResultOfReverse = _ReverseList(CurrentNode.next);

            CurrentNode.next = ResultOfReverse;

            CurrentNode = CurrentNode.next;
        }
    }
    #endregion

    #region Appraoch 2
    private static ListNode _FindMiddle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private static ListNode _MergeLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode();
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            current.next = list1;
            list1 = list1.next;
            current = current.next;
            current.next = list2;
            list2 = list2.next;
            current = current.next;
        }

        if (list1 != null)
        {
            current.next = list1;
        }
        if (list2 != null)
        {
            current.next = list2;
        }

        return dummy.next;
    }

    public static void ReorderList2(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        ListNode middle = _FindMiddle(head);
        ListNode secondHalf = middle.next;
        middle.next = null;

        secondHalf = _ReverseList(secondHalf);

        head = _MergeLists(head, secondHalf);
    }
    #endregion
}

