using System.IO;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class DumpCommand : ICommand
    {
        private readonly IDictionaryDeserializer _deserializer;
        private readonly IConsole _console;
        private readonly string _storeFile;

        public DumpCommand(IDictionaryDeserializer deserializer, IConsole console, string storeFile)
        {
            _deserializer = deserializer;
            _console = console;
            _storeFile = storeFile;
        }

        public void Execute()
        {
            using (var fs = new FileStream(_storeFile, FileMode.Open))
            {
                var dictionary = _deserializer.FullDeserialize(fs);
                foreach (var kv in dictionary)
                {
                    _console.WriteLine($"{kv.Key}: {kv.Value}");
                }
            }
        }
    }
}