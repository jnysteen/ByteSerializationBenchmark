using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ByteSerialization
{
    public class BinaryFormatterByteConverter<T> : IByteConverter<T>
    {
        private readonly BinaryFormatter _binaryFormatter;

        public BinaryFormatterByteConverter()
        {
            _binaryFormatter = new BinaryFormatter();
        }

        public byte[] GetBytes(T itemToSerialize)
        {
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, itemToSerialize);
                return ms.ToArray();
            }
        }

        public T GetItem(byte[] itemToDeserialize)
        {
            using (var ms = new MemoryStream(itemToDeserialize))
            {
                return (T) _binaryFormatter.Deserialize(ms);
            }
        }
    }
}