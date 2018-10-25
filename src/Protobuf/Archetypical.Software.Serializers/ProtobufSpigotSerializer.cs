using Archetypical.Software.Spigot;
using ProtoBuf;
using System.IO;

namespace Archetypical.Software.Serializers
{
    public class ProtobufSpigotSerializer : ISpigotSerializer
    {
        /// <inheritdoc />
        public T Deserialize<T>(byte[] serializedByteArray) where T : class, new()
        {
            using (var s = new MemoryStream(serializedByteArray))
            {
                return Serializer.Deserialize<T>(s);
            }
        }

        /// <inheritdoc />
        public byte[] Serialize<T>(T dataToSerialize) where T : class, new()
        {
            using (var mem = new MemoryStream())
            {
                Serializer.Serialize(mem, dataToSerialize);
                return mem.ToArray();
            }
        }
    }
}