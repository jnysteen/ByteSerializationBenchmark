using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ByteSerialization
{
    public class BinaryFormatterByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T input)
        {
            using (var ms = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, input);
                return ms.ToArray();
            }
        }
    }
}