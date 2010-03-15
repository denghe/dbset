namespace DAL.Database.UserDefinedTableTypes.dbo
{
    using System;
    using System.Collections.Generic;


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
    public partial class FS_Collection : List<FS>
    {
        // todo: ToDataTable()
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
    public partial class G_INT_Collection : List<G_INT>
    {
        // todo: ToDataTable()
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
    public partial class G_INT_STR_Collection : List<G_INT_STR>
    {
        // todo: ToDataTable()
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
    public partial class MyType1_Collection : List<MyType1>
    {
        // todo: ToDataTable()
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
    public partial class ParentChildOrg_Collection : List<ParentChildOrg>
    {
        // todo: ToDataTable()
    }
}