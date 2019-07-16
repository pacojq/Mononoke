using System;

namespace MononokeEngine.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}