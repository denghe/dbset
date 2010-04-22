using System;
using System.Collections.Generic;

namespace DAL.Database.UserDefinedTableTypes.表类型
{

	/// <summary>
	/// 
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
    public partial class G_INT_INT
    {
		/// <summary>
		/// 
		/// </summary>
        public int        c1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        c2 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class G_INT_STRING
    {
		/// <summary>
		/// 
		/// </summary>
        public int        c1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     c2 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class G_INT_STRING_STRING
    {
		/// <summary>
		/// 
		/// </summary>
        public int        c1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     c2 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     c3 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class G_STRING
    {
		/// <summary>
		/// 
		/// </summary>
        public string     c1 { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class G_STRING_DATETIME
    {
		/// <summary>
		/// 
		/// </summary>
        public string     c1 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   c2 { get; set; }
    }
}