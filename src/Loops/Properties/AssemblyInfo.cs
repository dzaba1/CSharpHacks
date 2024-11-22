namespace Loops;

public static class Extensions
{
    public static RangeEnumerator GetEnumerator(this int i)
    {
        var range = new Range(new Index(0), new Index(i));
        return new RangeEnumerator(range);
    }

    public static RangeEnumerator GetEnumerator(this Range i) => new RangeEnumerator(i);
}

public class RangeEnumerator
{
    private readonly Range range;
    private int current;

    public int Current => current - 1;

    public RangeEnumerator(Range range)
    {
        this.range = range;

        current = range.Start.Value;
    }

    public bool MoveNext()
    {
        if (current <= range.End.Value)
        {
            current += 1;
            return true;
        }

        return false;
    }
}