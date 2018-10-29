using Newtonsoft.Json;
using System.IO;

namespace Archetypical.Software.Spigot.Serializers.Json
{
    public class SpigotSerializer : ISpigotSerializer
    {
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public SpigotSerializer()
        {
            _serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
            _serializer.NullValueHandling = NullValueHandling.Ignore;
            _serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
        }

        /// <inheritdoc />
        public T Deserialize<T>(byte[] serializedByteArray) where T : class, new()
        {
            using (var s = new MemoryStream(serializedByteArray))
            using (var sr = new StreamReader(s))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    return _serializer.Deserialize<T>(reader);
                }
            }
        }

        /// <inheritdoc />
        public byte[] Serialize<T>(T dataToSerialize) where T : class, new()
        {
            using (var mem = new MemoryStream())
            using (var textWriter = new StreamWriter(mem))
            {
                _serializer.Serialize(textWriter, dataToSerialize);
                textWriter.Flush();
                return mem.ToArray();
            }
        }
    }
}