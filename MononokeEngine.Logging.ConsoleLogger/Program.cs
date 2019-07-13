namespace MononokeEngine.Logging.ConsoleLogger
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            new ConsoleLoggerClient().Run();
        }
    }
}