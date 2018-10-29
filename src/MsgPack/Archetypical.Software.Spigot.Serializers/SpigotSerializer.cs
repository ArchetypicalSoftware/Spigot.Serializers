using System.IO;
using Archetypical.Software.Serializers;
using Newtonsoft.Json;

namespace Archetypical.Software.Spigot.Serializers.MsgPack
{
    public class SpigotSerializer : ISpigotSerializer
    {
        private readonly JsonSerializer _serializer;

        public SpigotSerializer()
        {
            _serializer = new JsonSerializer
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        /// <inheritdoc />
        public T Deserialize<T>(byte[] serializedByteArray) where T : class, new()
        {
            using (var s = new MemoryStream(serializedByteArray))
            {
                MessagePackReader reader = new MessagePackReader(s);
                return _serializer.Deserialize<T>(reader);
            }
        }

        /// <inheritdoc />
        public byte[] Serialize<T>(T dataToSerialize) where T : class, new()
        {
            using (var s = new MemoryStream())
            {
                MessagePackWriter writer = new MessagePackWriter(s);
                _serializer.Serialize(writer, dataToSerialize);
                return s.ToArray();
            }
        }
    }
}