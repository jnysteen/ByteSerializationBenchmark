using System.Text;
using Newtonsoft.Json;

namespace ByteSerialization
{
    /// <summary>
    /// Uses Newtonsoft.Json to serialize objects to bytes
    /// </summary>
    public class JsonByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T objectToSerialize)
        {
            var jsonSerialized = JsonConvert.SerializeObject(objectToSerialize);
            return Encoding.UTF8.GetBytes(jsonSerialized);
        }

        public T GetObject(byte[] objectToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(objectToDeserialize));
        }
    }
}