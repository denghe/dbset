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
    using tt = DAL.Database.UserDefinedTableTypes.dbo;
    using sp = DAL.Database.StoredProcedures.dbo;

    public class Test {
        public static void Main() {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username: "admin");

            var rows = new List<tt.G_INT_STR>();
            rows.Add(new tt.G_INT_STR { c1 = 12, c2 = "asdf" });
            rows.Add(new tt.G_INT_STR { c1 = 23, c2 = "qwer" });

            var result = sp.需要传个表参.ExecuteDbSet(
                new sp.需要传个表参.Parameters { T = rows }
            );

            result.Dump();

            Console.ReadLine();
        }
    }

}
