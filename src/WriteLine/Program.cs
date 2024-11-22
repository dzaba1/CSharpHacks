using System;

namespace WriteLine;

internal class Program
{
    public static void Main(string[] args)
    {
        String s = "Hello World!";

        Console.WriteLine(s);
        _ = Console.Out << s << "test";
    }
}