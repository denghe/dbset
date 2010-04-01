namespace Sample {
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

    using SqlLib;
    using dbo = DAL.Database.Tables.dbo;
    using query = DAL.Queries.Tables.dbo;

    public class Test {
        public static void Main() {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username: "admin");

            //Console.WriteLine(dbo.t1.Select().Count);
            //var row = new dbo.t1 { ID = 20 };
            //Console.WriteLine(dbo.t1.Insert(row, o => o.ID, o => o.PID));
            //Console.WriteLine(dbo.t1.Select().Count);
            //row.ID = 21; row.PID = 1;
            //Console.WriteLine(dbo.t1.Update(row, o => o.ID == 20, o => o.ID, o => o.ID));
            //Console.WriteLine(dbo.t1.Select(o => o.ID == row.ID).Count);
            //Console.WriteLine(dbo.t1.Delete(o => o.ID == row.ID));
            //Console.WriteLine(dbo.t1.Select().Count);

            //SqlHelper.ExecuteDbSet("insert into t1 output inserted.* values (21, null)").Dump();

            // 显示 dbo.t3 的数据
            var dumpTable = new Action(() => {
                SqlHelper.ExecuteDbSet(query.t3.New().ToString()).Dump();
            });
            var dumpRow = new Action<dbo.t3>(o => {
                Console.WriteLine(o.c1 + ", " + o.c2 + ", " + o.c3 + ", " + o.c4);
            });

            // 清空表 dbo.t3 的数据
            dbo.t3.Delete();
            dumpTable.Invoke();

            // 插入 c4, 回写 c1 字段到 r1
            var r1 = new dbo.t3 { c4 = "asdf" };
            r1.Insert(
                o => o.c4, 
                o => o.c1
            );
            dumpRow.Invoke(r1);
            dumpTable.Invoke();

            // 更新刚插入行的 c4 字段，回写所有字段到 r2
            var r2 = new dbo.t3 { c4 = "qwer" };
            dbo.t3.Update(r2,
                o => o.c1 == r1.c1, 
                o => o.c4
            );
            dumpRow.Invoke(r2);
            dumpTable.Invoke();

            Console.ReadLine();
        }
    }

    public static class Ext {
        public static int Insert(this dbo.t3 o, DAL.ColumnEnums.Tables.dbo.t3.Handler insertCols = null, DAL.ColumnEnums.Tables.dbo.t3.Handler fillCols = null, bool isFillAfterInsert = true) {
            return dbo.t3.Insert(o, insertCols, fillCols, isFillAfterInsert);
        }
    }
}
