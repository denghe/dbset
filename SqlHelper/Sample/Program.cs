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

            var a = new dbo.A { AID = 1 };
            a.Insert();

            var b = new dbo.B { AID = 1, BID = 1 };
            b.Insert();

            b.BID = 2;
            b.Insert();

            var bs = dbo.B.Select(a);

            Console.WriteLine(bs.Count);

            dbo.B.Delete(o => o);
            dbo.A.Delete(o => o);


            Console.ReadLine();
        }
    }

}
