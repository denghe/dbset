﻿namespace Sample
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

            //var err = new Errors();
            //err.Add(new SqlError { Class = 1, LineNumber = 2, Message = "msg", Number = 3, Procedure = "sp", Server = "server", Source = "source", State = 4 });
            //err.Add(new SqlError { Class = 4, LineNumber = 5, Message = null, Number = 6, Procedure = "", Server = "", Source = "", State = 7 });

            //var err2 = new Errors();
            //var i = 0;
            //err2.Fill(err.GetBytes(), ref i);


            int idx = 0;

            //var dt = new DbTable();
            //dt.NewColumn("c1", typeof(string));
            //dt.NewColumn("c2", typeof(int));
            //dt.NewRow("asdf", 1);
            //dt.NewRow("qwer", 2);

            //var dt2 = new DbTable();
            //idx = 0;
            //dt2.Fill(dt.GetBytes(), ref idx);



            //var dt2 = new DbTable();
            //var idx = 0;
            //dt2.Fill(dt.GetBytes(), ref idx);



            //// 调用一个存储过程并输出结果
            //SqlHelper.ExecuteDbSet(SqlHelper.NewCommand("test")
            //    .AddParameter("p1", 12345)
            //    .AddParameter("p2", DateTime.Now)
            //).Dump();
            //SqlHelper.ExecuteDbSet("test",true).Dump();

            //Console.ReadLine();

            //return;

            // 执行一组 TSQL 并输出
            var ds = SqlHelper.ExecuteDbSet(@"
                        	select 1,2;
                        	print N'print';
                        	select 3,null;
                        	raiserror (N'error',1,1);"
            ).Dump();

            //var ds = new DbSet();
            //var dt = new DbTable();
            //dt.NewColumn("c1", typeof(string));
            //dt.NewColumn("c2", typeof(int));
            //dt.NewRow("asdf", 1);
            //dt.NewRow("qwer", 2);
            //ds.Tables.Add(dt);
            //dt.Set = ds;

            var ds2 = new DbSet();
            idx = 0;
            ds2.Fill(ds.GetBytes(), ref idx);

            ds2.Dump();

            //Console.WriteLine(ds.Errors.GetBytes().GetHexString());

            //var idx = 0;
            //var errors = new Errors();
            //errors.Fill(ds.Errors.GetBytes(), ref idx);



            //var bytes = ds.GetBytes();

            //Console.WriteLine("\r\n\r\n" + bytes.GetHexString());

            //var idx = 0;
            //var ds2 = new DbSet();
            //ds2.Fill(bytes, ref idx);

            //ds2.Dump();

            Console.ReadLine();
            return;


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

        }
    }

}
