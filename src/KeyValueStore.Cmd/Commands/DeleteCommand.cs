using System.Collections.Generic;
using System.IO;
using System.Linq;
using KeyValueStore.Cmd.Exceptions;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly IDictionaryDeserializer _deserializer;
        private readonly IDictionarySerializer _serializer;
        private readonly string _storeFile;
        private readonly string _key;

        public DeleteCommand(IDictionaryDeserializer deserializer, IDictionarySerializer serializer, string storeFile, string[] remainingArgs)
        {
            _deserializer = deserializer;
            _serializer = serializer;
            _storeFile = storeFile;

            if (!remainingArgs.Any())
            {
                throw new CommandParseException("Key not provided.");
            }

            _key = remainingArgs[0];
        }

        public void Execute()
        {
            IDictionary<string, string> dictionary;
            using (var fs = new FileStream(_storeFile, FileMode.Open))
            {
               dictionary = _deserializer.FullDeserialize(fs);
            }

            dictionary.Remove(_key);                

            using (var fs = new FileStream(_storeFile, FileMode.Create))
            {
                _serializer.Serialize(dictionary, fs);
            }
        }
    }
}