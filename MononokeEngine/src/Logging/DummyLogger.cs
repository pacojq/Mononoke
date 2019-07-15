namespace MononokeEngine.Logging
{
    
    /// <summary>
    /// Dummy logger for release configuration
    /// </summary>
    internal class DummyLogger : ILogger
    {
        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Print(string msg)
        {
            // Do nothing
        }
    }
}