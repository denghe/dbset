namespace Sample
{
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
    using SqlLib.DAL;

    public class Test
    {
        public static void Main()
        {
            Console.SetWindowSize(Console.WindowWidth, 50);

            // int sql connection
            SqlHelper.InitConnectString("sql", password: "1");

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
-- return 123;
";
            SqlHelper.ExecuteDbSet(sql, isGetInfoMessage: true).Dump();

            Console.ReadLine();
        }
    }
}
