using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly IConsole _console;

        public HelpCommand(IConsole console)
        {
            _console = console;
        }

        public void Execute()
        {
            _console.WriteLine("This is the help page.");
        }
    }
}