using System;
using System.Collections.Generic;
using System.IO;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class SetCommand : ICommand
    {
        private readonly IDictionaryDeserializer _deserializer;
        private readonly IDictionarySerializer _serializer;
        private readonly string _storeFile;
        private readonly string _key;
        private readonly string _value;

        public SetCommand(IDictionaryDeserializer deserializer, IDictionarySerializer serializer, string storeFile, string[] args)
        {
            _deserializer = deserializer;
            _serializer = serializer;
            _storeFile = storeFile;
            _key = args[0];
            _value = args[1];
        }

        public void Execute()
        {
            IDictionary<string, string> dictionary;

            if (!File.Exists(_storeFile))
            {
                using (File.Create(_storeFile)) { }
            }

            using (var fs = new FileStream(_storeFile, FileMode.Open))
            {
               dictionary = _deserializer.FullDeserialize(fs);
            }
            dictionary[_key] = _value;

            using (var fs = new FileStream(_storeFile, FileMode.Create))
            {
                _serializer.Serialize(dictionary, fs);
            }
        }
    }
}