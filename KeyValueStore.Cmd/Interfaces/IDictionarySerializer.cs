using System.Collections.Generic;
using System.IO;

namespace KeyValueStore.Cmd.Interfaces
{
    public interface IDictionarySerializer
    {
        void Serialize(IDictionary<string, string> store, Stream outStream);
    }
}
