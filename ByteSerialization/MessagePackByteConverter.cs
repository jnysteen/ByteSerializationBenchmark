using MessagePack;

namespace ByteSerialization
{
    public class MessagePackByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T objectToSerialize)
        {
            return MessagePackSerializer.Serialize(objectToSerialize);
        }

        public T GetObject(byte[] objectToDeserialize)
        {
            return MessagePackSerializer.Deserialize<T>(objectToDeserialize);
        }
        
        public override string ToString()
        {
            return "MessagePack";
        }
    }
}