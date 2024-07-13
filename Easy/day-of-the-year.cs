public class Solution
{
    #region Without Using Built-In Functions
    public static bool IsLeapYear(short year)
  => (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

    public static byte DaysInMonth(short year, byte month)
    {
        if (month < 1 || month > 12)
        {
            return 0;
        }

        byte[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        return (month == 2) ? (byte)(IsLeapYear(year) ? 29 : 28) : (daysInMonth[month]);
    }

    public static int DayOfYear(string date)
    {
        if (!DateTime.TryParse(date, out DateTime dateObject))
        {
            return -1;
        }

        int totalDays = 0;

        for (byte i = 1; i < dateObject.Month; i++)
        {
            totalDays += DaysInMonth((short)dateObject.Year, i);
        }

        return (totalDays + dateObject.Day);
    }
    #endregion

    #region Using Built-In Functions
    public static int DayOfYear2(string date)
    {
        if (!DateTime.TryParse(date, out DateTime dateObject))
        {
            return -1;
        }

        return dateObject.DayOfYear;
    }
    #endregion

    private static void Main()
    {
        Console.WriteLine(DayOfYear("2019-02-10"));
        Console.ReadKey();
    }
}