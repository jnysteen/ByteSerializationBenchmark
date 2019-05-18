namespace ByteSerialization
{
    public interface IByteConverter<T>
    {
        byte[] GetBytes(T input);
    }
}