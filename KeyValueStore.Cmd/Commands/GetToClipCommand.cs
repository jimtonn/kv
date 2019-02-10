using System.IO;
using System.Linq;
using System.Windows.Forms;
using KeyValueStore.Cmd.Exceptions;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class GetToClipCommand : ICommand
    {
        private readonly IDictionaryDeserializer _deserializer;
        private readonly string _file;
        private readonly string _key;

        public GetToClipCommand(IDictionaryDeserializer deserializer, string file, string[] remainingArgs)
        {
            _deserializer = deserializer;
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
                Clipboard.SetText(_deserializer.GetSingleValue(fs, _key));
            }

        }
    }
}