namespace DAL.UserDefinedTableTypes.dbo
{
    using System;
    using System.Collections.Generic;


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
    public partial class udt_INT_Collection : List<udt_INT>
    {
        // todo: ToDataTable()
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
    public partial class udt_INT_STRING_Collection : List<udt_INT_STRING>
    {
        // todo: ToDataTable()
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
    public partial class udt_test1_Collection : List<udt_test1>
    {
        // todo: ToDataTable()
    }
}