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
    using DAL.Database.Tables.dbo;
    using dbo = DAL.Database.Tables.dbo;
    using query = DAL.Queries.Tables.dbo;

    public class Test {
        public static void Main() {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username: "admin");

            // 显示 dbo.t3 整表数据
            var dumpTable = new Action(() => {
                SqlHelper.ExecuteDbSet(query.t3.New().ToString()).Dump();
            });
            // 显示 dbo.t3 一行数据
            var dumpRow = new Action<dbo.t3>(o => {
                Console.WriteLine("row data:");
                Console.WriteLine(o.c1 + "\t" + o.c2 + "\t" + o.c3 + "\t" + o.c4);
            });

            // 清空表 dbo.t3 的数据
            dbo.t3.Delete(o => o);
            dumpTable();

            // 插入 c4, 回写 c1 字段到 r1
            var r1 = new dbo.t3 { c4 = "asdf" };
            r1.Insert(
                o => o.c4,
                o => o.c1
            );
            dumpRow(r1);
            dumpTable();

            // 更新刚插入行的 c4 字段，回写所有字段到 r2
            var r2 = new dbo.t3 { c4 = "qwer" };
            r2.Update(
                o => o.c1 == r1.c1,
                o => o.c4
            );
            dumpRow(r2);
            dumpTable();

            // 根据字段 c1 删掉数据
            r1.Delete(o => o.c1);

            Console.ReadLine();
        }
    }

}
