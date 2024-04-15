using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        TestCopyRandomList();

        Console.ReadKey();
    }

    #region Test Solution
    private static void _PrintList(Node head)
    {
        Node current = head;
        while (current != null)
        {
            Console.Write($"[{current.val},{_GetRandomIndex(current.random)}] ");
            current = current.next;
        }
        Console.WriteLine();
    }

    // Utility method to get the index of the random node
    private static int _GetRandomIndex(Node randomNode)
    {
        if (randomNode == null)
            return -1;

        Node current = randomNode;
        int index = 0;
        while (current.next != null)
        {
            current = current.next;
            index++;
        }
        return index;
    }

    // Test method
    public static void TestCopyRandomList()
    {
        // Example 1
        int[][] inputArray1 = { new int[] { 7, -1 }, new int[] { 13, 0 }, new int[] { 11, 4 }, new int[] { 10, 2 }, new int[] { 1, 0 } };
        Node head1 = _CreateRandomLinkedList(inputArray1);

        Console.WriteLine("Original List:");
        _PrintList(head1);

        Node copiedHead1 = CopyRandomList(head1);

        Console.WriteLine("Copied List:");
        _PrintList(copiedHead1);
    }

    // Utility method to create a linked list from an array with random pointers
    private static Node _CreateRandomLinkedList(int[][] arr)
    {
        if (arr == null || arr.Length == 0)
            return null;

        Node dummy = new Node(0);
        Node current = dummy;
        Dictionary<int, Node> indexNodeMap = new Dictionary<int, Node>();

        // Create nodes without random pointers
        foreach (int[] nodeData in arr)
        {
            Node newNode = new Node(nodeData[0]);
            current.next = newNode;
            current = current.next;
            indexNodeMap.Add(indexNodeMap.Count, newNode);
        }

        // Assign random pointers based on the provided indices
        current = dummy.next;
        //int index = 0;
        foreach (int[] nodeData in arr)
        {
            if (nodeData[1] != -1)
            {
                current.random = indexNodeMap[nodeData[1]];
            }
            current = current.next;
            //index++;
        }

        return dummy.next;
    }
    #endregion

    private static void _MappingOriginalNodesWithCopyNodes(Node currentCopy, Dictionary<Node, Node> originalCopyMap, Node currentOriginal)
    {
        while (currentOriginal != null)
        {
            // Create a copy of the current node
            Node newNode = new Node(currentOriginal.val);
            originalCopyMap.Add(currentOriginal, newNode);

            currentCopy.next = newNode;
            currentCopy = currentCopy.next;

            currentOriginal = currentOriginal.next;
        }
    }

    private static void _AssignRandomPointersToCopyNodes(Node currentCopy, Dictionary<Node, Node> originalCopyMap, Node currentOriginal)
    {
        while (currentOriginal != null)
        {
            if (currentOriginal.random != null)
            {
                currentCopy.random = originalCopyMap[currentOriginal.random];
            }

            currentCopy = currentCopy.next;

            currentOriginal = currentOriginal.next;
        }
    }

    public static Node CopyRandomList(Node head)
    {
        Node dummy = new Node(0);
        Node currentCopy = dummy;
        Dictionary<Node, Node> originalCopyMap = new Dictionary<Node, Node>();

        Node currentOriginal = head;
        _MappingOriginalNodesWithCopyNodes(currentCopy, originalCopyMap, currentOriginal);

        // Reset pointers for traversal
        currentOriginal = head;
        currentCopy = dummy.next;
        _AssignRandomPointersToCopyNodes(currentCopy, originalCopyMap, currentOriginal);

        return dummy.next;
    }
}

