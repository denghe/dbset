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






    public class Test
    {
        public static void Main()
        {
            var ts = new DbArray<kh.客户, kh.订单, kh.订单明细>();

            ts.Table1 = new kh.客户[] { new kh.客户 { 客户编号 = 1 }, new kh.客户 { 客户编号 = 2 } };
            //ts.Table2 = 
            //ts.Table3 = 

            byte[] buff = ts.GetBytes();
            var ts2 = new DbArray<kh.客户, kh.订单, kh.订单明细>(buff);

            ts2.Table1.Length.WL();

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
