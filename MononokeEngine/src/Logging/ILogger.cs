namespace MononokeEngine.Logging
{
    public interface ILogger
    {

        void Open();

        void Close();
        
        
        void Print(string msg);
    }
}