using System.Text;
using Newtonsoft.Json;

namespace ByteSerialization
{
    public class JsonByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T itemToSerialize)
        {
            var jsonSerialized = JsonConvert.SerializeObject(itemToSerialize);
            return Encoding.UTF8.GetBytes(jsonSerialized);
        }

        public T GetItem(byte[] itemToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(itemToDeserialize));
        }
    }
}