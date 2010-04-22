using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.产品
{

    public static partial class 产品_Extensions
    {

        #region Insert

		public static int Insert(this 产品 o, ColumnEnums.Tables.产品.产品.Handler insertCols = null, ColumnEnums.Tables.产品.产品.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 产品.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 产品 o, Expressions.Tables.产品.产品.Handler eh = null, ColumnEnums.Tables.产品.产品.Handler updateCols = null, ColumnEnums.Tables.产品.产品.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 产品.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 产品 o, ColumnEnums.Tables.产品.产品.Handler conditionCols = null)
		{
            if(conditionCols == null) return 产品.产品.Delete(t =>
                t.产品编号 == o.产品编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.产品.产品());
            var exp = new DAL.Expressions.Tables.产品.产品();
            if(cols.Contains(0)) exp.And(t => t.产品编号 == o.产品编号);
            if(cols.Contains(1)) exp.And(t => t.名称 == o.名称);
            if(cols.Contains(2)) exp.And(t => t.说明 == o.说明);
            return 产品.产品.Delete(exp);
		}

        #endregion

    }
}
namespace DAL.Database.Tables.雇员
{

    public static partial class 雇员_Extensions
    {

        #region Insert

		public static int Insert(this 雇员 o, ColumnEnums.Tables.雇员.雇员.Handler insertCols = null, ColumnEnums.Tables.雇员.雇员.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 雇员.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 雇员 o, Expressions.Tables.雇员.雇员.Handler eh = null, ColumnEnums.Tables.雇员.雇员.Handler updateCols = null, ColumnEnums.Tables.雇员.雇员.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 雇员.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 雇员 o, ColumnEnums.Tables.雇员.雇员.Handler conditionCols = null)
		{
            if(conditionCols == null) return 雇员.雇员.Delete(t =>
                t.雇员编号 == o.雇员编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.雇员.雇员());
            var exp = new DAL.Expressions.Tables.雇员.雇员();
            if(cols.Contains(0)) exp.And(t => t.雇员编号 == o.雇员编号);
            if(cols.Contains(1)) exp.And(t => t.姓名 == o.姓名);
            if(cols.Contains(2)) exp.And(t => t.性别 == o.性别);
            if(cols.Contains(3)) exp.And(t => t.年龄 == o.年龄);
            if(cols.Contains(4)) exp.And(t => t.照片 == o.照片);
            return 雇员.雇员.Delete(exp);
		}

        #endregion

    }
}
namespace DAL.Database.Tables.客户
{

    public static partial class 订单_Extensions
    {

        #region Insert

		public static int Insert(this 订单 o, ColumnEnums.Tables.客户.订单.Handler insertCols = null, ColumnEnums.Tables.客户.订单.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 订单.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 订单 o, Expressions.Tables.客户.订单.Handler eh = null, ColumnEnums.Tables.客户.订单.Handler updateCols = null, ColumnEnums.Tables.客户.订单.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 订单.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 订单 o, ColumnEnums.Tables.客户.订单.Handler conditionCols = null)
		{
            if(conditionCols == null) return 客户.订单.Delete(t =>
                t.订单编号 == o.订单编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.客户.订单());
            var exp = new DAL.Expressions.Tables.客户.订单();
            if(cols.Contains(0)) exp.And(t => t.订单编号 == o.订单编号);
            if(cols.Contains(1)) exp.And(t => t.客户编号 == o.客户编号);
            if(cols.Contains(2)) exp.And(t => t.经办雇员编号 == o.经办雇员编号);
            if(cols.Contains(3)) exp.And(t => t.下单时间 == o.下单时间);
            return 客户.订单.Delete(exp);
		}

        #endregion

    }
    public static partial class 订单明细_Extensions
    {

        #region Insert

		public static int Insert(this 订单明细 o, ColumnEnums.Tables.客户.订单明细.Handler insertCols = null, ColumnEnums.Tables.客户.订单明细.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 订单明细.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 订单明细 o, Expressions.Tables.客户.订单明细.Handler eh = null, ColumnEnums.Tables.客户.订单明细.Handler updateCols = null, ColumnEnums.Tables.客户.订单明细.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 订单明细.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 订单明细 o, ColumnEnums.Tables.客户.订单明细.Handler conditionCols = null)
		{
            if(conditionCols == null) return 客户.订单明细.Delete(t =>
                t.订单明细编号 == o.订单明细编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.客户.订单明细());
            var exp = new DAL.Expressions.Tables.客户.订单明细();
            if(cols.Contains(0)) exp.And(t => t.订单明细编号 == o.订单明细编号);
            if(cols.Contains(1)) exp.And(t => t.订单编号 == o.订单编号);
            if(cols.Contains(2)) exp.And(t => t.产品编号 == o.产品编号);
            if(cols.Contains(3)) exp.And(t => t.数量 == o.数量);
            if(cols.Contains(4)) exp.And(t => t.单价 == o.单价);
            return 客户.订单明细.Delete(exp);
		}

        #endregion

    }
    public static partial class 客户_Extensions
    {

        #region Insert

		public static int Insert(this 客户 o, ColumnEnums.Tables.客户.客户.Handler insertCols = null, ColumnEnums.Tables.客户.客户.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 客户.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 客户 o, Expressions.Tables.客户.客户.Handler eh = null, ColumnEnums.Tables.客户.客户.Handler updateCols = null, ColumnEnums.Tables.客户.客户.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 客户.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 客户 o, ColumnEnums.Tables.客户.客户.Handler conditionCols = null)
		{
            if(conditionCols == null) return 客户.客户.Delete(t =>
                t.客户编号 == o.客户编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.客户.客户());
            var exp = new DAL.Expressions.Tables.客户.客户();
            if(cols.Contains(0)) exp.And(t => t.客户编号 == o.客户编号);
            if(cols.Contains(1)) exp.And(t => t.姓名 == o.姓名);
            if(cols.Contains(2)) exp.And(t => t.联系方式 == o.联系方式);
            return 客户.客户.Delete(exp);
		}

        #endregion

    }
}
namespace DAL.Database.Tables.系统
{

    public static partial class 管理员_Extensions
    {

        #region Insert

		public static int Insert(this 管理员 o, ColumnEnums.Tables.系统.管理员.Handler insertCols = null, ColumnEnums.Tables.系统.管理员.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return 管理员.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this 管理员 o, Expressions.Tables.系统.管理员.Handler eh = null, ColumnEnums.Tables.系统.管理员.Handler updateCols = null, ColumnEnums.Tables.系统.管理员.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return 管理员.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this 管理员 o, ColumnEnums.Tables.系统.管理员.Handler conditionCols = null)
		{
            if(conditionCols == null) return 系统.管理员.Delete(t =>
                t.管理员编号 == o.管理员编号
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.系统.管理员());
            var exp = new DAL.Expressions.Tables.系统.管理员();
            if(cols.Contains(0)) exp.And(t => t.管理员编号 == o.管理员编号);
            if(cols.Contains(1)) exp.And(t => t.登录名 == o.登录名);
            if(cols.Contains(2)) exp.And(t => t.密码 == o.密码);
            if(cols.Contains(3)) exp.And(t => t.创建时间 == o.创建时间);
            return 系统.管理员.Delete(exp);
		}

        #endregion

    }
}