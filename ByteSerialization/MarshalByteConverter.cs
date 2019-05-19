using System;

namespace ByteSerialization
{
    public class MarshalByteConverter : IByteConverter<string>
    {
        public unsafe byte[] GetBytes(string input)
        {
            var tempByte = new byte[input.Length];
            fixed (void* ptr = input)
            {
                System.Runtime.InteropServices.Marshal.Copy(new IntPtr(ptr), tempByte, 0, input.Length);
            }

            return tempByte;
        }
    }
}