using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

public class Solution
{
    public static void Main(string[] args)
    {

        Console.WriteLine(IsValid("{[()(]}"));
        Console.ReadKey();
    }

    public static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char bracket in s)
        {
            if (IsOpeningBracket(bracket))
            {
                stack.Push(bracket);
            }
            else
            {
                if (stack.Count == 0 || !IsParenthesesValid(stack.Pop(), bracket))
                {
                    return false;
                }
            }
        }

        return (stack.Count == 0);
    }

    public static bool IsOpeningBracket(char bracket)
    {
        return bracket == '(' || bracket == '{' || bracket == '[';
    }

    public static bool IsParenthesesValid(char C1, char C2)
    {
        return (C1 == '(' && C2 == ')') ||
               (C1 == '{' && C2 == '}') ||
               (C1 == '[' && C2 == ']');
    }
}





