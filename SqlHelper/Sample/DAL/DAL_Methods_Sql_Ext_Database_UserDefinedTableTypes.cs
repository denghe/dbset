using System;
using System.Data;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

	/// <summary>
	/// 
	/// </summary>
    public static partial class udt_INT_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<udt_INT> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.id;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class udt_INT_STRING_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<udt_INT_STRING> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[2];
                if(o.column1 == null) rowdata[0] = DBNull.Value;
                else rowdata[0] = o.column1.Value;
                if(o.column2 == null) rowdata[1] = DBNull.Value;
                else rowdata[1] = o.column2;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class udt_test1_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<udt_test1> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.id;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
}