using MessagePack;

namespace ByteSerialization
{
    public class MessagePackByteConverter<T> : IByteConverter<T>
    {
        public byte[] GetBytes(T itemToSerialize)
        {
            return MessagePackSerializer.Serialize(itemToSerialize);
        }

        public T GetItem(byte[] itemToDeserialize)
        {
            return MessagePackSerializer.Deserialize<T>(itemToDeserialize);
        }
    }
}