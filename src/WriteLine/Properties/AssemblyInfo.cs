using System.Linq;

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
    public static class Console
    {
        public static void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }

        public static ConsoleTextWriter Out => new ConsoleTextWriter();
    }

    public class ConsoleTextWriter
    {
        public static ConsoleTextWriter operator <<(ConsoleTextWriter writer, string s)
        {
            System.Console.WriteLine(s);
            return writer;
        }
    }
}
