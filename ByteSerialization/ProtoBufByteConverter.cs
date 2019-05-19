using System.IO;
using ProtoBuf;

namespace ByteSerialization
{
    public class ProtoBufByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T itemToSerialize)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, itemToSerialize);
                return ms.ToArray();
            }
        }

        public T GetItem(byte[] itemToDeserialize)
        {
            using (var ms = new MemoryStream(itemToDeserialize))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}