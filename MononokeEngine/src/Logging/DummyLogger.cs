namespace MononokeEngine.Logging
{
    
    /// <summary>
    /// Dummy logger for release configuration
    /// </summary>
    internal class DummyLogger : ILogger
    {
        public void Print(string msg)
        {
            // Do nothing
        }
    }
}