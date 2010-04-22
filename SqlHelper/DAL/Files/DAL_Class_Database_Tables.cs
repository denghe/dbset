using System;
using System.Collections.Generic;

namespace DAL.Database.Tables.产品
{

	/// <summary>
	/// 
	/// </summary>
    public partial class 产品
    {
		/// <summary>
		/// 
		/// </summary>
        public int        产品编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     名称   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     说明   { get; set; }
    }
}
namespace DAL.Database.Tables.雇员
{

	/// <summary>
	/// 
	/// </summary>
    public partial class 雇员
    {
		/// <summary>
		/// 
		/// </summary>
        public int        雇员编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     姓名   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public bool       性别   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        年龄   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public byte[]     照片   { get; set; }
    }
}
namespace DAL.Database.Tables.客户
{

	/// <summary>
	/// 
	/// </summary>
    public partial class 订单
    {
		/// <summary>
		/// 
		/// </summary>
        public int        订单编号   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        客户编号   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        经办雇员编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     序列号    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   下单时间   { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class 订单明细
    {
		/// <summary>
		/// 
		/// </summary>
        public int        订单明细编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        订单编号   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public int        产品编号   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public decimal    数量     { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public decimal    单价     { get; set; }
    }
	/// <summary>
	/// 
	/// </summary>
    public partial class 客户
    {
		/// <summary>
		/// 
		/// </summary>
        public int        客户编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     姓名   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     联系方式 { get; set; }
    }
}
namespace DAL.Database.Tables.系统
{

	/// <summary>
	/// 
	/// </summary>
    public partial class 管理员
    {
		/// <summary>
		/// 
		/// </summary>
        public int        管理员编号 { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     登录名   { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string     密码    { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public DateTime   创建时间  { get; set; }
    }
}