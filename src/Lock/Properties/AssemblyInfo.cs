namespace System.Threading
{
    public static class Monitor
    {
        public static void Enter(object obj, ref bool lockTaken)
        {
            lockTaken = true;
            Console.WriteLine("YOU HAVE BEEN HACKED!!!");
        }

        public static void Exit(object obj)
        {
            Console.WriteLine("AHAHAHAHAHAHAHAHA");
        }
    }
}
