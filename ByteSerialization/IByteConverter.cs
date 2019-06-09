using System;

namespace ByteSerialization
{
    /// <summary>
    /// Serializes instances of T to bytes
    /// </summary>
    /// <typeparam name="T">The type that can be serialized to bytes</typeparam>
    public interface IByteConverter<T>
    {
        /// <summary>
        /// Serializes an instance of T to bytes
        /// </summary>
        /// <param name="objectToSerialize">The instance to serialize</param>
        /// <returns>A byte representation of the instance</returns>
        byte[] GetBytes(T objectToSerialize);
        
        /// <summary>
        /// Deserializes bytes into an instance of T
        /// </summary>
        /// <param name="objectToDeserialize">The byte representation of the instance</param>
        /// <returns>The bytes as an instance of T</returns>
        T GetObject(byte[] objectToDeserialize);
    }
}