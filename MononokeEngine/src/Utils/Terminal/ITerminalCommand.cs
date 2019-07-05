namespace MononokeEngine.Utils.Terminal
{
    public interface ITerminalCommand
    {
        void Execute(string[] arguments);
    }
}