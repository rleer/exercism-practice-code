using System;
using System.Linq;
using System.Linq.Expressions;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;
    
    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var daysAsArray = Enumerable.Range(1, DateTime.DaysInMonth(_year, _month))
            .Select(d => new DateTime(_year, _month, d))
            .Where(d => d.DayOfWeek == dayOfWeek)
            .ToArray();
        switch (schedule)
        {
            case Schedule.Last:
                return daysAsArray[^1];
            case Schedule.Teenth:
                return daysAsArray.First(d => d.Day is >= 13 and <= 19);
            default:
                return daysAsArray[(int)schedule - 1];
        }
    }
}