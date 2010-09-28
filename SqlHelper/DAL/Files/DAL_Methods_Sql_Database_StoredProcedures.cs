using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// 
	/// </summary>
    partial class StoredProcedure1
    {

        partial class Parameters
        {
            public bool Exists_parameter1() { return _f_parameter1; }
            public bool Exists_parameter2() { return _f_parameter2; }

            public void ResetFlags()
            {
                _f_parameter1 = false;
                _f_parameter2 = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand(@"StoredProcedure1", "dbo");

            if (ps.Exists_parameter1())
            {
                var p = new SqlParameter(@"parameter1", SqlDbType.Int);
                if (ps.parameter1 == null) p.Value = DBNull.Value; else p.Value = ps.parameter1;
                cmd.Parameters.Add(p);
            }

            var _____parameter2 = new SqlParameter(@"parameter2", SqlDbType.Int) { Direction = ParameterDirection.InputOutput };
            if (ps.Exists_parameter2()) if (_____parameter2.Value == null) _____parameter2.Value = DBNull.Value;
                else _____parameter2.Value = ps.parameter2;
            cmd.Parameters.Add(_____parameter2);

            var result = SqlHelper.ExecuteDbSet(cmd);

            if (_____parameter2.Value == DBNull.Value) ps.parameter2 = null;
            else ps.parameter2 = (int)_____parameter2.Value;

            return result;
        }

    }
	/// <summary>
	/// 
	/// </summary>
    partial class xxx
    {

        partial class Parameters
        {
            public bool Exists_iib() { return _f_iib; }

            public void ResetFlags()
            {
                _f_iib = false;
            }
        }
        public static DbSet ExecuteDbSet(Parameters ps)
        {
            var cmd = SqlHelper.NewCommand(@"xxx", "dbo");

            if (ps.Exists_iib())
            {
                var p = new SqlParameter(@"iib", SqlDbType.Structured);
                if (ps.iib == null) p.Value = DBNull.Value; else p.Value = UDTT.表类型.G_INT_INT_BIT_Extensions.ToDataTable(ps.iib);
                cmd.Parameters.Add(p);
            }

            var result = SqlHelper.ExecuteDbSet(cmd);

            return result;
        }

    }
}