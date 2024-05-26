public class Solution
{
    public static bool IsUgly(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        foreach (byte num in new byte[] { 2, 3, 5 })
        {
            while (n % num == 0)
            {
                n /= num;
            }
        }

        return (n == 1);
    }

    static void Main()
    {
        Console.WriteLine(IsUgly(7));
    }
}

