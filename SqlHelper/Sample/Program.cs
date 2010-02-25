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

    using DAL;
    using SpResultConfig;
    using System.Diagnostics;

    public class Test
    {
        public static void Main()
        {
            // 初始化连接串
            SqlHelper.InitConnectString("data,14333", password: "dreamgame@8844028.com");

            // 执行一组 TSQL 并输出
            var ds = SqlHelper.ExecuteDbSet(@"
                        	select 1 as 'c1',2 as 'c2';
                        	print N'print';
                        	select 3,null;
                        	raiserror (N'error',1,1);"
            );
            var bytes = ds.GetBytes();

            Console.Write(bytes.ToHexString());

            Console.ReadLine();
            return;

            var ds2 = new DbSet(bytes);
            ds2.Dump();

            Console.ReadLine();
            return;


            #region Config

            using (var tran = SqlHelper.NewTransaction())
            {
                SqlHelper.ExecuteDbSet(@"select count(*) from t1;").Dump();
                SqlHelper.ExecuteDbSet("delete from t1 where id = 12;print N'deleted';raiserror ('xx',1,1);").Dump();
                SqlHelper.ExecuteDbSet(@"select count(*) from t1;").Dump();
                // Console.WriteLine((from DbRow row in result.Rows select row["ID"]).Combine());
                // SqlHelper.ExecuteDbTable(@"select * from tree;").Dump();
                tran.Rollback();
                SqlHelper.ExecuteDbSet(@"select count(*) from t1;").Dump();
            }

            var s = @"
<Config>
	<Options Select=""True"" Return=""True"" Print=""True"" Raiserror=""True"" />

	<Result Name=""Total"" 		Category=""Scalar"" 	Type=""Int32"" 	Description=""总行数"" />
	<Result Name=""PageSize"" 	Category=""Scalar"" 	Type=""Int32"" 	Description=""每页行数"" />
	<Result Name=""Rows"" 		Category=""TableRows"" 	Struct=""xxx""  Schema=""dbo"" 	 			Description=""dbo.xxx表当前页的数据"" />
	<Result Name=""SomeData1""  Category=""StructRow""  Struct=""asdf"" Description=""附带的相关明细数据1（单行）"" />
	<Result Name=""SomeData2""  Category=""StructRows"" Struct=""qwer"" Description=""附带的相关明细数据2（多行）"" />

    <Struct Name=""asdf"">
		<Column Name=""ID"" 	    Type=""Int32"" 	    Nullable=""False""  Description=""编号"" />
		<Column Name=""Name"" 	    Type=""String"" 	Nullable=""False""  Description=""名称"" />
		<Column Name=""SaleTime"" 	Type=""DateTime"" 	Nullable=""True""   Description=""出货时间"" />
    </Struct>
    <Struct Name=""qwer"">
		<Column Name=""ID"" 	    Type=""Int32"" 	    Nullable=""False""  Description=""编号"" />
		<Column Name=""Price"" 	    Type=""Decimal""    Nullable=""False""  Description=""价格"" />
    </Struct>
</Config>
";
            var cfg = s.GetConfig();

            foreach (var o in cfg.Structs) foreach (var c in o.Columns) Console.WriteLine(c.Type.ToString());
            foreach (var o in cfg.Results) Console.WriteLine(o.Category.ToString());

            Console.ReadKey();

            #endregion
        }
    }

}
