using System.Collections.Generic;
using System.IO;
using KeyValueStore.Cmd.Interfaces;

namespace KeyValueStore.Cmd
{
    public class Base64DictionaryDeserializer : IDictionaryDeserializer
    {
        public IDictionary<string, string> FullDeserialize(Stream inStream)
        {
            var dictionary = new Dictionary<string, string>();

            using (var sr = new StreamReader(inStream))
            {
                while(!sr.EndOfStream)
                {
                    var key = sr.ReadLine();
                    var value = sr.ReadLine();

                    dictionary.Add(key, Base64.Base64Decode(value));
                }
            }

            return dictionary;
        }

        public string GetSingleValue(Stream inStream, string requestedKey)
        {
            using (var sr = new StreamReader(inStream))
            {
                while (!sr.EndOfStream)
                {
                    var key = sr.ReadLine();
                    var value = sr.ReadLine();

                    if (key == requestedKey)
                    {
                        return Base64.Base64Decode(value);
                    }
                }
            }

            throw new KeyNotFoundException();
        }
    }
}
