using System.Text;

namespace ByteSerialization.StringOnly
{
    /// <summary>
    /// Uses Encoding.UTF8 to serialize objects to bytes
    /// </summary>
    public class Utf8ByteConverter: IByteConverter<string>
    {
        public byte[] GetBytes(string objectToSerialize)
        {
            return Encoding.UTF8.GetBytes(objectToSerialize);
        }

        public string GetObject(byte[] objectToDeserialize)
        {
            return Encoding.UTF8.GetString(objectToDeserialize);
        }
    }
}