using System;
using System.Data;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.表类型
{

	/// <summary>
	/// 
	/// </summary>
    public static partial class G_INT_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_INT> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.c1;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class G_INT_INT_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_INT_INT> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[2];
                rowdata[0] = o.c1;
                rowdata[1] = o.c2;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class G_INT_STRING_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_INT_STRING> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[2];
                rowdata[0] = o.c1;
                rowdata[1] = o.c2;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class G_INT_STRING_STRING_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_INT_STRING_STRING> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            foreach(var o in os) {
                var rowdata = new object[3];
                rowdata[0] = o.c1;
                rowdata[1] = o.c2;
                rowdata[2] = o.c3;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class G_STRING_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_STRING> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.c1;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class G_STRING_DATETIME_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_STRING_DATETIME> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[2];
                rowdata[0] = o.c1;
                rowdata[1] = o.c2;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
}