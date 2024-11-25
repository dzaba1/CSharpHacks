using System.Runtime.CompilerServices;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
    {
    }
}

namespace WriteLine2
{
    public static class Interceptors
    {
        [InterceptsLocation(@"..\Program.cs", 1, 13)]
        public static void WriteLineInterceptor(this TextWriter cmd, string text)
        {
            var reversed = text.Reverse();
            var newStr = new string(reversed.ToArray());
            cmd.WriteLine(newStr);
        }
    }
}