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
    using exp = DAL.Expressions.Tables.dbo;
    using tt = DAL.Database.UserDefinedTableTypes.dbo;
    using sp = DAL.Database.StoredProcedures.dbo;

    public class Test {
        public static void Main() {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username:"admin");


            RL();
        }

        public static void RL() {
            Console.ReadLine();
        }
    }
    public static class Extensions {
        public static void WL(this object o) {
            Console.WriteLine(o);
        }
        public static void WL(this byte[] buff) {
            buff.ToHexString().WL();
        }
    }

}
