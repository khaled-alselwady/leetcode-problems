using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] Tokens = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

        Console.WriteLine(EvalRPN(Tokens));

        Console.ReadKey();
    }

    private static bool _IsOperator(string Operator)
    {
        return Operator == "+" || Operator == "-" || Operator == "*" || Operator == "/";
    }

    private static int _Calulate(string Operator, int Number2, int Number1)
    {
        // I always reverse the two parameters (Number2, Number1) to handle subtraction

        switch (Operator)
        {
            case "+":
                return Number1 + Number2;

            case "-":
                return Number1 - Number2;

            case "*":
                return Number1 * Number2;

            case "/":
                if (Number2 == 0)
                    return 0;

                return Number1 / Number2;

            default:
                return 0;
        }
    }

    public static int EvalRPN(string[] tokens)
    {
        if (tokens == null || tokens.Length == 0 ||
            _IsOperator(tokens[0]))
            return 0;

        if (tokens.Length == 1)
            return int.Parse(tokens[0]);

        if (tokens.Length == 2 && _IsOperator(tokens[1]))
            return 0;

        Stack<int> stkNumbers = new Stack<int>();

        foreach (string token in tokens)
        {
            if (_IsOperator(token))
                stkNumbers.Push(_Calulate(token, stkNumbers.Pop(), stkNumbers.Pop()));
            else
                stkNumbers.Push(int.Parse(token));
        }

        return stkNumbers.Pop();
    }

}

