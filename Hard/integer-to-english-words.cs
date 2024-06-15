public class Solution
{
    private static bool _IsRemainderZero(int num, int divisionBy)
        => (num % divisionBy) == 0;

    public static string NumberToWords(int num)
    {
        if (num == 0)
        {
            return "Zero";
        }

        if (num >= 1 && num <= 19)
        {
            string[] arr = { "", "One", "Two", "Three", "Four", "Five",
                            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                            "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                            "Eighteen", "Nineteen" };

            return arr[num];
        }

        if (num >= 20 && num <= 99)
        {
            string[] arr = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
                            "Seventy", "Eighty", "Ninety" };

            return $"{arr[num / 10]} {(_IsRemainderZero(num, 10) ? string.Empty : NumberToWords(num % 10))}".Trim();
        }

        if (num >= 100 && num <= 999)
        {
            return $"{NumberToWords(num / 100)} Hundred {(_IsRemainderZero(num, 100) ? string.Empty : NumberToWords(num % 100))}".Trim();
        }

        if (num >= 1000 && num <= 999999)
        {
            return $"{NumberToWords(num / 1000)} Thousand {(_IsRemainderZero(num, 1000) ? string.Empty : NumberToWords(num % 1000))}".Trim();
        }

        if (num >= 1000000 && num <= 999999999)
        {
            return $"{NumberToWords(num / 1000000)} Million {(_IsRemainderZero(num, 1000000) ? string.Empty : NumberToWords(num % 1000000))}".Trim();
        }

        if (num >= 1000000000)
        {
            return $"{NumberToWords(num / 1000000000)} Billion {(_IsRemainderZero(num, 1000000000) ? string.Empty : NumberToWords(num % 1000000000))}".Trim();
        }

        return string.Empty;
    }

    static void Main()
    {
        Console.WriteLine(NumberToWords(110));
        Console.ReadKey();
    }
}

