using System.Collections.Generic;
using System.IO;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd
{
    /// <summary>
    /// Base64 is used here to simplify the storage of special characters and binary data.
    /// Base64 does not encrypt your data or keep it secret.
    /// </summary>
    public class Base64DictionarySerializer : IDictionarySerializer
    {
        public void Serialize(IDictionary<string, string> dictionary, Stream outStream)
        {
            using (var sw = new StreamWriter(outStream))
            {
                foreach (var kv in dictionary)
                {
                    sw.WriteLine(kv.Key);
                    sw.WriteLine(Base64.Base64Encode(kv.Value));
                }
            }
        }
    }
}
