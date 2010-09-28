namespace SqlLib
{
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
        public static byte[] GetBytes(this byte[] o)
        {
            if (o == null || o.Length == 0) return new byte[4];
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
            //return BitConverter.GetBytes(o.ToFileTimeUtc());
            return BitConverter.GetBytes(o.ToBinary());
        }
        public static byte[] GetBytes(this decimal o)
        {
            return decimal.GetBits(o).GetBytes();
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
            if (o == null) return BitConverter.GetBytes(-1);
            else if (o.Length == 0) return new byte[4];
            var stringbytes = Encoding.Unicode.GetBytes(o);
            var length = stringbytes.Length;
            var bytes = BitConverter.GetBytes(length);
            Array.Resize<byte>(ref bytes, sizeof(int) + length);
            Array.Copy(stringbytes, 0, bytes, sizeof(int), length);
            return bytes;
        }
        public static byte[] GetBytes(this int[] o)
        {
            if (o == null) return BitConverter.GetBytes(-1);
            else if (o.Length == 0) return new byte[4];
            var len = o.Length;
            var bytes = new byte[(len << 2) + 4];
            var buff = BitConverter.GetBytes(len);
            Array.Copy(buff, 0, bytes, 0, 4);
            for (int i = 0; i < len; i++)
            {
                buff = BitConverter.GetBytes(o[i]);
                Array.Copy(buff, 0, bytes, 4 + (i << 2), 4);
            }
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
        public static byte[] GetBytes(this Type o)
        {
            return o.FullName.GetBytes();
        }



        public static byte[] GetBytes(this bool? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this byte? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this char? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this DateTime? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this decimal? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this double? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this Guid? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this short? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this int? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this long? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this sbyte? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this float? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this ushort? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this uint? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this ulong? o)
        {
            if (o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
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
            if (len == 0) return new byte[0];
            else if (len == -1) return null;
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
            //var result = DateTime.FromFileTimeUtc(BitConverter.ToUInt64(buffer, startIndex));
            var result = DateTime.FromBinary(BitConverter.ToInt64(buffer, startIndex));
            startIndex += sizeof(long);
            return result;
        }
        public static decimal ToDecimal(this byte[] buffer, ref int startIndex)
        {
            return new decimal(buffer.ToInt32Array(ref startIndex));
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
            if (len == 0) return "";
            else if (len == -1) return null;
            var result = Encoding.Unicode.GetString(buffer, startIndex, len);
            startIndex += len;
            return result;
        }
        public static int[] ToInt32Array(this byte[] buffer, ref int startIndex)
        {
            var len = BitConverter.ToInt32(buffer, startIndex);
            startIndex += 4;
            if (len == 0) return new int[] { };
            else if (len == -1) return null;
            var array = new int[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = BitConverter.ToInt32(buffer, startIndex);
                startIndex += 4;
            }
            return array;
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
        public static Type ToType(this byte[] buffer, ref int startIndex)
        {
            return Type.GetType(buffer.ToString(ref startIndex));
        }



        public static bool? ToNullableBoolean(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToBoolean(buffer, ref startIndex);
        }
        public static byte? ToNullableByte(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToByte(buffer, ref startIndex);
        }
        public static char? ToNullableChar(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToChar(buffer, ref startIndex);
        }
        public static DateTime? ToNullableDateTime(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToDateTime(buffer, ref startIndex);
        }
        public static decimal? ToNullableDecimal(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToDecimal(buffer, ref startIndex);
        }
        public static double? ToNullableDouble(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToDouble(buffer, ref startIndex);
        }
        public static Guid? ToNullableGuid(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToGuid(buffer, ref startIndex);
        }
        public static short? ToNullableInt16(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToInt16(buffer, ref startIndex);
        }
        public static int? ToNullableInt32(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToInt32(buffer, ref startIndex);
        }
        public static long? ToNullableInt64(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToInt64(buffer, ref startIndex);
        }
        public static sbyte? ToNullableSByte(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToSByte(buffer, ref startIndex);
        }
        public static float? ToNullableSingle(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToSingle(buffer, ref startIndex);
        }
        public static ushort? ToNullableUInt16(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToUInt16(buffer, ref startIndex);
        }
        public static uint? ToNullableUInt32(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToUInt32(buffer, ref startIndex);
        }
        public static ulong? ToNullableUInt64(this byte[] buffer, ref int startIndex)
        {
            if (buffer[startIndex++] == 0) return null;
            return ToUInt64(buffer, ref startIndex);
        }


        #endregion

        #region GetBytes (generic)

        public static byte[] GetBytes(this object o, bool isContainTypeNumber = true)
        {
            if (o == null || o == DBNull.Value) return new byte[] { };
            var typeName = o.GetType().FullName;
            if (isContainTypeNumber)
            {
                switch (typeName)
                {
                    case "System.Boolean":
                        return new byte[][] { new byte[] { (byte)1 }, ((bool)o).GetBytes() }.Combine();
                    case "System.Byte":
                        return new byte[] { (byte)2, (byte)o };
                    case "System.Byte[]":
                        return new byte[][] { new byte[] { (byte)3 }, ((byte[])o).GetBytes() }.Combine();
                    case "System.Char":
                        return new byte[][] { new byte[] { (byte)4 }, ((char)o).GetBytes() }.Combine();
                    case "System.DateTime":
                        return new byte[][] { new byte[] { (byte)5 }, ((DateTime)o).GetBytes() }.Combine();
                    case "System.Decimal":
                        return new byte[][] { new byte[] { (byte)6 }, ((decimal)o).GetBytes() }.Combine();
                    case "System.Double":
                        return new byte[][] { new byte[] { (byte)7 }, ((double)o).GetBytes() }.Combine();
                    case "System.Guid":
                        return new byte[][] { new byte[] { (byte)8 }, ((Guid)o).GetBytes() }.Combine();
                    case "System.Int16":
                        return new byte[][] { new byte[] { (byte)9 }, ((short)o).GetBytes() }.Combine();
                    case "System.Int32":
                        return new byte[][] { new byte[] { (byte)10 }, ((int)o).GetBytes() }.Combine();
                    case "System.Int64":
                        return new byte[][] { new byte[] { (byte)11 }, ((long)o).GetBytes() }.Combine();
                    case "System.SByte":
                        return new byte[][] { new byte[] { (byte)12 }, ((sbyte)o).GetBytes() }.Combine();
                    case "System.Single":
                        return new byte[][] { new byte[] { (byte)13 }, ((float)o).GetBytes() }.Combine();
                    case "System.String":
                        return new byte[][] { new byte[] { (byte)14 }, ((string)o).GetBytes() }.Combine();
                    case "System.UInt16":
                        return new byte[][] { new byte[] { (byte)15 }, ((ushort)o).GetBytes() }.Combine();
                    case "System.UInt32":
                        return new byte[][] { new byte[] { (byte)16 }, ((uint)o).GetBytes() }.Combine();
                    case "System.UInt64":
                        return new byte[][] { new byte[] { (byte)17 }, ((ulong)o).GetBytes() }.Combine();
                    case "System.Type":
                        return new byte[][] { new byte[] { (byte)18 }, ((Type)o).GetBytes() }.Combine();
                    case "System.Int32[]":
                        return new byte[][] { new byte[] { (byte)19 }, ((int[])o).GetBytes() }.Combine();
                    default:
                        throw new Exception("unhandled data type");
                }
            }
            else
            {
                switch (typeName)
                {
                    case "System.Boolean":
                        return ((bool)o).GetBytes();
                    case "System.Byte":
                        return new byte[] { (byte)o };
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
                    case "System.Type":
                        return ((Type)o).GetBytes();
                    case "System.Int32[]":
                        return ((int[])o).GetBytes();
                    default:
                        throw new Exception("unhandled data type");
                }
            }
        }

        #endregion

        #region ToObject (generic)

        public static object ToObject(this byte[] buffer, ref int startIndex, string typeName)
        {
            switch (typeName)
            {
                case "System.Boolean":
                    return buffer.ToObject(ref startIndex, (byte)1);
                case "System.Byte":
                    return buffer.ToObject(ref startIndex, (byte)2);
                case "System.Byte[]":
                    return buffer.ToObject(ref startIndex, (byte)3);
                case "System.Char":
                    return buffer.ToObject(ref startIndex, (byte)4);
                case "System.DateTime":
                    return buffer.ToObject(ref startIndex, (byte)5);
                case "System.Decimal":
                    return buffer.ToObject(ref startIndex, (byte)6);
                case "System.Double":
                    return buffer.ToObject(ref startIndex, (byte)7);
                case "System.Guid":
                    return buffer.ToObject(ref startIndex, (byte)8);
                case "System.Int16":
                    return buffer.ToObject(ref startIndex, (byte)9);
                case "System.Int32":
                    return buffer.ToObject(ref startIndex, (byte)10);
                case "System.Int64":
                    return buffer.ToObject(ref startIndex, (byte)11);
                case "System.SByte":
                    return buffer.ToObject(ref startIndex, (byte)12);
                case "System.Single":
                    return buffer.ToObject(ref startIndex, (byte)13);
                case "System.String":
                    return buffer.ToObject(ref startIndex, (byte)14);
                case "System.UInt16":
                    return buffer.ToObject(ref startIndex, (byte)15);
                case "System.UInt32":
                    return buffer.ToObject(ref startIndex, (byte)16);
                case "System.UInt64":
                    return buffer.ToObject(ref startIndex, (byte)17);
                case "System.Type":
                    return buffer.ToObject(ref startIndex, (byte)18);
                case "System.Int32[]":
                    return buffer.ToObject(ref startIndex, (byte)19);
                default:
                    throw new Exception("unhandled data type");
            }
        }

        public static object ToObject(this byte[] buffer, ref int startIndex, byte typeNumber = 0)
        {
            if (typeNumber == 0) typeNumber = buffer.ToByte(ref startIndex);
            switch (typeNumber)
            {
                case 1:
                    return buffer.ToBoolean(ref startIndex);
                case 2:
                    return buffer.ToByte(ref startIndex);
                case 3:
                    return buffer.ToBytes(ref startIndex);
                case 4:
                    return buffer.ToChar(ref startIndex);
                case 5:
                    return buffer.ToDateTime(ref startIndex);
                case 6:
                    return buffer.ToDecimal(ref startIndex);
                case 7:
                    return buffer.ToDouble(ref startIndex);
                case 8:
                    return buffer.ToGuid(ref startIndex);
                case 9:
                    return buffer.ToInt16(ref startIndex);
                case 10:
                    return buffer.ToInt32(ref startIndex);
                case 11:
                    return buffer.ToInt64(ref startIndex);
                case 12:
                    return buffer.ToSByte(ref startIndex);
                case 13:
                    return buffer.ToSingle(ref startIndex);
                case 14:
                    return buffer.ToString(ref startIndex);
                case 15:
                    return buffer.ToUInt16(ref startIndex);
                case 16:
                    return buffer.ToUInt32(ref startIndex);
                case 17:
                    return buffer.ToUInt64(ref startIndex);
                case 18:
                    return buffer.ToType(ref startIndex);
                case 19:
                    return buffer.ToInt32Array(ref startIndex);
                default:
                    throw new Exception("unhandled data type");
            }
        }

        #endregion

        #region List<byte[]> Combine

        public static byte[] Combine(this List<byte[]> byteslist)
        {
            var result = new byte[byteslist.Sum(o => o == null ? 0 : o.Length)];
            var idx = 0;
            foreach (var bytes in byteslist)
            {
                if (bytes == null || bytes.Length == 0) continue;
                var len = bytes.Length;
                Array.Copy(bytes, 0, result, idx, len);
                idx += len;
            }
            return result;
        }
        public static byte[] Combine(this byte[][] byteslist)
        {
            var result = new byte[byteslist.Sum(o => o == null ? 0 : o.Length)];
            var idx = 0;
            foreach (var bytes in byteslist)
            {
                if (bytes == null || bytes.Length == 0) continue;
                var len = bytes.Length;
                Array.Copy(bytes, 0, result, idx, len);
                idx += len;
            }
            return result;
        }

        #endregion
    }



    public static class DateTimeExtensionsSL
    {
        public static readonly int[] DaysToMonth365 = new[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        public static readonly int[] DaysToMonth366 = new[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };


        public static long DateToTicks(int year, int month, int day)
        {
            if (((year >= 1) && (year <= 9999)) && ((month >= 1) && (month <= 12)))
            {
                int[] numArray = DateTime.IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
                if ((day >= 1) && (day <= (numArray[month] - numArray[month - 1])))
                {
                    int num = year - 1;
                    int num2 = ((((((num * 365) + (num / 4)) - (num / 100)) + (num / 400)) + numArray[month - 1]) + day) - 1;
                    return (num2 * 864000000000L);
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public static long TimeToTicks(int hour, int minute, int second)
        {
            long num = ((hour * 3600L) + (minute * 60L)) + second;
            if ((num > 922337203685L) || (num < -922337203685L))
            {
                throw new ArgumentOutOfRangeException();
            }
            return (num * 10000000L);
        }

        public static long ToBinary(this DateTime self)
        {
            long num = DateToTicks(self.Year, self.Month, self.Day) + TimeToTicks(self.Hour, self.Minute, self.Second);
            if ((self.Millisecond < 0) || (self.Millisecond >= 1000))
            {
                throw new ArgumentOutOfRangeException();
            }
            num += self.Millisecond * 10000L;
            if ((num < 0L) || (num > 3155378975999999999L))
            {
                throw new ArgumentException();
            }
            num = num | (((long)self.Kind) << 62);

            return num;
        }

        public static DateTime FromBinary(long dateData)
        {
            return new DateTime(dateData);
        }
    }
}