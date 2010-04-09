using System;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

	/// <summary>
	/// aeeeffffffffffff
	/// </summary>
    public partial class FS
    {
		/// <summary>
		/// aaaaaaaaaaaa
		/// </summary>
        public int        Col1 { get; set; }
		/// <summary>
		/// qq
		/// </summary>
        public int        Col2 { get; set; }
		/// <summary>
		/// asdf
		/// </summary>
        public string     Col3 { get; set; }
    }
	/// <summary>
	/// x!
	/// </summary>
    public partial class G_INT
    {
		/// <summary>
		/// 
		/// </summary>
        public int        c1 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class G_INT_STR
    {
		/// <summary>
		/// 
		/// </summary>
        public int?       c1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     c2 { get; set; }
    }
	/// <summary>
	/// sadfsadf
	/// </summary>
    public partial class MyType1
    {
		/// <summary>
		/// 
		/// </summary>
        public string     Str { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int?       Num { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class ParentChildOrg
    {
		/// <summary>
		/// 
		/// </summary>
        public int        EmployeeID   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int?       ManagerId    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     EmployeeName { get; set; }
    }
}