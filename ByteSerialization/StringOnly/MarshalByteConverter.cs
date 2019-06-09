using System;
using System.Runtime.InteropServices;

namespace ByteSerialization.StringOnly
{
    /// <summary>
    /// Copies the bytes of the string directly from memory using Marshal
    /// </summary>
    public class MarshalByteConverter : IByteConverter<string>
    {
        public unsafe byte[] GetBytes(string objectToSerialize)
        {
            var tempByte = new byte[objectToSerialize.Length * 2];
            fixed (void* ptr = objectToSerialize)
            {
                Marshal.Copy(new IntPtr(ptr), tempByte, 0, objectToSerialize.Length * 2);
            }

            return tempByte;
        }

        public unsafe string GetObject(byte[] objectToDeserialize)
        {
            fixed (void* ptr = objectToDeserialize)
            {
                return Marshal.PtrToStringUni(new IntPtr(ptr), objectToDeserialize.Length / 2);
            }
        }
    }
}