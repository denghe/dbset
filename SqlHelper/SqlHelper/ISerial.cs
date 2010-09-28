namespace SqlLib
{
    using System;
    using System.Collections.Generic;

    public interface ISerial
    {
        byte[] GetBytes();
        void Fill(byte[] buffer, ref int startIndex);
    }


    public static class ISerial_Extension
    {

        public static byte[] GetBytes<T>(this List<T> os) where T : ISerial, new()
        {
            if (os == null || os.Count == 0) return new byte[] { 0, 0, 0, 0 };
            var buffers = new List<byte[]>();
            buffers.Add(os.Count.GetBytes());
            foreach (var o in os)
            {
                buffers.Add(o.GetBytes());
            }
            return buffers.Combine();
        }

        public static byte[] GetBytes<T>(this T[] os) where T : ISerial, new()
        {
            if (os == null || os.Length == 0) return new byte[] { 0, 0, 0, 0 };
            var buffers = new List<byte[]>();
            buffers.Add(os.Length.GetBytes());
            foreach (var o in os)
            {
                buffers.Add(o.GetBytes());
            }
            return buffers.Combine();
        }


        public static List<T> ToList<T>(this byte[] buffer, ref int startIndex) where T : ISerial, new()
        {
            var os = new List<T>();
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                var t = new T();
                t.Fill(buffer, ref startIndex);
                os.Add(t);
            }
            return os;
        }

        public static List<T> ToList<T>(this byte[] buffer) where T : ISerial, new()
        {
            var startIndex = 0;
            return ToList<T>(buffer, ref startIndex);
        }



        public static T[] ToArray<T>(this byte[] buffer, ref int startIndex) where T : ISerial, new()
        {
            var count = buffer.ToInt32(ref startIndex);
            var os = new T[count];
            for (int i = 0; i < count; i++)
            {
                var t = new T();
                t.Fill(buffer, ref startIndex);
                os[i] = t;
            }
            return os;
        }

        public static T[] ToArray<T>(this byte[] buffer) where T : ISerial, new()
        {
            var startIndex = 0;
            return ToArray<T>(buffer, ref startIndex);
        }
    }
}