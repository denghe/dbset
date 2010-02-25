using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class DbSet_Utils
{
    #region Types to byte[] (GetBytes)

    public static byte[] GetBytes(this bool o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this byte o)
    {
        return new byte[] { o };
    }
    public static byte[] GetBytes(this Byte[] o)
    {
        var length = o.Length;
        var bytes = BitConverter.GetBytes(length);
        Array.Resize<byte>(ref bytes, sizeof(int) + length);
        Array.Copy(o, 0, bytes, sizeof(int), length);
        return bytes;
    }
    public static byte[] GetBytes(this char o)
    {
        var charbytes = Encoding.Unicode.GetBytes(new char[] { o });
        var length = charbytes.Length;
        var bytes = BitConverter.GetBytes(length);
        Array.Resize<byte>(ref bytes, sizeof(int) + length);
        Array.Copy(charbytes, 0, bytes, sizeof(int), length);
        return bytes;
    }
    public static byte[] GetBytes(this DateTime o)
    {
        return BitConverter.GetBytes(o.ToBinary());
    }
    public static byte[] GetBytes(this decimal o)
    {
        var buffers = new List<byte[]>();
        var ints = Decimal.GetBits(o);
        buffers.Add(BitConverter.GetBytes((byte)ints.Length));
        foreach (var a in ints)
            buffers.Add(BitConverter.GetBytes(a));
        return buffers.Combine();
    }
    public static byte[] GetBytes(this double o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this Guid o)
    {
        return o.ToByteArray();
    }
    public static byte[] GetBytes(this short o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this int o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this long o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this sbyte o)
    {
        return new byte[] { (byte)o };
    }
    public static byte[] GetBytes(this float o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this string o)
    {
        var stringbytes = Encoding.Unicode.GetBytes(o);
        var length = stringbytes.Length;
        var bytes = BitConverter.GetBytes(length);
        Array.Resize<byte>(ref bytes, sizeof(int) + length);
        Array.Copy(stringbytes, 0, bytes, sizeof(int), length);
        return bytes;
    }
    public static byte[] GetBytes(this ushort o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this uint o)
    {
        return BitConverter.GetBytes(o);
    }
    public static byte[] GetBytes(this ulong o)
    {
        return BitConverter.GetBytes(o);
    }

    #endregion

    #region byte[] to Type (ToXxxxxx)

    public static bool ToBoolean(this byte[] buffer, ref int startIndex)
    {
        return BitConverter.ToBoolean(buffer, startIndex++);
    }
    public static byte ToByte(this byte[] buffer, ref int startIndex)
    {
        return buffer[startIndex++];
    }
    public static byte[] ToBytes(this byte[] buffer, ref int startIndex)
    {
        var len = BitConverter.ToInt32(buffer, startIndex);
        startIndex += sizeof(int);
        var result = new byte[len];
        Array.Copy(buffer, startIndex, result, 0, len);
        startIndex += len;
        return result;
    }
    public static char ToChar(this byte[] buffer, ref int startIndex)
    {
        var len = buffer[startIndex++];
        var result = Encoding.Unicode.GetChars(buffer, startIndex, len);
        startIndex += len;
        return result[0];
    }
    public static DateTime ToDateTime(this byte[] buffer, ref int startIndex)
    {
        var result = DateTime.FromBinary(BitConverter.ToInt64(buffer, startIndex));
        startIndex += sizeof(long);
        return result;
    }
    public static decimal ToDecimal(this byte[] buffer, ref int startIndex)
    {
        var num = buffer[startIndex++];
        var bits = new int[num];
        var len = num * 4;
        for (var i = 0; i < len; i += 4)
            bits[i] = BitConverter.ToInt32(buffer, startIndex + i);
        startIndex += len;
        return new decimal(bits);
    }
    public static double ToDouble(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToDouble(buffer, startIndex);
        startIndex += sizeof(double);
        return result;
    }
    public static Guid ToGuid(this byte[] buffer, ref int startIndex)
    {
        var bytes = new byte[16];
        Array.Copy(buffer, startIndex, bytes, 0, 16);
        startIndex += 16;
        return new Guid(bytes);
    }
    public static short ToInt16(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToInt16(buffer, startIndex);
        startIndex += sizeof(short);
        return result;
    }
    public static int ToInt32(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToInt32(buffer, startIndex);
        startIndex += sizeof(int);
        return result;
    }
    public static long ToInt64(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToInt64(buffer, startIndex);
        startIndex += sizeof(long);
        return result;
    }
    public static sbyte ToSByte(this byte[] buffer, ref int startIndex)
    {
        return (sbyte)(byte)buffer[startIndex++];
    }
    public static float ToSingle(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToSingle(buffer, startIndex);
        startIndex += sizeof(float);
        return result;
    }
    public static string ToString(this byte[] buffer, ref int startIndex)
    {
        var len = BitConverter.ToInt32(buffer, startIndex);
        startIndex += 4;
        var result = Encoding.Unicode.GetString(buffer, startIndex, len);
        startIndex += len;
        return result;
    }
    public static ushort ToUInt16(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToUInt16(buffer, startIndex);
        startIndex += sizeof(ushort);
        return result;
    }
    public static uint ToUInt32(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToUInt32(buffer, startIndex);
        startIndex += sizeof(uint);
        return result;
    }
    public static ulong ToUInt64(this byte[] buffer, ref int startIndex)
    {
        var result = BitConverter.ToUInt64(buffer, startIndex);
        startIndex += sizeof(ulong);
        return result;
    }
    #endregion

    #region GetBytes (generic)
    public static byte[] GetBytes(this object o)
    {
        if (o == null || o == DBNull.Value) return null;
        var typeName = o.GetType().Name;
        switch (typeName)
        {
            case "System.Boolean":
                return ((bool)o).GetBytes();
            case "System.Byte":
                return ((byte)o).GetBytes();
            case "System.Byte[]":
                return ((byte[])o).GetBytes();
            case "System.Char":
                return ((char)o).GetBytes();
            case "System.DateTime":
                return ((DateTime)o).GetBytes();
            case "System.Decimal":
                return ((decimal)o).GetBytes();
            case "System.Double":
                return ((double)o).GetBytes();
            case "System.Guid":
                return ((Guid)o).GetBytes();
            case "System.Int16":
                return ((short)o).GetBytes();
            case "System.Int32":
                return ((int)o).GetBytes();
            case "System.Int64":
                return ((long)o).GetBytes();
            case "System.SByte":
                return ((sbyte)o).GetBytes();
            case "System.Single":
                return ((float)o).GetBytes();
            case "System.String":
                return ((string)o).GetBytes();
            case "System.UInt16":
                return ((ushort)o).GetBytes();
            case "System.UInt32":
                return ((uint)o).GetBytes();
            case "System.UInt64":
                return ((ulong)o).GetBytes();
            default:
                return null;
        }
    }
    #endregion

    #region ToObject (generic)
    public static object ToObject(this byte[] buffer, Type type, ref int startIndex)
    {
        return ToObject(buffer, type.Name, ref startIndex);
    }
    public static object ToObject(this byte[] buffer, string typeName, ref int startIndex)
    {
        switch (typeName)
        {
            case "System.Boolean":
                return ToBoolean(buffer, ref startIndex);
            case "System.Byte":
                return ToByte(buffer, ref startIndex);
            case "System.Byte[]":
                return ToBytes(buffer, ref startIndex);
            case "System.Char":
                return ToChar(buffer, ref startIndex);
            case "System.DateTime":
                return ToDateTime(buffer, ref startIndex);
            case "System.Decimal":
                return ToDecimal(buffer, ref startIndex);
            case "System.Double":
                return ToDouble(buffer, ref startIndex);
            case "System.Guid":
                return ToGuid(buffer, ref startIndex);
            case "System.Int16":
                return ToInt16(buffer, ref startIndex);
            case "System.Int32":
                return ToInt32(buffer, ref startIndex);
            case "System.Int64":
                return ToInt64(buffer, ref startIndex);
            case "System.SByte":
                return ToSByte(buffer, ref startIndex);
            case "System.Single":
                return ToSingle(buffer, ref startIndex);
            case "System.String":
                return ToString(buffer, ref startIndex);
            case "System.UInt16":
                return ToUInt16(buffer, ref startIndex);
            case "System.UInt32":
                return ToUInt32(buffer, ref startIndex);
            case "System.UInt64":
                return ToUInt64(buffer, ref startIndex);
            default:
                return null;
        }
    }

    #endregion

    #region List<byte[]> Combine

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

    #endregion
}
