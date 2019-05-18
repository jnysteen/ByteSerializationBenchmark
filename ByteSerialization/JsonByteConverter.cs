using System.Text;
using Newtonsoft.Json;

namespace ByteSerialization
{
    public class JsonByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T input)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(input));
        }
    }
}