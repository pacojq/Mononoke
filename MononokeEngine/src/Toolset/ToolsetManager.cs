namespace MononokeEngine.Toolset
{
    public class ToolsetManager
    {
        public TcpController TCP { get; }
        
        

        internal ToolsetManager()
        {
            TCP = new TcpController();
        }
    }
}