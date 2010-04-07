using System;
using System.Data;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

	/// <summary>
	/// aeeeffffffffffff
	/// </summary>
    public static partial class FS_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<FS> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.Col1;
                rowdata[1] = o.Col2;
                if(o.Col3 == null) rowdata[2] = DBNull.Value;
                else rowdata[2] = o.Col3;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// x!
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
    public static partial class G_INT_STR_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<G_INT_STR> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[1];
                if(o.c1 == null) rowdata[0] = DBNull.Value;
                else rowdata[0] = o.c1.Value;
                if(o.c2 == null) rowdata[1] = DBNull.Value;
                else rowdata[1] = o.c2;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// sadfsadf
	/// </summary>
    public static partial class MyType1_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<MyType1> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.Str;
                if(o.Num == null) rowdata[1] = DBNull.Value;
                else rowdata[1] = o.Num.Value;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class ParentChildOrg_Extensions
    {
        public static DataTable ToDataTable(this IEnumerable<ParentChildOrg> os)
        {
            var dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            foreach(var o in os) {
                var rowdata = new object[1];
                rowdata[0] = o.EmployeeID;
                if(o.ManagerId == null) rowdata[1] = DBNull.Value;
                else rowdata[1] = o.ManagerId.Value;
                if(o.EmployeeName == null) rowdata[2] = DBNull.Value;
                else rowdata[2] = o.EmployeeName;
                dt.Rows.Add(rowdata);
            }
            return dt;
        }
    }
}