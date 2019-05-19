using System;

namespace ByteSerialization
{
    public interface IByteConverter<T>
    {
        byte[] GetBytes(T itemToSerialize);
        T GetItem(byte[] itemToDeserialize);
    }
}