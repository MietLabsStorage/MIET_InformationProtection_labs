using System;
using System.Collections.Generic;

namespace Lab4
{
    public struct DuoTuple<T>
    {
        public T first;
        public T second;

        public DuoTuple(T first, T second)
        {
            this.first = first;
            this.second = second;
        }
    }
    
    public static class Convertor
    {
        public static UInt64 ToUInt64(byte[] bytes)
        {
            return BitConverter.ToUInt64(bytes, 0);
        }
        
        public static UInt64 ToUInt64(UInt32 left, UInt32 right)
        {
            List<byte> bytes = new List<byte>(8);
            bytes.AddRange(BitConverter.GetBytes(left));
            bytes.AddRange(BitConverter.GetBytes(right));
            return BitConverter.ToUInt64(bytes.ToArray(), 0);
        }

        public static UInt32 ToUInt32(byte[] bytes)
        {
            return BitConverter.ToUInt32(bytes, 0);
        }
        
        public static DuoTuple<UInt32> ToUInt32(UInt64 uint64)
        {
            List<byte> bytes = new List<byte>(8);
            bytes.AddRange(BitConverter.GetBytes(uint64));
            return new DuoTuple<UInt32>(
                BitConverter.ToUInt32(bytes.ToArray(), 0),
                BitConverter.ToUInt32(bytes.ToArray(), 4)
            );
        }
        
        public static List<byte> ToByte(UInt32 uint32)
        {
            List<byte> bytes = new List<byte>(4);
            bytes.AddRange(BitConverter.GetBytes(uint32));
            return bytes;
        }
        
        public static List<byte> ToByte(UInt64 uint64)
        {
            List<byte> bytes = new List<byte>(8);
            bytes.AddRange(BitConverter.GetBytes(uint64));
            return bytes;
        }
    }
}