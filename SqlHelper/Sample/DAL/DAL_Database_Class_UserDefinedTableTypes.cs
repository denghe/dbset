using System;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

	/// <summary>
	/// 
	/// </summary>
    public partial class udt_INT
    {
		/// <summary>
		/// 
		/// </summary>
        public int        id { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class udt_INT_STRING
    {
		/// <summary>
		/// 
		/// </summary>
        public int?       column1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     column2 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class udt_test1
    {
		/// <summary>
		/// 
		/// </summary>
        public int        id { get; set; }
    }
}