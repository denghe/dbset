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
            SqlHelper.InitConnectString(server: "sql");

            var q = query.Tree.New(
                o => o.Name.Like("asdf") & o.TreePID == null
                , o => o.Name.DESC & o.TreeID.ASC
                , 12, 34
                , o => o.TreeID.Memo);

            var buff = q.GetBytes();
            buff.WL();

            var q2 = new query.Tree(buff);

            q2.PageSize.WL();
            q2.PageIndex.WL();
            q2.Where.WL();
            q2.OrderBy.WL();
            q2.Columns.WL();

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
