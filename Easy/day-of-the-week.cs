public class Solution
{
    #region Without Using Built-In Functions
    public static byte DayOfWeekOrder(int day, int month, int year)
    {
        short a, y, m;
        a = (short)((14 - month) / 12);
        y = (short)(year - a);
        m = (short)(month + (12 * a) - 2);
        // Gregorian://0:sun, 1:Mon, 2:Tue...etc
        return (byte)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);
    }

    public static string DayOfTheWeek(int day, int month, int year)
    {
        byte dayOfWeekOrder = DayOfWeekOrder(day, month, year);

        string[] arrDayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        return arrDayNames[dayOfWeekOrder];
    }
    #endregion

    #region Using Built-In Functions
    public static string DayOfTheWeek2(int day, int month, int year)
    {
        DateTime date = new(year, month, day);
        return date.DayOfWeek.ToString();
    }
    #endregion

    private static void Main()
    {
        Console.WriteLine(DayOfTheWeek2(31, 8, 2019));

        Console.ReadKey();
    }
}