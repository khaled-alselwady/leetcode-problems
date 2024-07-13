public class Solution
{
    private static void SwapDates(ref DateTime date1, ref DateTime date2)
    {
        (date1, date2) = (date2, date1);
    }

    public static int DaysBetweenDates(string date1, string date2)
    {
        if (!DateTime.TryParse(date1, out DateTime startDate) ||
            !DateTime.TryParse(date2, out DateTime endDate))
        {
            return 0;
        }

        if (startDate > endDate)
        {
            SwapDates(ref startDate, ref endDate);
        }

        return (endDate - startDate).Days;
    }

    private static void Main()
    {
        Console.WriteLine(DaysBetweenDates("2019-06-29", "2019-06-30"));

        Console.ReadKey();
    }
}