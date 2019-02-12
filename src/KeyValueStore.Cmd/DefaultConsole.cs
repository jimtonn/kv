using System;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd
{
    public class DefaultConsole : IConsole
    {
        public void WriteLine(string text) => Console.WriteLine(text);
        public void Write(string text) => Console.Write(text);
    }
}
