namespace KeyValueStore.Cmd.Commands
{
    public interface ICommandLineParser
    {
        ICommand Find(string[] args);
    }

    public interface ICommand
    {
        void Execute();
    }
}
