namespace Sample
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Data;
    using System.Diagnostics;
    using System.IO;

    using DAL;
    using DAL.Database.Tables;
    using dt = DAL.Database.Tables;
    using kh = DAL.Database.Tables.客户;
    using ex = DAL.Expressions.Tables;
    using sp = DAL.Database.StoredProcedures;
    using tt = DAL.Database.UserDefinedTableTypes.表类型;

    using SqlLib;




    public class Tables<T1> : ISerial
        where T1 : ISerial, new()
    {
        public List<T1> Table1;

        public Tables() { }
        public Tables(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public Tables(byte[] buffer)
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
            this.Table1 = buffer.ToList<T1>();
        }
    }
    public class Tables<T1, T2> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
    {
        public List<T1> Table1;
        public List<T2> Table2;

        public Tables() { }
        public Tables(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public Tables(byte[] buffer)
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
            Array.Copy(buff1, 0, buff, 0, buff1.Length);
            Array.Copy(buff2, 0, buff, buff1.Length, buff2.Length);
            return buff;
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Table1 = buffer.ToList<T1>(ref startIndex);
            this.Table2 = buffer.ToList<T2>(ref startIndex);
        }
    }
    public class Tables<T1, T2, T3> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
    {
        public List<T1> Table1;
        public List<T2> Table2;
        public List<T3> Table3;

        public Tables() { }
        public Tables(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public Tables(byte[] buffer)
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
            this.Table1 = buffer.ToList<T1>(ref startIndex);
            this.Table2 = buffer.ToList<T2>(ref startIndex);
            this.Table3 = buffer.ToList<T3>(ref startIndex);
        }
    }
    public class Tables<T1, T2, T3, T4> : ISerial
        where T1 : ISerial, new()
        where T2 : ISerial, new()
        where T3 : ISerial, new()
        where T4 : ISerial, new()
    {
        public List<T1> Table1;
        public List<T2> Table2;
        public List<T3> Table3;
        public List<T4> Table4;

        public Tables() { }
        public Tables(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public Tables(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public byte[] GetBytes()
        {
            var buff1 = this.Table1.GetBytes();
            var buff2 = this.Table2.GetBytes();
            var buff3 = this.Table2.GetBytes();
            var buff4 = this.Table2.GetBytes();
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
            this.Table1 = buffer.ToList<T1>(ref startIndex);
            this.Table2 = buffer.ToList<T2>(ref startIndex);
            this.Table3 = buffer.ToList<T3>(ref startIndex);
        }

    }

    public class Test
    {
        public static void Main()
        {
            SqlHelper.InitConnectString("data,14333", "Test", "admin", "1");


            var ts = new Tables<kh.客户, kh.订单, kh.订单明细>();

            ts.Table1 = kh.客户.Select(a => a.客户编号 == 27);
            ts.Table2 = kh.订单.Select(a => a.客户编号 == 27);
            ts.Table3 = kh.订单明细.Select(a => a.订单编号.In(ts.Table2.Select(b => b.订单编号)));

            ts.Table3.Count.WL();

            byte[] buff = ts.GetBytes();
            var ts2 = new Tables<kh.客户, kh.订单, kh.订单明细>(buff);

            ts2.Table3.Count.WL();


            RL();
        }

        public static void RL()
        {
            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static void WL(this object o)
        {
            Console.WriteLine(o);
        }
        public static void WL(this byte[] buff)
        {
            buff.ToHexString().WL();
        }
    }

}
