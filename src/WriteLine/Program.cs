using System;

namespace WriteLine;

internal class Program
{
    public static void Main(string[] args)
    {
        String s = "Hello World!";

        Console.WriteLine(s);
        Console.Out.WriteLine("Hello World!");
        _ = Console.Out << s << "test";
    }
}