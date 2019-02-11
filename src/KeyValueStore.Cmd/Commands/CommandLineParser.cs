using System.IO;
using System.Linq;
using KeyValueStore.Cmd.Exceptions;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd.Commands
{
    public class CommandLineParser : ICommandLineParser
    {
        private static readonly string[] VALID_VERBS = { "help", "dump", "set", "get", "delete" };
        private const string VERB_NOT_FOUND_MESSAGE = "Verb not found. Valid verbs are help, dump, set, get, delete.";

        private readonly IDictionaryDeserializer _deserializer;
        private readonly IDictionarySerializer _serializer;
        private readonly IConsole _console;

        public CommandLineParser(IDictionaryDeserializer deserializer, IDictionarySerializer serializer, IConsole console)
        {
            _deserializer = deserializer;
            _serializer = serializer;
            _console = console;
        }

        public ICommand Find(string[] args)
        {
            if (!args.Any())
            {
                throw new CommandParseException(VERB_NOT_FOUND_MESSAGE);
            }

            string file;
            string verb;
            string[] remainingArgs;

            if (VALID_VERBS.Contains(args[0].ToLower()))
            {
                //file is omitted. use default
                verb = args[0];
                file = "kvstore.txt";
                remainingArgs = args.Skip(1).ToArray();
            }
            else
            {
                //since verb did not come first, assume that the first parameter is the file, and then there must be a verb after it
                if (args.Length < 2)
                {
                    throw new CommandParseException(VERB_NOT_FOUND_MESSAGE);
                }
                file = args[0];
                verb = args[1];
                remainingArgs = args.Skip(2).ToArray();
            }

            switch (verb) {
                case "dump":
                    return new DumpCommand(_deserializer, _console, file);
                case "set":
                    return new SetCommand(_deserializer, _serializer, file, remainingArgs);
                case "get":
                    return new GetCommand(_deserializer, _console, file, remainingArgs);
                case "delete":
                    return new DeleteCommand(_deserializer, _serializer, file, remainingArgs);
                case "help":
                    return new HelpCommand(_console);
                default:
                    throw new CommandParseException($"Unknown verb: {verb}");
            }
        }
    }
}