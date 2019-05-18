using System.IO;
using ProtoBuf;

namespace ByteSerialization
{
    public class ProtoBufByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T input)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, input);
                return ms.ToArray();
            }
        }
    }
}