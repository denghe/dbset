using System;
using System.Data;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

	/// <summary>
	/// 
	/// </summary>
    partial class udt_INT_Collection : List<udt_INT>
    {
        public DataTable ToDataTable()
        {
		/// <summary>
		/// 
		/// </summary>
            return null;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    partial class udt_INT_STRING_Collection : List<udt_INT_STRING>
    {
        public DataTable ToDataTable()
        {
		/// <summary>
		/// 
		/// </summary>
		/// <summary>
		/// 
		/// </summary>
            return null;
        }
    }
	/// <summary>
	/// 
	/// </summary>
    partial class udt_test1_Collection : List<udt_test1>
    {
        public DataTable ToDataTable()
        {
		/// <summary>
		/// 
		/// </summary>
            return null;
        }
    }
}