using MessagePack;

namespace ByteSerialization
{
    /// <summary>
    /// Uses MessagePack to serialize objects to bytes
    /// </summary>
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
    }
}