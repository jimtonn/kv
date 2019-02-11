using System.Collections.Generic;
using System.IO;

namespace KeyValueStore.Cmd.Interfaces
{
    public interface IDictionaryDeserializer
    {
        IDictionary<string, string> FullDeserialize(Stream inStream);

        string GetSingleValue(Stream inStream, string requestedKey);
    }
}
