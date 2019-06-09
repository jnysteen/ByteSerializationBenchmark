using System.Text;

namespace ByteSerialization.StringOnly
{
    /// <summary>
    /// Uses Encoding.Unicode to serialize objects to bytes
    /// </summary>
    public class UnicodeByteConverter : IByteConverter<string>
    {
        public byte[] GetBytes(string objectToSerialize)
        {
            return Encoding.Unicode.GetBytes(objectToSerialize);
        }

        public string GetObject(byte[] objectToDeserialize)
        {
            return Encoding.Unicode.GetString(objectToDeserialize);
        }
    }
}