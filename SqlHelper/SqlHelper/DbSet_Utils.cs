using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class DbSet_Utils
{
    public static byte[] GetBytes(this object o, Type type = null)
    {
        return GetBytes(o, type == null ? null : type.Name);
    }
    public static byte[] GetBytes(this object o, string typeName)
    {
        if (o == null || o == DBNull.Value) return null;
        if (typeName == null) typeName = o.GetType().Name;
        var buffers = new List<byte[]>();
        switch (typeName)
        {
            case "System.Boolean":
                return BitConverter.GetBytes((bool)o);
            case "System.Byte":
                return new byte[] { (byte)o };
            case "System.Byte[]":
                var bytes = (byte[])o;
                buffers.Add(BitConverter.GetBytes(bytes.Length));
                buffers.Add(bytes);
                break;
            case "System.Char":
                var charbytes = Encoding.Unicode.GetBytes(new char[] { (char)o });
                buffers.Add(new byte[] { (byte)charbytes.Length });
                buffers.Add(charbytes);
                break;
            case "System.DateTime":
                return BitConverter.GetBytes(((DateTime)o).ToBinary());
            case "System.Decimal":
                var ints = Decimal.GetBits((Decimal)o);
                buffers.Add(BitConverter.GetBytes((byte)ints.Length));
                foreach (var a in ints)
                    buffers.Add(BitConverter.GetBytes(a));
                break;
            case "System.Double":
                return BitConverter.GetBytes((double)o);
            case "System.Guid":
                return ((Guid)o).ToByteArray();
            case "System.Int16":
                return BitConverter.GetBytes((short)o);
            case "System.Int32":
                return BitConverter.GetBytes((int)o);
            case "System.Int64":
                return BitConverter.GetBytes((long)o);
            case "System.SByte":
                return new byte[] { (byte)(sbyte)o };
            case "System.Single":
                return BitConverter.GetBytes((float)o);
            case "System.String":
                var stringbytes = Encoding.Unicode.GetBytes((string)o);
                buffers.Add(BitConverter.GetBytes(stringbytes.Length));
                buffers.Add(stringbytes);
                break;
            case "System.UInt16":
                return BitConverter.GetBytes((System.UInt16)o);
            case "System.UInt32":
                return BitConverter.GetBytes((System.UInt32)o);
            case "System.UInt64":
                return BitConverter.GetBytes((System.UInt64)o);
        }
        if (buffers.Count == 0) return null;
        else if (buffers.Count == 1) return buffers[0];
        else
        {
            var buff1 = buffers[0];
            var buff2 = buffers[1];
            var length_buff1 = buff1.Length;
            var length_buff2 = buff2.Length;
            var result = new byte[length_buff1 + length_buff2];
            Array.Copy(buff1, 0, result, 0, length_buff1);
            Array.Copy(buff2, 0, result, length_buff1, length_buff2);
            return result;
        }
    }
    public static object GetObject(this byte[] buffer, Type type, ref int startIndex, int length = 0)
    {
        return GetObject(buffer, type.Name, ref startIndex, length);
    }

    public static object GetObject(this byte[] buffer, string typeName, ref int startIndex, int length = 0)
    {
        switch (typeName)
        {
            case "System.Boolean":
                return BitConverter.ToBoolean(buffer, startIndex++);
            case "System.Byte":
                return buffer[startIndex++];
            case "System.Byte[]":
                {
                    var result = new byte[length];
                    Array.Copy(buffer, startIndex, result, 0, length);
                    startIndex += length;
                    return result;
                }
            case "System.Char":
                {
                    var len = buffer[startIndex++];
                    var result = Encoding.Unicode.GetChars(buffer, startIndex, len);
                    startIndex += len;
                    return result;
                }
            case "System.DateTime":
                {
                    var result = DateTime.FromBinary(BitConverter.ToInt64(buffer, startIndex));
                    startIndex += sizeof(long);
                    return result;
                }
            case "System.Decimal":
                {
                    var num = buffer[startIndex++];
                    var bits = new int[num];
                    var len = num * 4;
                    for (var i = 0; i < len; i += 4)
                        bits[i] = BitConverter.ToInt32(buffer, startIndex + i);
                    startIndex += len;
                    return new decimal(bits);
                }
            case "System.Double":
                {
                    var result = BitConverter.ToDouble(buffer, startIndex);
                    startIndex += sizeof(double);
                    return result;
                }
            case "System.Guid":
                {
                    var bytes = new byte[16];
                    Array.Copy(buffer, startIndex, bytes, 0, 16);
                    startIndex += 16;
                    return new Guid(bytes);
                }
            case "System.Int16":
                {
                    var result = BitConverter.ToInt16(buffer, startIndex);
                    startIndex += sizeof(short);
                    return result;
                }
            case "System.Int32":
                {
                    var result = BitConverter.ToInt32(buffer, startIndex);
                    startIndex += sizeof(int);
                    return result;
                }
            case "System.Int64":
                {
                    var result = BitConverter.ToInt64(buffer, startIndex);
                    startIndex += sizeof(long);
                    return result;
                }
            case "System.SByte":
                return (sbyte)(byte)buffer[startIndex++];
            case "System.Single":
                {
                    var result = BitConverter.ToSingle(buffer, startIndex);
                    startIndex += sizeof(float);
                    return result;
                }
            case "System.String":
                {
                    var len = BitConverter.ToInt32(buffer, startIndex);
                    startIndex += 4;
                    var result = Encoding.Unicode.GetString(buffer, startIndex, len);
                    startIndex += len;
                    return result;
                }
            case "System.UInt16":
                {
                    var result = BitConverter.ToUInt16(buffer, startIndex);
                    startIndex += sizeof(ushort);
                    return result;
                }
            case "System.UInt32":
                {
                    var result = BitConverter.ToUInt32(buffer, startIndex);
                    startIndex += sizeof(uint);
                    return result;
                }
            case "System.UInt64":
                {
                    var result = BitConverter.ToUInt64(buffer, startIndex);
                    startIndex += sizeof(ulong);
                    return result;
                }
        }
        return null;
    }

    public static byte[] Combine(this List<byte[]> byteslist)
    {
        var result = new byte[byteslist.Sum(o => o.Length)];
        var idx = 0;
        foreach (var bytes in byteslist)
        {
            var len = bytes.Length;
            Array.Copy(bytes, 0, result, idx, len);
            idx += len;
        }
        return result;
    }
}
