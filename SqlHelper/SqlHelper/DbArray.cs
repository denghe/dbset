using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlLib
{
    /*
     
     
     
     
     
     
     
     
     
     
     
            var sb = new StringBuilder();

            for (int j = 2; j < 20; j++)
            {


                string s0 = "", s1 = "", s2 = "", s3 = "", s4 = "", s5 = "", s6 = "";
                for (int i = 2; i <= j; i++)
                {
                    s0 += @", T" + i;
                    s1 += @"
        where T" + i + @" : ISerial, new()";
                    s2 += @"
        public T" + i + @"[] Table" + i + @";";
                    s3 += @"
        var buff" + i + @" = this.Table" + i + @".GetBytes();";
                    s4 += @" + buff" + i + @".Length";

                    s5 += @"
            idx += buff" + (i - 1) + @".Length;
            Array.Copy(buff" + i + @", 0, buff, idx, buff" + i + @".Length);";
                    s6 += @"
            this.Table" + i + @" = buffer.ToArray<T" + i + @">(ref startIndex);";
                }

                var s = @"
    public class DbArray<T1" + s0 + @"> : ISerial
        where T1 : ISerial, new()" + s1 + @"
    {
        public T1[] Table1;" + s2 + @"

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();" + s3 + @"
            var buff = new byte[buff1.Length" + s4 + @"];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);" + s5 + @"
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);" + s6 + @"
        }
    }
";
                sb.Append(s);

            }

            var ss = sb.ToString();


     
     
     
     
     
     
     
     
     
     
     
     
     
     */


























    public class DbArray<T1> : ISerial
        where T1 : ISerial, new()
    {
        public T1[] Table1;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            return this.Table1.GetBytes();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>();
        }
    }



    public class DbArray<T1, T2> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
        where T15 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;
        public T15[] Table15;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff15 = this.Table15.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length + buff15.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            idx += buff14.Length;
            Array.Copy(buff15, 0, buff, idx, buff15.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
            this.Table15 = buffer.ToArray<T15>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
        where T15 : ISerial, new()
        where T16 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;
        public T15[] Table15;
        public T16[] Table16;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff15 = this.Table15.GetBytes();
            var buff16 = this.Table16.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length + buff15.Length + buff16.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            idx += buff14.Length;
            Array.Copy(buff15, 0, buff, idx, buff15.Length);
            idx += buff15.Length;
            Array.Copy(buff16, 0, buff, idx, buff16.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
            this.Table15 = buffer.ToArray<T15>(ref startIndex);
            this.Table16 = buffer.ToArray<T16>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
        where T15 : ISerial, new()
        where T16 : ISerial, new()
        where T17 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;
        public T15[] Table15;
        public T16[] Table16;
        public T17[] Table17;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff15 = this.Table15.GetBytes();
            var buff16 = this.Table16.GetBytes();
            var buff17 = this.Table17.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length + buff15.Length + buff16.Length + buff17.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            idx += buff14.Length;
            Array.Copy(buff15, 0, buff, idx, buff15.Length);
            idx += buff15.Length;
            Array.Copy(buff16, 0, buff, idx, buff16.Length);
            idx += buff16.Length;
            Array.Copy(buff17, 0, buff, idx, buff17.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
            this.Table15 = buffer.ToArray<T15>(ref startIndex);
            this.Table16 = buffer.ToArray<T16>(ref startIndex);
            this.Table17 = buffer.ToArray<T17>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
        where T15 : ISerial, new()
        where T16 : ISerial, new()
        where T17 : ISerial, new()
        where T18 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;
        public T15[] Table15;
        public T16[] Table16;
        public T17[] Table17;
        public T18[] Table18;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff15 = this.Table15.GetBytes();
            var buff16 = this.Table16.GetBytes();
            var buff17 = this.Table17.GetBytes();
            var buff18 = this.Table18.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length + buff15.Length + buff16.Length + buff17.Length + buff18.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            idx += buff14.Length;
            Array.Copy(buff15, 0, buff, idx, buff15.Length);
            idx += buff15.Length;
            Array.Copy(buff16, 0, buff, idx, buff16.Length);
            idx += buff16.Length;
            Array.Copy(buff17, 0, buff, idx, buff17.Length);
            idx += buff17.Length;
            Array.Copy(buff18, 0, buff, idx, buff18.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
            this.Table15 = buffer.ToArray<T15>(ref startIndex);
            this.Table16 = buffer.ToArray<T16>(ref startIndex);
            this.Table17 = buffer.ToArray<T17>(ref startIndex);
            this.Table18 = buffer.ToArray<T18>(ref startIndex);
        }
    }

    public class DbArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
        where T5 : ISerial, new()
        where T6 : ISerial, new()
        where T7 : ISerial, new()
        where T8 : ISerial, new()
        where T9 : ISerial, new()
        where T10 : ISerial, new()
        where T11 : ISerial, new()
        where T12 : ISerial, new()
        where T13 : ISerial, new()
        where T14 : ISerial, new()
        where T15 : ISerial, new()
        where T16 : ISerial, new()
        where T17 : ISerial, new()
        where T18 : ISerial, new()
        where T19 : ISerial, new()
    {
        public T1[] Table1;
        public T2[] Table2;
        public T3[] Table3;
        public T4[] Table4;
        public T5[] Table5;
        public T6[] Table6;
        public T7[] Table7;
        public T8[] Table8;
        public T9[] Table9;
        public T10[] Table10;
        public T11[] Table11;
        public T12[] Table12;
        public T13[] Table13;
        public T14[] Table14;
        public T15[] Table15;
        public T16[] Table16;
        public T17[] Table17;
        public T18[] Table18;
        public T19[] Table19;

        public DbArray() { }
        public DbArray(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbArray(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table3.GetBytes();
            var buff4 = this.Table4.GetBytes();
            var buff5 = this.Table5.GetBytes();
            var buff6 = this.Table6.GetBytes();
            var buff7 = this.Table7.GetBytes();
            var buff8 = this.Table8.GetBytes();
            var buff9 = this.Table9.GetBytes();
            var buff10 = this.Table10.GetBytes();
            var buff11 = this.Table11.GetBytes();
            var buff12 = this.Table12.GetBytes();
            var buff13 = this.Table13.GetBytes();
            var buff14 = this.Table14.GetBytes();
            var buff15 = this.Table15.GetBytes();
            var buff16 = this.Table16.GetBytes();
            var buff17 = this.Table17.GetBytes();
            var buff18 = this.Table18.GetBytes();
            var buff19 = this.Table19.GetBytes();
            var buff = new byte[buff1.Length + buff2.Length + buff3.Length + buff4.Length + buff5.Length + buff6.Length + buff7.Length + buff8.Length + buff9.Length + buff10.Length + buff11.Length + buff12.Length + buff13.Length + buff14.Length + buff15.Length + buff16.Length + buff17.Length + buff18.Length + buff19.Length];
            var idx = 0;
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            idx += buff1.Length;
            Array.Copy(buff2, 0, buff, idx, buff2.Length);
            idx += buff2.Length;
            Array.Copy(buff3, 0, buff, idx, buff3.Length);
            idx += buff3.Length;
            Array.Copy(buff4, 0, buff, idx, buff4.Length);
            idx += buff4.Length;
            Array.Copy(buff5, 0, buff, idx, buff5.Length);
            idx += buff5.Length;
            Array.Copy(buff6, 0, buff, idx, buff6.Length);
            idx += buff6.Length;
            Array.Copy(buff7, 0, buff, idx, buff7.Length);
            idx += buff7.Length;
            Array.Copy(buff8, 0, buff, idx, buff8.Length);
            idx += buff8.Length;
            Array.Copy(buff9, 0, buff, idx, buff9.Length);
            idx += buff9.Length;
            Array.Copy(buff10, 0, buff, idx, buff10.Length);
            idx += buff10.Length;
            Array.Copy(buff11, 0, buff, idx, buff11.Length);
            idx += buff11.Length;
            Array.Copy(buff12, 0, buff, idx, buff12.Length);
            idx += buff12.Length;
            Array.Copy(buff13, 0, buff, idx, buff13.Length);
            idx += buff13.Length;
            Array.Copy(buff14, 0, buff, idx, buff14.Length);
            idx += buff14.Length;
            Array.Copy(buff15, 0, buff, idx, buff15.Length);
            idx += buff15.Length;
            Array.Copy(buff16, 0, buff, idx, buff16.Length);
            idx += buff16.Length;
            Array.Copy(buff17, 0, buff, idx, buff17.Length);
            idx += buff17.Length;
            Array.Copy(buff18, 0, buff, idx, buff18.Length);
            idx += buff18.Length;
            Array.Copy(buff19, 0, buff, idx, buff19.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToArray<T1>(ref startIndex);
            this.Table2 = buffer.ToArray<T2>(ref startIndex);
            this.Table3 = buffer.ToArray<T3>(ref startIndex);
            this.Table4 = buffer.ToArray<T4>(ref startIndex);
            this.Table5 = buffer.ToArray<T5>(ref startIndex);
            this.Table6 = buffer.ToArray<T6>(ref startIndex);
            this.Table7 = buffer.ToArray<T7>(ref startIndex);
            this.Table8 = buffer.ToArray<T8>(ref startIndex);
            this.Table9 = buffer.ToArray<T9>(ref startIndex);
            this.Table10 = buffer.ToArray<T10>(ref startIndex);
            this.Table11 = buffer.ToArray<T11>(ref startIndex);
            this.Table12 = buffer.ToArray<T12>(ref startIndex);
            this.Table13 = buffer.ToArray<T13>(ref startIndex);
            this.Table14 = buffer.ToArray<T14>(ref startIndex);
            this.Table15 = buffer.ToArray<T15>(ref startIndex);
            this.Table16 = buffer.ToArray<T16>(ref startIndex);
            this.Table17 = buffer.ToArray<T17>(ref startIndex);
            this.Table18 = buffer.ToArray<T18>(ref startIndex);
            this.Table19 = buffer.ToArray<T19>(ref startIndex);
        }
    }

}
