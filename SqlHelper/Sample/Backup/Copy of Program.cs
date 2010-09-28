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
    using DAL;

    public class Test {
        public static void Main() {
            Console.SetWindowSize(Console.WindowWidth, 50);





            SqlHelper.InitConnectString("data,14333", "Test", "admin", "1");

            var exp = ex.产品.产品.New(a => a.产品编号.In(27, 28));
            exp.ToSqlString().WL();

            byte[] buff = exp.GetBytes();

            var exp2 = new ex.产品.产品(buff);
            exp2.ToSqlString().WL();

            var p = new sp.dbo.xxx.Parameters
            {
                iib = new tt.G_INT_INT_BIT[] {
                    new tt.G_INT_INT_BIT { c1 = 1, c2 = 1, c3 = true },
                    new tt.G_INT_INT_BIT { c1 = 2, c2 = 2, c3 = true },
                    new tt.G_INT_INT_BIT { c1 = 3, c2 = 3, c3 = false }
                }
            };
            var ds = sp.dbo.xxx.ExecuteDbSet(p);

            ds.Dump();






            // int sql connection
            SqlHelper.InitConnectString("sql");

            // test get info messages, multi select results
            var sql = @"
print 'begin';
select 3 as 'Rows',1 as 'PageIdx', 10 as 'PageSize';
raiserror ('warning1',1,1);
select 1 as 'ID', 'apple' as 'Name', 2.34 as 'Price'
union all
select 2, 'orange', 3.12
union all
select 3, 'banana', 1.23;
print 'end'
raiserror ('warning2',1,1);
";
            SqlHelper.ExecuteDbSet(sql, isGetInfoMessage: true).Dump();

            // test sp's return value.
            // test call TableType Parameter's sp
            /*
CREATE TYPE [dbo].[G_INT_STR] AS TABLE(
	c1 int,
	c2 nvarchar(max)
)
CREATE PROCEDURE TestTableType
    @T dbo.G_INT_STR READONLY
AS BEGIN
    SELECT * FROM @T;
    RETURN (SELECT COUNT(*) FROM @T);
END
             */

            Console.ReadLine();
        }
    }
}
