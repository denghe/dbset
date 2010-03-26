using System;
using System.Data;
using System.Collections.Generic;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// 返回一个字段（INT) 的表
	/// </summary>
    partial class GetIntList
    {

        public static DbSet ExecuteDbSet()
        {
            return SqlHelper.ExecuteDbSet("GetIntList", true);
        }

    }
	/// <summary>
	/// asdf
	/// </summary>
    partial class GetIntStringList
    {

        partial class Parameters
        {
            public bool Exists_IntList() { return _f_IntList; }

            public void ResetFlags()
            {
                _f_IntList = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("GetIntStringList");
            if( ps.Exists_IntList() ) cmd.AddParameter("IntList", ps.IntList, SqlDbType.Structured, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// as
	/// </summary>
    partial class MergeTest
    {

        public static DbSet ExecuteDbSet()
        {
            return SqlHelper.ExecuteDbSet("MergeTest", true);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class test
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
            var cmd = SqlHelper.NewCommand("test");
            if( ps.Exists_p1() ) cmd.AddParameter("p1", ps.p1, SqlDbType.Variant, false);
            if( ps.Exists_p2() ) cmd.AddParameter("p2", ps.p2, SqlDbType.Variant, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// asdf
	/// </summary>
    partial class usp_Tree_Delete
    {

        partial class Parameters
        {
            public bool Exists_Original_TreeID() { return _f_Original_TreeID; }

            public void ResetFlags()
            {
                _f_Original_TreeID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Delete");
            if( ps.Exists_Original_TreeID() ) cmd.AddParameter("Original_TreeID", ps.Original_TreeID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// xxx
	/// </summary>
    partial class usp_Tree_Delete_ForSqlDataSource
    {

        partial class Parameters
        {
            public bool Exists_TreeID() { return _f_TreeID; }
            public bool Exists_Original_TreeID() { return _f_Original_TreeID; }

            public void ResetFlags()
            {
                _f_TreeID = false;
                _f_Original_TreeID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Delete_ForSqlDataSource");
            if( ps.Exists_TreeID() ) cmd.AddParameter("TreeID", ps.TreeID, SqlDbType.Int, false);
            if( ps.Exists_Original_TreeID() ) cmd.AddParameter("Original_TreeID", ps.Original_TreeID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_Tree_Insert
    {

        partial class Parameters
        {
            public bool Exists_TreeID() { return _f_TreeID; }
            public bool Exists_TreePID() { return _f_TreePID; }
            public bool Exists_Name() { return _f_Name; }
            public bool Exists_Memo() { return _f_Memo; }

            public void ResetFlags()
            {
                _f_TreeID = false;
                _f_TreePID = false;
                _f_Name = false;
                _f_Memo = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Insert");
            if( ps.Exists_TreeID() ) cmd.AddParameter("TreeID", ps.TreeID, SqlDbType.Int, false);
            if( ps.Exists_TreePID() ) cmd.AddParameter("TreePID", ps.TreePID, SqlDbType.Int, false);
            if( ps.Exists_Name() ) cmd.AddParameter("Name", ps.Name, SqlDbType.NVarChar, false);
            if( ps.Exists_Memo() ) cmd.AddParameter("Memo", ps.Memo, SqlDbType.NVarChar, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_Tree_Select
    {

        partial class Parameters
        {
            public bool Exists_TreeID() { return _f_TreeID; }

            public void ResetFlags()
            {
                _f_TreeID = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Select");
            if( ps.Exists_TreeID() ) cmd.AddParameter("TreeID", ps.TreeID, SqlDbType.Int, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_Tree_SelectAll
    {

        public static DbSet ExecuteDbSet()
        {
            return SqlHelper.ExecuteDbSet("usp_Tree_SelectAll", true);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_Tree_Update
    {

        partial class Parameters
        {
            public bool Exists_Original_TreeID() { return _f_Original_TreeID; }
            public bool Exists_TreeID() { return _f_TreeID; }
            public bool Exists_TreePID() { return _f_TreePID; }
            public bool Exists_Name() { return _f_Name; }
            public bool Exists_Memo() { return _f_Memo; }

            public void ResetFlags()
            {
                _f_Original_TreeID = false;
                _f_TreeID = false;
                _f_TreePID = false;
                _f_Name = false;
                _f_Memo = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Update");
            if( ps.Exists_Original_TreeID() ) cmd.AddParameter("Original_TreeID", ps.Original_TreeID, SqlDbType.Int, false);
            if( ps.Exists_TreeID() ) cmd.AddParameter("TreeID", ps.TreeID, SqlDbType.Int, false);
            if( ps.Exists_TreePID() ) cmd.AddParameter("TreePID", ps.TreePID, SqlDbType.Int, false);
            if( ps.Exists_Name() ) cmd.AddParameter("Name", ps.Name, SqlDbType.NVarChar, false);
            if( ps.Exists_Memo() ) cmd.AddParameter("Memo", ps.Memo, SqlDbType.NVarChar, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class usp_Tree_Update_For_SqlDataSource
    {

        partial class Parameters
        {
            public bool Exists_TreeID() { return _f_TreeID; }
            public bool Exists_TreePID() { return _f_TreePID; }
            public bool Exists_Name() { return _f_Name; }
            public bool Exists_Memo() { return _f_Memo; }

            public void ResetFlags()
            {
                _f_TreeID = false;
                _f_TreePID = false;
                _f_Name = false;
                _f_Memo = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand("usp_Tree_Update_For_SqlDataSource");
            if( ps.Exists_TreeID() ) cmd.AddParameter("TreeID", ps.TreeID, SqlDbType.Int, false);
            if( ps.Exists_TreePID() ) cmd.AddParameter("TreePID", ps.TreePID, SqlDbType.Int, false);
            if( ps.Exists_Name() ) cmd.AddParameter("Name", ps.Name, SqlDbType.NVarChar, false);
            if( ps.Exists_Memo() ) cmd.AddParameter("Memo", ps.Memo, SqlDbType.NVarChar, false);
            return SqlHelper.ExecuteDbSet(cmd);
        }

    }
}