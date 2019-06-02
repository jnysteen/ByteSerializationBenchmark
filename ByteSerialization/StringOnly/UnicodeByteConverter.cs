using System.Text;

namespace ByteSerialization.StringOnly
{
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