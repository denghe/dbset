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
            //var ts = new DbArray<kh.客户, kh.订单, kh.订单明细>();

            //ts.Table1 = new kh.客户[] { new kh.客户 { 客户编号 = 1 }, new kh.客户 { 客户编号 = 2 } };
            ////ts.Table2 = 
            ////ts.Table3 = 

            //byte[] buff = ts.GetBytes();
            //var ts2 = new DbList<kh.客户, kh.订单, kh.订单明细>(buff);

            //ts2.Table1.Count.WL();


            DbTable table = new DbTable();

            // Declare DataColumn and DataRow variables.
            table.NewColumn("程序集名称", typeof(string), true);
            table.NewColumn("窗口标题", typeof(string), true);
            table.NewColumn("动作", typeof(int), true);
            table.NewColumn("结束时间", typeof(DateTime), true);
            table.NewColumn("开始时间", typeof(DateTime), true);
            table.Name = "windowslogs";


            var list = new List<DesktopWindowInfo>();
            //for (int i = 0; i < 5; i++)
            //{
            //    list.Add(new DesktopWindowInfo
            //    {
            //        开始时间 = DateTime.Now,
            //        结束时间 = DateTime.Now,
            //        窗口标题 = "xxx",
            //        程序集名称 = "asdf",
            //        动作 = 窗口动作.关闭
            //    });
            //}
            list.Add(new DesktopWindowInfo
            {
                开始时间 = DateTime.Now,
                结束时间 = DateTime.Now,
                窗口标题 = null,
                程序集名称 = null,
                动作 = 窗口动作.关闭
            });

            AddlistToRows(table, list);

            table.Dump();

            var t = new DbTable(table.GetBytes());
            t.Dump();

            RL();
        }


        public class DesktopWindowInfo
        {
            public DateTime 开始时间 { get; set; }
            public DateTime 结束时间 { get; set; }
            public string 窗口标题 { get; set; }
            public string 程序集名称 { get; set; }
            public 窗口动作 动作 { get; set; }
        }
        public enum 窗口动作 : int
        {
            开启, 获得焦点, 失去焦点, 关闭
        }

        public static void AddlistToRows(DbTable dt, List<DesktopWindowInfo> lst)
        {
            foreach (var item in lst)
            {
                var row = dt.NewRow();
                row["程序集名称"] = item.程序集名称;
                row["窗口标题"] = item.窗口标题;
                row["动作"] = (int)item.动作;
                row["结束时间"] = item.结束时间;
                row["开始时间"] = item.开始时间;

            }
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
