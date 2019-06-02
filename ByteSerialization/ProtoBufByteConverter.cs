using System.IO;
using ProtoBuf;

namespace ByteSerialization
{
    public class ProtoBufByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T objectToSerialize)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, objectToSerialize);
                return ms.ToArray();
            }
        }

        public T GetObject(byte[] objectToDeserialize)
        {
            using (var ms = new MemoryStream(objectToDeserialize))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}