using ReadOnly;

var consts = new SomeConstants();

Console.WriteLine("ORIG");
PrintAll(consts);

Hack.Me(consts);

Console.WriteLine();
Console.WriteLine("HACKED");
PrintAll(consts);

void PrintAll(SomeConstants consts)
{
    consts.PrintAll();
    SomeStaticConstants.PrintAll();
}

class SomeConstants
{
    private static readonly string MyStaticValue = "My static value";
    private const string MyConstValue = "My const value";
    private readonly string myFieldValue = "My field value";

    public void PrintAll()
    {
        Console.WriteLine($"MyStaticValue: {MyStaticValue}");
        Console.WriteLine($"MyConstValue: {MyConstValue}");
        Console.WriteLine($"myFieldValue: {myFieldValue}");
    }
}

static class SomeStaticConstants
{
    private static readonly string MyStaticValue = "My static value in static class";
    private const string MyConstValue = "My const value in static class";

    public static void PrintAll()
    {
        Console.WriteLine($"MyStaticValue: {MyStaticValue}");
        Console.WriteLine($"MyConstValue: {MyConstValue}");
    }
}