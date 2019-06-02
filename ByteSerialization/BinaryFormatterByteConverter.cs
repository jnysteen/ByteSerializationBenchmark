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

        public byte[] GetBytes(T objectToSerialize)
        {
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, objectToSerialize);
                return ms.ToArray();
            }
        }

        public T GetObject(byte[] objectToDeserialize)
        {
            using (var ms = new MemoryStream(objectToDeserialize))
            {
                return (T) _binaryFormatter.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return "BinaryFormatter";
        }
    }
}