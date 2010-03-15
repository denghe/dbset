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
    using db = DAL.Database.Tables.dbo;
    using query = DAL.Queries.Tables.dbo;

    public class Test {
        public static void Main() {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username: "admin");
            // dump dbo.t2 data (only contain ID column)
            SqlHelper.ExecuteDbSet(query.t2.New(columns: o => o.ID).ToString()).Dump();

            // select method test
            var row = db.t2.Select(5, o => o.CreateTime.Name.ID);               // return t2(id=5)
            var row2 = db.t2.Select(6);                         // return null

            var q = query.t2.New(o => o.Name >= "a"             // where
                , o => o.CreateTime.ASC & o.Name.DESC           // order by
                , 3                                             // pagesize
                , 1                                             // pageindex
                , o => o.ID.Name.CreateTime);                   // column list

            var rows = db.t2.Select(q);                         // return List<t2>

            Console.WriteLine("\r\n\r\nresult: "
                + (row == null ? 0 : row.ID) + " "
                + (row2 == null ? 0 : row.ID) + " "
                + rows.Count
                );

            Console.WriteLine(q.ToString());

            Console.ReadLine();
        }
    }
}
