using System;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd
{
    public class DefaultConsole : IConsole
    {
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
