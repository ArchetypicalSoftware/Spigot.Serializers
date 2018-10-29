using System.IO;
using ProtoBuf;

namespace Archetypical.Software.Spigot.Serializers.Protobuf
{
    public class SpigotSerializer : ISpigotSerializer
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