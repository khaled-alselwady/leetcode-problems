using System;
using System.Collections.Generic;

public class Node
{
    public int Value;
    public Node Next;

    public Node(int Value = 0, Node Next = null)
    {
        this.Value = Value;
        this.Next = Next;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        List<Node> L1 = new List<Node>
        {
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null }
        };
        List<Node> L2 = new List<Node>
        {
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null },
           new Node { Value = 9, Next = null }
        };

        L1[0].Next = L1[1];
        L1[1].Next = L1[2];
        L1[2].Next = L1[3];
        L1[3].Next = L1[4];
        L1[4].Next = L1[5];
        L1[5].Next = L1[6];

        L2[0].Next = L2[1];
        L2[1].Next = L2[2];
        L2[2].Next = L2[3];

        List<Node> L3 = AddTwoNumbers(L1, L2);

        Console.Write("List 1: ");
        PrintList(L1);

        Console.Write("\n\nList 2: ");
        PrintList(L2);

        Console.Write("\n\nList 3: ");
        PrintList(L3);

        Console.ReadKey();
    }

    public static void PrintList(List<Node> L)
    {
        Console.Write("[");
        foreach (Node N in L)
        {
            if (N.Next != null)
                Console.Write(N.Value + ",");
            else
                Console.Write(N.Value);
        }
        Console.Write("]");
    }

    public static List<Node> AddTwoNumbers(List<Node> lst1, List<Node> lst2)
    {
        if (lst1 == null || lst2 == null)
            return null;

        if ((lst1.Count > 100 || lst1.Count < 1) ||
            (lst2.Count > 100 || lst2.Count < 1))
            return null;

        if (lst1[0].Value == 0 && lst1.Count > 1)
            lst1.RemoveAt(0);

        if (lst2[0].Value == 0 && lst2.Count > 1)
            lst2.RemoveAt(0);

        List<Node> lst3 = new List<Node>();

        lst3 = (lst1.Count >= lst2.Count) ? SumTwoLists(lst1, lst2) : SumTwoLists(lst2, lst1);

        return lst3;
    }

    public static List<Node> SumTwoLists(List<Node> lst1, List<Node> lst2)
    {
        List<Node> lstResult = new List<Node>();
        Node NodeSum = null;
        byte Remainder = 0;

        for (int i = 0; i < lst1.Count || Remainder != 0; i++)
        {
            int Value1 = (i < lst1.Count) ? lst1[i].Value : 0;
            int Value2 = (i < lst2.Count) ? lst2[i].Value : 0;

            int Sum = Value1 + Value2 + Remainder;
            Remainder = (byte)(Sum / 10);

            NodeSum = new Node(Sum % 10);

            if (i != 0)
            {
                lstResult[i - 1].Next = NodeSum;
            }

            lstResult.Add(NodeSum);
        }

        return lstResult;
    }
}


