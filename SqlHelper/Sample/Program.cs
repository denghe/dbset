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
            Console.WriteLine(dbo.t1.Select().Count);
            var row = new dbo.t1 { ID = 20 };
            Console.WriteLine(dbo.t1.Insert(row, o => o.ID, o=>o.PID));
            Console.WriteLine(dbo.t1.Select().Count);
            row.ID = 21; row.PID = 1;
            Console.WriteLine(dbo.t1.Update(row, o => o.ID == 20, o => o.ID, o=>o.ID));
            Console.WriteLine(dbo.t1.Select(o => o.ID == row.ID).Count);
            Console.WriteLine(dbo.t1.Delete(o => o.ID == row.ID));
            Console.WriteLine(dbo.t1.Select().Count);

            //SqlHelper.ExecuteDbSet("insert into t1 output inserted.* values (21, null)").Dump();
            Console.ReadLine();
        }
    }
}
