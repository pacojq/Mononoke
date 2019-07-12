namespace MononokeEngine.Terminal
{
    public interface ITerminalCommand
    {
        void Execute(string[] arguments);
    }
}