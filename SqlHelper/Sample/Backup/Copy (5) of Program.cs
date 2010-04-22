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

            //var a1 = new dbo.A { AID = 1 };
            //var buff = a1.GetBytes();
            //Console.WriteLine(buff.ToHexString());

            //var a2 = new dbo.A(buff);
            //Console.WriteLine(a2.AID);

            //var t11 = new dbo.t1 { ID = 1, PID = null };
            //buff = t11.GetBytes();
            //Console.WriteLine(buff.ToHexString());

            //var t12 = new dbo.t1(buff);
            //Console.WriteLine(t12.ID + ", " + (t12.PID == null ? "NULL" : t12.PID.ToString()));

            //var t3 = new dbo.t3 { c4 = "asdf" };
            //t3.Insert(o => o.c4);
            //var buff = t3.GetBytes(); Console.WriteLine(buff.ToHexString());
            //t3 = new dbo.t3(buff); Console.WriteLine(t3.c1 + "\t" + t3.c2 + "\t" + t3.c3 + "\t" + t3.c4);

            var rows = dbo.t3.Select();
            var buff = rows.GetBytes();
            Console.WriteLine(buff.ToHexString());
            rows = buff.ToList<dbo.t3>();
            foreach(var row in rows) 
                Console.WriteLine(row.c1 + "\t" + row.c2 + "\t" + row.c3 + "\t" + row.c4);

            Console.ReadLine();
        }
    }

}
