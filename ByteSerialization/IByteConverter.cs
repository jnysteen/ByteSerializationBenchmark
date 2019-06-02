using System;

namespace ByteSerialization
{
    public interface IByteConverter<T>
    {
        byte[] GetBytes(T objectToSerialize);
        T GetObject(byte[] objectToDeserialize);
    }
}