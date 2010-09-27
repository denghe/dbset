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

    using SqlLib;




    public class Tables<T1> : ISerial
        where T1 : ISerial
    {
        public List<T1> Table1;

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            throw new NotImplementedException();
        }
    }
    public class Tables<T1, T2> : ISerial
        where T1 : ISerial
        where T2 : ISerial
    {
        public List<T1> Table1;
        public List<T2> Table2;

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            throw new NotImplementedException();
        }
    }
    public class Tables<T1, T2, T3> : ISerial
        where T1 : ISerial
        where T2 : ISerial
        where T3 : ISerial
    {
        public List<T1> Table1;
        public List<T2> Table2;
        public List<T3> Table3;

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            throw new NotImplementedException();
        }
    }
    public class Tables<T1, T2, T3, T4> : ISerial
        where T1 : ISerial
        where T2 : ISerial
        where T3 : ISerial
        where T4 : ISerial
    {
        public List<T1> Table1;
        public List<T2> Table2;
        public List<T3> Table3;
        public List<T4> Table4;

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            throw new NotImplementedException();
        }
    }

    public class Test
    {
        public static void Main()
        {
            var ts = new Tables<kh.客户, kh.订单, kh.订单明细>();

            ts.Table1 = kh.客户.Select(a => a.客户编号 == 2);
            ts.Table2 = kh.订单.Select(a => a.客户编号 == 2);
            ts.Table3 = kh.订单明细.Select(a => a.订单编号.In(ts.Table2.Select(b => b.订单编号)));

            byte[] buff = ts.GetBytes();



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
