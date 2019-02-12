using System.IO;
using System.Linq;
using KeyValueStore.Cmd.Exceptions;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class GetCommand : ICommand
    {
        private readonly IDictionaryDeserializer _deserializer;
        private readonly IConsole _console;
        private readonly string _file;
        private readonly string _key;

        public GetCommand(IDictionaryDeserializer deserializer, IConsole console, string file, string[] remainingArgs)
        {
            _deserializer = deserializer;
            _console = console;
            _file = file;

            if (!remainingArgs.Any())
            {
                throw new CommandParseException("Key not provided.");
            }

            _key = remainingArgs[0];
        }

        public void Execute()
        {
            using (var fs = new FileStream(_file, FileMode.Open))
            {
               _console.Write(_deserializer.GetSingleValue(fs, _key));
            }
        }
    }
}