namespace DAL.Database.Tables.dbo
{
    using System;
    using System.Collections.Generic;

	/// <summary>
	/// aaa
	/// </summary>
    public partial class Formula_890
    {
		/// <summary>
		/// bbbbb
		/// </summary>
        public string     Name        { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Expression  { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Value       { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public bool?      IsGenerator { get; set; }
    }
	/// <summary>
	/// adf
	/// </summary>
    public partial class FS
    {
		/// <summary>
		/// fdsfd
		/// </summary>
        public Guid       ID       { get; set; }
		/// <summary>
		/// fdfd
		/// </summary>
        public object     Category { get; set; }
		/// <summary>
		/// dfaffffw
		/// </summary>
        public byte[]     Stream   { get; set; }
    }
	/// <summary>
	/// asdf
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
	/// <summary>
	/// 
	/// </summary>
    public partial class t
    {
		/// <summary>
		/// 
		/// </summary>
        public int        a { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        b { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public byte[]     c { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class t1
    {
		/// <summary>
		/// 
		/// </summary>
        public int        ID  { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int?       PID { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class t2
    {
		/// <summary>
		/// 
		/// </summary>
        public int        ID         { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Name       { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   CreateTime { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class tree
    {
		/// <summary>
		/// 
		/// </summary>
        public string     Parent   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Children { get; set; }
    }
}namespace DAL.Database.Tables.MySchema
{
    using System;
    using System.Collections.Generic;

	/// <summary>
	/// 
	/// </summary>
    public partial class FS
    {
		/// <summary>
		/// 
		/// </summary>
        public Guid       dbo_FSID { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     asdf     { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        ID       { get; set; }
    }
}namespace DAL.Database.Tables.Schema1
{
    using System;
    using System.Collections.Generic;

	/// <summary>
	/// 树表
	/// </summary>
    public partial class T1
    {
		/// <summary>
		/// 
		/// </summary>
        public int        ID  { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int?       PID { get; set; }
    }
}