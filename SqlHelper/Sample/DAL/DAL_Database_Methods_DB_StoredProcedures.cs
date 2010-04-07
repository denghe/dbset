using System;
using System.Data;
using System.Collections.Generic;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// asdfsadf
	/// </summary>
    partial class GenT2
    {

        partial class Parameters
        {
            public bool Exists_count() { return _f_count; }

            public void ResetFlags()
            {
                _f_count = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("GenT2");
            if( ps.Exists_count() ) cmd.AddParameter("count", ps.count, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class ReturnParm
    {

        partial class Parameters
        {
            public bool Exists_r() { return _f_r; }

            public void ResetFlags()
            {
                _f_r = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("ReturnParm");
            if( ps.Exists_r() ) cmd.AddParameter("r", ps.r, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class SelectNode
    {

        partial class Parameters
        {
            public bool Exists_ID() { return _f_ID; }

            public void ResetFlags()
            {
                _f_ID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("SelectNode");
            if( ps.Exists_ID() ) cmd.AddParameter("ID", ps.ID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class SelectNode_CTE
    {

        partial class Parameters
        {
            public bool Exists_ID() { return _f_ID; }

            public void ResetFlags()
            {
                _f_ID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("SelectNode_CTE");
            if( ps.Exists_ID() ) cmd.AddParameter("ID", ps.ID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class StoredProcedure1
    {

        partial class Parameters
        {
            public bool Exists_s() { return _f_s; }
            public bool Exists_dt() { return _f_dt; }
            public bool Exists_i() { return _f_i; }
            public bool Exists_bytes() { return _f_bytes; }

            public void ResetFlags()
            {
                _f_s = false;
                _f_dt = false;
                _f_i = false;
                _f_bytes = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("StoredProcedure1");
            if( ps.Exists_s() ) cmd.AddParameter("s", ps.s, SqlDbType.NVarChar, false);
            if( ps.Exists_dt() ) cmd.AddParameter("dt", ps.dt, SqlDbType.DateTime, false);
            if( ps.Exists_i() ) cmd.AddParameter("i", ps.i, SqlDbType.Int, false);
            if( ps.Exists_bytes() ) cmd.AddParameter("bytes", ps.bytes, SqlDbType.VarBinary, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class StoredProcedure2
    {

        partial class Parameters
        {
            public bool Exists_m() { return _f_m; }

            public void ResetFlags()
            {
                _f_m = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("StoredProcedure2");
            if( ps.Exists_m() ) cmd.AddParameter("m", ps.m, SqlDbType.Xml, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class StoredProcedure3
    {

        partial class Parameters
        {
            public bool Exists_i() { return _f_i; }
            public bool Exists_m() { return _f_m; }
            public bool Exists_dt() { return _f_dt; }

            public void ResetFlags()
            {
                _f_i = false;
                _f_m = false;
                _f_dt = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("StoredProcedure3");
            if( ps.Exists_i() ) cmd.AddParameter("i", ps.i, SqlDbType.Int, false);
            if( ps.Exists_m() ) cmd.AddParameter("m", ps.m, SqlDbType.Money, false);
            if( ps.Exists_dt() ) cmd.AddParameter("dt", ps.dt, SqlDbType.DateTime, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class TestReturn
    {

        partial class Parameters
        {
            public bool Exists_r() { return _f_r; }

            public void ResetFlags()
            {
                _f_r = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("TestReturn");
            if( ps.Exists_r() ) cmd.AddParameter("r", ps.r, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class TestTableType
    {

        partial class Parameters
        {
            public bool Exists_T() { return _f_T; }

            public void ResetFlags()
            {
                _f_T = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("TestTableType");
            if( ps.Exists_T() ) cmd.AddParameter("T", UDTT.dbo.G_INT_STR_Extensions.ToDataTable(ps.T), SqlDbType.Structured, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 测试自定义表类型
	/// </summary>
    partial class usp_NeedMyType1
    {

        partial class Parameters
        {
            public bool Exists_MyType1() { return _f_MyType1; }

            public void ResetFlags()
            {
                _f_MyType1 = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_NeedMyType1");
            if( ps.Exists_MyType1() ) cmd.AddParameter("MyType1", UDTT.dbo.MyType1_Extensions.ToDataTable(ps.MyType1), SqlDbType.Structured, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_SelectP1
    {

        partial class Parameters
        {
            public bool Exists_P1() { return _f_P1; }

            public void ResetFlags()
            {
                _f_P1 = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_SelectP1");
            if( ps.Exists_P1() ) cmd.AddParameter("P1", UDTT.dbo.FS_Extensions.ToDataTable(ps.P1), SqlDbType.Structured, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_testp1p2
    {

        partial class Parameters
        {
            public bool Exists_p1() { return _f_p1; }
            public bool Exists_p2() { return _f_p2; }

            public void ResetFlags()
            {
                _f_p1 = false;
                _f_p2 = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_testp1p2");
            if( ps.Exists_p1() ) cmd.AddParameter("p1", ps.p1, SqlDbType.Int, false);
            if( ps.Exists_p2() ) cmd.AddParameter("p2", ps.p2, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class 需要传个表参
    {

        partial class Parameters
        {
            public bool Exists_T() { return _f_T; }

            public void ResetFlags()
            {
                _f_T = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("需要传个表参");
            if( ps.Exists_T() ) cmd.AddParameter("T", UDTT.dbo.G_INT_STR_Extensions.ToDataTable(ps.T), SqlDbType.Structured, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
}
namespace DAL.Database.StoredProcedures.Schema1
{

	/// <summary>
	/// 
	/// </summary>
    partial class GenT1
    {

        partial class Parameters
        {
            public bool Exists_count() { return _f_count; }

            public void ResetFlags()
            {
                _f_count = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("GenT1");
            if( ps.Exists_count() ) cmd.AddParameter("count", ps.count, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 针对 表 [Schema1].[T1]
	/// 根据主键值返回一个节点的多行数据
	/// </summary>
    partial class usp_T1_SelectNode
    {

        partial class Parameters
        {
            public bool Exists_ID() { return _f_ID; }

            public void ResetFlags()
            {
                _f_ID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_T1_SelectNode");
            if( ps.Exists_ID() ) cmd.AddParameter("ID", ps.ID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
}