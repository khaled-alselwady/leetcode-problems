using System;
using System.Collections.Generic;
using System.Linq;

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
        TestMergeLists();

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
    public static void TestMergeLists()
    {
        int[] inputArray1 = { -10, -10, -9, -4, 1, 6, 6 };
        ListNode head1 = _CreateLinkedList(inputArray1);

        int[] inputArray2 = { -7 };
        ListNode head2 = _CreateLinkedList(inputArray2);

        Console.WriteLine("Original List1:");
        _PrintList(head1);

        Console.WriteLine("\nOriginal List2:");
        _PrintList(head2);

        ListNode head3 = MergeTwoLists2(head1, head2);

        Console.WriteLine("Merge Lists:");
        _PrintList(head3);
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
    private static ListNode _ConvertFromListToNodes(List<sbyte> Result)
    {
        if (Result == null || Result.Count == 0)
            return null;

        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        foreach (sbyte Number in Result)
        {
            current.next = new ListNode(Number);
            current = current.next;
        }

        return dummy.next;
    }

    private static void _AddDuplicateNumbersToList(List<sbyte> Result, sbyte Number, sbyte Count)
    {
        if (Count == 0)
            return;

        for (int i = 0; i < Count; i++)
            Result.Add(Number);
    }

    private static List<sbyte> _ConvertFromNodesToList(ListNode head)
    {
        if (head == null)
            return new List<sbyte>();

        List<sbyte> result = new List<sbyte>();

        while (head != null)
        {
            result.Add((sbyte)head.val);
            head = head.next;
        }

        return result;
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        List<sbyte> ListNumbers1 = _ConvertFromNodesToList(list1);
        List<sbyte> ListNumbers2 = _ConvertFromNodesToList(list2);

        List<sbyte> Result = new List<sbyte>();

        sbyte StartNumber = Math.Min(ListNumbers1[0], ListNumbers2[0]);
        sbyte EndNumber = Math.Max(ListNumbers1[ListNumbers1.Count - 1], ListNumbers2[ListNumbers2.Count - 1]);

        for (sbyte i = StartNumber; i <= EndNumber; i++)
        {
            if (ListNumbers1.Contains(i))
                _AddDuplicateNumbersToList(Result, i, (sbyte)ListNumbers1.Count(x => x == i));

            if (ListNumbers2.Contains(i))
                _AddDuplicateNumbersToList(Result, i, (sbyte)ListNumbers2.Count(x => x == i));
        }

        ListNode head = _ConvertFromListToNodes(Result);

        return head;
    }
    #endregion

    #region Approach 2
    public static ListNode MergeTwoLists2(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        if (list1 != null)
        {
            current.next = list1;
        }
        else
        {
            current.next = list2;
        }

        return dummy.next;
    }
    #endregion
}

