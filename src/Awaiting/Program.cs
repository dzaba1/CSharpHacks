﻿namespace Awaiting;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine(DateTime.Now);

        //await Task.Delay(TimeSpan.FromSeconds(2));
        //await TimeSpan.FromSeconds(2);
        //await "2 seconds";

        //await Task.Delay(new DateTime(2024, 11, 30) - DateTime.Now);
        //await new DateTime(2024, 11, 30);
        //await "30.11.2024";
        //await "30/11/2024";
        //await (30 / (Month)11 / 2024);
        //await 30.November(2024);
        //await "next Ben Stiller birthday";

        Console.WriteLine(DateTime.Now);
    }
}