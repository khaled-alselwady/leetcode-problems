public class Solution
{
    private static int _SumAllDivisors(int number)
    {
        int sum = 0;

        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }

        return sum;
    }

    public static bool CheckPerfectNumber(int number)
        => number == _SumAllDivisors(number);

    static void Main()
    {
        Console.WriteLine(CheckPerfectNumber(28));
    }
}

