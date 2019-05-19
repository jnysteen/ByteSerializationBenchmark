using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ByteSerialization
{
    public class MarshalByteConverter : IByteConverter<string>
    {
        public unsafe byte[] GetBytes(string itemToSerialize)
        {
            var tempByte = new byte[itemToSerialize.Length];
            fixed (void* ptr = itemToSerialize)
            {
                Marshal.Copy(new IntPtr(ptr), tempByte, 0, itemToSerialize.Length);
            }

            return tempByte;
        }

        public unsafe string GetItem(byte[] itemToDeserialize)
        {
            return Encoding.Unicode.GetString(itemToDeserialize);
            
            fixed (void* ptr = itemToDeserialize)
            {
                return Marshal.PtrToStringAuto(new IntPtr(ptr), itemToDeserialize.Length);
            }
        }
    }
}