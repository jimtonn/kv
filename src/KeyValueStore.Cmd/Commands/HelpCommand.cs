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
            _console.WriteLine("kv v1.0.2");
            _console.WriteLine("General usage:");
            _console.WriteLine("  kv <path to store file> <verb> <additional parameters>");
            _console.WriteLine(@"E.g. to set a value in the default store (current folder\kvstore.txt):");
            _console.WriteLine(@"  kv set websites.logins.github myemail@address.com");
            _console.WriteLine(@"To set a value in a store in a custom location:");
            _console.WriteLine(@"  kv c:\temp\kv.txt set websites.logins.github myemail@address.com");
            _console.WriteLine(@"To get a value from the default store:");
            _console.WriteLine(@"  kv get websites.logins.github");
            _console.WriteLine(@"To get a value from a store in a custom location:");
            _console.WriteLine(@"  kv c:\temp\kv.txt get websites.logins.github");
            _console.WriteLine(@"To delete a key (and corresponding value) from a store:");
            _console.WriteLine(@"  kv delete websites.logins.github");
            _console.WriteLine(@"To show everything that's in a store");
            _console.WriteLine(@"  kv dump");
            _console.WriteLine(@"To show everything that's in a store in a custom location:");
            _console.WriteLine(@"  kv c:\temp\kv.txt dump");
            _console.WriteLine(@"NOTE: kv does not encrypt your data, but if you examine the store file you can see that values are Base64 encoded. This is done to simplify the storage of data that might have unusual values like Unicode characters or line breaks.");
            _console.WriteLine(string.Empty);
            _console.WriteLine("Fancy usage:");
            _console.WriteLine("To get a value from the default store and put it in the clipboard:");
            _console.WriteLine("   kv get mykey| clip");
            _console.WriteLine("To get a value from the default store and place it in a file:");
            _console.WriteLine("   kv get mykey > myfile.txt");
            _console.WriteLine(string.Empty);
            _console.WriteLine("If you are using kv in a batch file or other scripting context, note that it can have 5 different errorlevels:");
            _console.WriteLine("0 - Operation succeeded");
            _console.WriteLine("1 - Unknown error");
            _console.WriteLine("2 - Could not parse command line");
            _console.WriteLine("3 - Store file not found");
            _console.WriteLine("4 - Key not found");
        }
    }
}