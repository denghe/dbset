namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;

	/// <summary>
	/// 
	/// </summary>
    public partial class Child
    {
		/// <summary>
		/// 
		/// </summary>
        public int        TreeID     { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public Guid       ChildID    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Name       { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Memo       { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class ChildLog
    {
		/// <summary>
		/// 
		/// </summary>
        public Guid       ChildID    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        ChildLogID { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     LogContent { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class DoublePK
    {
		/// <summary>
		/// 
		/// </summary>
        public int        ID1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        ID2 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class Orders
    {
		/// <summary>
		/// 
		/// </summary>
        public int        OrderID   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        memberID  { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   orderDate { get; set; }
    }
	/// <summary>
	/// asdfasdf
	/// </summary>
    public partial class t1
    {
		/// <summary>
		/// asdfsadfsadf
		/// </summary>
        public int        ID   { get; set; }
		/// <summary>
		/// asdfsadfsadf
		/// </summary>
        public string     Name { get; set; }
		/// <summary>
		/// awfeaewfawefwaef
		/// </summary>
        public string     XML  { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class TA
    {
		/// <summary>
		/// 
		/// </summary>
        public int?       AID   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     AData { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class TB
    {
		/// <summary>
		/// 
		/// </summary>
        public int?       BID   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     BData { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class Tree
    {
		/// <summary>
		/// 
		/// </summary>
        public int        TreeID  { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int?       TreePID { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Name    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     Memo    { get; set; }
    }
}