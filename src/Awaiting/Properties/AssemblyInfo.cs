using MyCopilot;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Awaiting;

public static class Extensions
{
    public static TimeSpanAwaiter GetAwaiter(this TimeSpan x) => new TimeSpanAwaiter(x);

    public static TimeSpanAwaiter GetAwaiter(this string x)
    {
        var split = x.Split(' ');

        // TimeSpan
        if (split.Length == 2)
        {
            var value = double.Parse(split[0]);
            if (split[1] == "seconds" || split[1] == "second")
            {
                return GetAwaiter(TimeSpan.FromSeconds(value));
            }
            if (split[1] == "minutes" || split[1] == "minute")
            {
                return GetAwaiter(TimeSpan.FromMinutes(value));
            }

            // https://github.com/AntonBergaker/InterpolatedParser
            //int seconds = 0;
            //InterpolatedParsing.InterpolatedParser.Parse($"{seconds} seconds", x);
            //return GetAwaiter(TimeSpan.FromSeconds(value));
        }

        // DateTime
        split = x.Split('.', '/');
        if (split.Length == 3)
        {
            var dateValues = split.Select(int.Parse).ToArray();
            return GetAwaiter(new DateTime(dateValues[2], dateValues[1], dateValues[0]));
        }

        // AI
        var ai = new DateTimeAssistant();
        var aiDate = ai.AskForDateAsync(x).Result.Value;
        return GetAwaiter(aiDate);
    }

    public static TimeSpanAwaiter GetAwaiter(this DateTime x)
    {
        var span = x - DateTime.Today;
        return new TimeSpanAwaiter(span);
    }

    public static TimeSpanAwaiter GetAwaiter(this DatePart x)
    {
        var parts = EnumerateDatePartsFromEnd(x)
            .OrderBy(p => p.Type)
            .ToArray();

        var date = new DateTime(parts[2].Value, parts[1].Value, parts[0].Value);
        return GetAwaiter(date);
    }

    private static IEnumerable<DatePart> EnumerateDatePartsFromEnd(this DatePart current)
    {
        DatePart temp = current;
        while (temp != null)
        {
            yield return temp;
            temp = temp.Prev;
        }
    }
}

public static class Months
{
    public static DateTime November(this int day, int year)
    {
        return new DateTime(year, 11, day);
    }
}

public class TimeSpanAwaiter : INotifyCompletion
{
    private readonly TaskAwaiter awaiter;

    public TimeSpanAwaiter(TimeSpan span)
    {
        Debug.WriteLine($"TimeSpan: {span}");
        awaiter = Task.Delay(span).GetAwaiter();
    }

    public bool IsCompleted => awaiter.IsCompleted;

    public void GetResult() => awaiter.GetResult();

    public void OnCompleted(Action continuation) => awaiter.OnCompleted(continuation);
}

public enum DatePartType
{
    Day, Month, Year
}

public class DatePart
{
    public DatePartType? Type { get; set; }
    public int Value { get; set; }
    public DatePart? Prev { get; set; }

    public static implicit operator DatePart(int value)
    {
        var result = new DatePart
        {
            Value = value
        };

        if (value > 2000)
        {
            result.Type = DatePartType.Year;
        }

        return result;
    }

    public static DatePart operator /(DatePart prev, DatePart next)
    {
        if (prev.Type == null && next.Type == DatePartType.Month)
        {
            prev.Type = DatePartType.Day;
        }

        if (prev.Type == null && next.Type == DatePartType.Day)
        {
            prev.Type = DatePartType.Month;
        }

        if (next.Type == null && prev.Type == DatePartType.Day)
        {
            next.Type = DatePartType.Month;
        }

        if (next.Type == null && prev.Type == DatePartType.Month)
        {
            next.Type = DatePartType.Day;
        }

        return new DatePart
        {
            Prev = prev,
            Type = next.Type,
            Value = next.Value
        };
    }
}

public class Month : DatePart
{
    public static implicit operator Month(int value) => new Month
    {
        Value = value,
        Type = DatePartType.Month
    };
}

public class Day : DatePart
{
    public static implicit operator Day(int value) => new Day
    {
        Value = value,
        Type = DatePartType.Day
    };
}