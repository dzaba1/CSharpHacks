namespace Lock;

internal class Program
{
    public static void Main(string[] args)
    {
        var syncLock = new object();

        lock (syncLock)
        {
            Console.WriteLine("The thread is safe");
        }
    }
}