using System.IO;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

namespace System
{
    public class String(string realString)
    {
        public static implicit operator String(string s) => new String(s);
        public static implicit operator string(String s) => s.ToString();

        public override string ToString()
        {
            var reversed = realString.Reverse();
            return new string(reversed.ToArray());
        }
    }
}

namespace WriteLine
{
    //public static class Console
    //{
    //    public static void WriteLine(string s)
    //    {
    //        System.Console.WriteLine(s);
    //    }

    //    public static ConsoleTextWriter Out => new ConsoleTextWriter();
    //}

    //public class ConsoleTextWriter
    //{
    //    public void WriteLine(string s)
    //    {
    //        System.Console.WriteLine(s);
    //    }

    //    public static ConsoleTextWriter operator <<(ConsoleTextWriter writer, string s)
    //    {
    //        System.Console.WriteLine(s);
    //        return writer;
    //    }
    //}

    //public static class Interceptors
    //{
    //    [InterceptsLocation(@"..\Program.cs", 12, 21)]
    //    public static void WriteLineInterceptor(this TextWriter cmd, string text)
    //    {
    //        var reversed = text.Reverse();
    //        var newStr = new string(reversed.ToArray());
    //        cmd.WriteLine(newStr);
    //    }
    //}
}

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
    {
    }
}