using System;
using System.Collections.Generic;
using System.IO;
using KeyValueStore.Cmd.Commands;
using KeyValueStore.Cmd.Exceptions;

namespace KeyValueStore.Cmd
{
    class Program
    {
        private const int SUCCEEDED = 0;
        private const int COULD_NOT_PARSE_COMMAND = 1;
        private const int STORE_FILE_NOT_FOUND = 2;
        private const int KEY_NOT_FOUND = 3;
        private const int UNKNOWN_ERROR = 100;

        [STAThread]
        static int Main(string[] args)
        {
            var console = new DefaultConsole();
            var parser = new CommandLineParser(new Base64DictionaryDeserializer(), new Base64DictionarySerializer(), console);

            ICommand command;
            try
            {
                command = parser.Find(args);
            }
            catch(CommandParseException e)
            {
                console.WriteLine(e.Message);
                return COULD_NOT_PARSE_COMMAND;
            }

            try
            {
                command.Execute();
            }
            catch (KeyNotFoundException)
            {
                console.WriteLine("Requested key was not found.");
                return KEY_NOT_FOUND;
            }
            catch (FileNotFoundException)
            {
                console.WriteLine("Store file was not found.");
                return STORE_FILE_NOT_FOUND;
            }
            catch (Exception e)
            {
                console.WriteLine(e.Message);
                return UNKNOWN_ERROR;
            }

            return SUCCEEDED;
        }
    }
}
