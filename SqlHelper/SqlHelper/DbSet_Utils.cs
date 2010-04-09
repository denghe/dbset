namespace SqlLib {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class DbSet_Utils {
        #region Types to byte[] (GetBytes)

        public static byte[] GetBytes(this bool o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this byte o) {
            return new byte[] { o };
        }
        public static byte[] GetBytes(this byte[] o) {
            if(o == null || o.Length == 0) return new byte[4];
            var length = o.Length;
            var bytes = BitConverter.GetBytes(length);
            Array.Resize<byte>(ref bytes, sizeof(int) + length);
            Array.Copy(o, 0, bytes, sizeof(int), length);
            return bytes;
        }
        public static byte[] GetBytes(this char o) {
            var charbytes = Encoding.Unicode.GetBytes(new char[] { o });
            var length = charbytes.Length;
            var bytes = BitConverter.GetBytes(length);
            Array.Resize<byte>(ref bytes, sizeof(int) + length);
            Array.Copy(charbytes, 0, bytes, sizeof(int), length);
            return bytes;
        }
        public static byte[] GetBytes(this DateTime o) {
            return BitConverter.GetBytes(o.ToFileTimeUtc());
        }
        public static byte[] GetBytes(this decimal o) {
            var buffers = new List<byte[]>();
            var ints = decimal.GetBits(o);
            buffers.Add(BitConverter.GetBytes((byte)ints.Length));
            foreach(var a in ints)
                buffers.Add(BitConverter.GetBytes(a));
            return buffers.Combine();
        }
        public static byte[] GetBytes(this double o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this Guid o) {
            return o.ToByteArray();
        }
        public static byte[] GetBytes(this short o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this int o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this long o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this sbyte o) {
            return new byte[] { (byte)o };
        }
        public static byte[] GetBytes(this float o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this string o) {
            if(string.IsNullOrEmpty(o)) return new byte[4];
            var stringbytes = Encoding.Unicode.GetBytes(o);
            var length = stringbytes.Length;
            var bytes = BitConverter.GetBytes(length);
            Array.Resize<byte>(ref bytes, sizeof(int) + length);
            Array.Copy(stringbytes, 0, bytes, sizeof(int), length);
            return bytes;
        }
        public static byte[] GetBytes(this ushort o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this uint o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this ulong o) {
            return BitConverter.GetBytes(o);
        }
        public static byte[] GetBytes(this Type o) {
            return o.FullName.GetBytes();
        }



        public static byte[] GetBytes(this bool? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this byte? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this char? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this DateTime? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this decimal? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this double? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this Guid? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this short? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this int? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this long? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this sbyte? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this float? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this ushort? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this uint? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }
        public static byte[] GetBytes(this ulong? o) {
            if(o == null) return new byte[] { 0 };
            return new byte[][] { new byte[] { 1 }, GetBytes(o.Value) }.Combine();
        }

        #endregion

        #region byte[] to Type (ToXxxxxx)

        public static bool ToBoolean(this byte[] buffer, ref int startIndex) {
            return BitConverter.ToBoolean(buffer, startIndex++);
        }
        public static byte ToByte(this byte[] buffer, ref int startIndex) {
            return buffer[startIndex++];
        }
        public static byte[] ToBytes(this byte[] buffer, ref int startIndex) {
            var len = BitConverter.ToInt32(buffer, startIndex);
            startIndex += sizeof(int);
            if(len == 0) return new byte[0];
            else if(len == -1) return null;
            var result = new byte[len];
            Array.Copy(buffer, startIndex, result, 0, len);
            startIndex += len;
            return result;
        }
        public static char ToChar(this byte[] buffer, ref int startIndex) {
            var len = buffer[startIndex++];
            var result = Encoding.Unicode.GetChars(buffer, startIndex, len);
            startIndex += len;
            return result[0];
        }
        public static DateTime ToDateTime(this byte[] buffer, ref int startIndex) {
            var result = DateTime.FromFileTimeUtc(BitConverter.ToInt64(buffer, startIndex));
            startIndex += sizeof(long);
            return result;
        }
        public static decimal ToDecimal(this byte[] buffer, ref int startIndex) {
            var num = buffer[startIndex++];
            var bits = new int[num];
            var len = num * 4;
            for(var i = 0; i < len; i += 4)
                bits[i] = BitConverter.ToInt32(buffer, startIndex + i);
            startIndex += len;
            return new decimal(bits);
        }
        public static double ToDouble(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToDouble(buffer, startIndex);
            startIndex += sizeof(double);
            return result;
        }
        public static Guid ToGuid(this byte[] buffer, ref int startIndex) {
            var bytes = new byte[16];
            Array.Copy(buffer, startIndex, bytes, 0, 16);
            startIndex += 16;
            return new Guid(bytes);
        }
        public static short ToInt16(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToInt16(buffer, startIndex);
            startIndex += sizeof(short);
            return result;
        }
        public static int ToInt32(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToInt32(buffer, startIndex);
            startIndex += sizeof(int);
            return result;
        }
        public static long ToInt64(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToInt64(buffer, startIndex);
            startIndex += sizeof(long);
            return result;
        }
        public static sbyte ToSByte(this byte[] buffer, ref int startIndex) {
            return (sbyte)(byte)buffer[startIndex++];
        }
        public static float ToSingle(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToSingle(buffer, startIndex);
            startIndex += sizeof(float);
            return result;
        }
        public static string ToString(this byte[] buffer, ref int startIndex) {
            var len = BitConverter.ToInt32(buffer, startIndex);
            startIndex += 4;
            if(len == 0) return "";
            else if(len == -1) return null;
            var result = Encoding.Unicode.GetString(buffer, startIndex, len);
            startIndex += len;
            return result;
        }
        public static ushort ToUInt16(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToUInt16(buffer, startIndex);
            startIndex += sizeof(ushort);
            return result;
        }
        public static uint ToUInt32(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToUInt32(buffer, startIndex);
            startIndex += sizeof(uint);
            return result;
        }
        public static ulong ToUInt64(this byte[] buffer, ref int startIndex) {
            var result = BitConverter.ToUInt64(buffer, startIndex);
            startIndex += sizeof(ulong);
            return result;
        }
        public static Type ToType(this byte[] buffer, ref int startIndex) {
            return Type.GetType(buffer.ToString(ref startIndex));
        }



        public static bool? ToNullableBoolean(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToBoolean(buffer, ref startIndex);
        }
        public static byte? ToNullableByte(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToByte(buffer, ref startIndex);
        }
        public static char? ToNullableChar(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToChar(buffer, ref startIndex);
        }
        public static DateTime? ToNullableDateTime(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToDateTime(buffer, ref startIndex);
        }
        public static decimal? ToNullableDecimal(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToDecimal(buffer, ref startIndex);
        }
        public static double? ToNullableDouble(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToDouble(buffer, ref startIndex);
        }
        public static Guid? ToNullableGuid(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToGuid(buffer, ref startIndex);
        }
        public static short? ToNullableInt16(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToInt16(buffer, ref startIndex);
        }
        public static int? ToNullableInt32(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToInt32(buffer, ref startIndex);
        }
        public static long? ToNullableInt64(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToInt64(buffer, ref startIndex);
        }
        public static sbyte? ToNullableSByte(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToSByte(buffer, ref startIndex);
        }
        public static float? ToNullableSingle(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToSingle(buffer, ref startIndex);
        }
        public static ushort? ToNullableUInt16(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToUInt16(buffer, ref startIndex);
        }
        public static uint? ToNullableUInt32(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToUInt32(buffer, ref startIndex);
        }
        public static ulong? ToNullableUInt64(this byte[] buffer, ref int startIndex) {
            if(buffer[startIndex] == 0) {
                ++startIndex;
                return null;
            }
            return ToUInt64(buffer, ref startIndex);
        }


        #endregion

        #region GetBytes (generic)
        public static byte[] GetBytes(object o) {
            if(o == null || o == DBNull.Value) return null;
            var typeName = o.GetType().FullName;
            switch(typeName) {
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
                case "System.Type":
                    return ((Type)o).GetBytes();
                default:
                    return null;
            }
        }

        public static byte[] GetBytes(object o, ref int typeNumber) {
            if(o == null || o == DBNull.Value) return null;
            var typeName = o.GetType().FullName;
            switch(typeName) {
                case "System.Boolean":
                    typeNumber = 1;
                    return ((bool)o).GetBytes();
                case "System.Byte":
                    typeNumber = 2;
                    return ((byte)o).GetBytes();
                case "System.Byte[]":
                    typeNumber = 3;
                    return ((byte[])o).GetBytes();
                case "System.Char":
                    typeNumber = 4;
                    return ((char)o).GetBytes();
                case "System.DateTime":
                    typeNumber = 5;
                    return ((DateTime)o).GetBytes();
                case "System.Decimal":
                    typeNumber = 6;
                    return ((decimal)o).GetBytes();
                case "System.Double":
                    typeNumber = 7;
                    return ((double)o).GetBytes();
                case "System.Guid":
                    typeNumber = 8;
                    return ((Guid)o).GetBytes();
                case "System.Int16":
                    typeNumber = 9;
                    return ((short)o).GetBytes();
                case "System.Int32":
                    typeNumber = 10;
                    return ((int)o).GetBytes();
                case "System.Int64":
                    typeNumber = 11;
                    return ((long)o).GetBytes();
                case "System.SByte":
                    typeNumber = 12;
                    return ((sbyte)o).GetBytes();
                case "System.Single":
                    typeNumber = 13;
                    return ((float)o).GetBytes();
                case "System.String":
                    typeNumber = 14;
                    return ((string)o).GetBytes();
                case "System.UInt16":
                    typeNumber = 15;
                    return ((ushort)o).GetBytes();
                case "System.UInt32":
                    typeNumber = 16;
                    return ((uint)o).GetBytes();
                case "System.UInt64":
                    typeNumber = 17;
                    return ((ulong)o).GetBytes();
                case "System.Type":
                    typeNumber = 18;
                    return ((Type)o).GetBytes();
                default:
                    return null;
            }
        }

        #endregion

        #region ToObject (generic)
        public static object ToObject(byte[] buffer, Type type, ref int startIndex) {
            return ToObject(buffer, type.FullName, ref startIndex);
        }
        public static object ToObject(byte[] buffer, string typeName, ref int startIndex) {
            switch(typeName) {
                case "System.Boolean":
                    return buffer.ToBoolean(ref startIndex);
                case "System.Byte":
                    return buffer.ToByte(ref startIndex);
                case "System.Byte[]":
                    return buffer.ToBytes(ref startIndex);
                case "System.Char":
                    return buffer.ToChar(ref startIndex);
                case "System.DateTime":
                    return buffer.ToDateTime(ref startIndex);
                case "System.Decimal":
                    return buffer.ToDecimal(ref startIndex);
                case "System.Double":
                    return buffer.ToDouble(ref startIndex);
                case "System.Guid":
                    return buffer.ToGuid(ref startIndex);
                case "System.Int16":
                    return buffer.ToInt16(ref startIndex);
                case "System.Int32":
                    return buffer.ToInt32(ref startIndex);
                case "System.Int64":
                    return buffer.ToInt64(ref startIndex);
                case "System.SByte":
                    return buffer.ToSByte(ref startIndex);
                case "System.Single":
                    return buffer.ToSingle(ref startIndex);
                case "System.String":
                    return buffer.ToString(ref startIndex);
                case "System.UInt16":
                    return buffer.ToUInt16(ref startIndex);
                case "System.UInt32":
                    return buffer.ToUInt32(ref startIndex);
                case "System.UInt64":
                    return buffer.ToUInt64(ref startIndex);
                case "System.Type":
                    return buffer.ToType(ref startIndex);
                default:
                    return null;
            }
        }

        public static object ToObject(byte[] buffer, int typeNumber, ref int startIndex) {
            switch(typeNumber) {
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
                default:
                    return null;
            }
        }

        #endregion

        #region List<byte[]> Combine

        public static byte[] Combine(this List<byte[]> byteslist) {
            var result = new byte[byteslist.Sum(o => o == null ? 0 : o.Length)];
            var idx = 0;
            foreach(var bytes in byteslist) {
                if(bytes == null) continue;
                var len = bytes.Length;
                Array.Copy(bytes, 0, result, idx, len);
                idx += len;
            }
            return result;
        }
        public static byte[] Combine(this byte[][] byteslist) {
            var result = new byte[byteslist.Sum(o => o == null ? 0 : o.Length)];
            var idx = 0;
            foreach(var bytes in byteslist) {
                if(bytes == null) continue;
                var len = bytes.Length;
                Array.Copy(bytes, 0, result, idx, len);
                idx += len;
            }
            return result;
        }

        #endregion
    }
}