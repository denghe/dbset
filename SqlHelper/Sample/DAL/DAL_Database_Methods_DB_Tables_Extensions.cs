using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    public static partial class Child_Extensions
    {

        #region Insert

		public static int Insert(this Child o, ColumnEnums.Tables.dbo.Child.Handler insertCols = null, ColumnEnums.Tables.dbo.Child.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Child.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this Child o, Expressions.Tables.dbo.Child.Handler eh = null, ColumnEnums.Tables.dbo.Child.Handler updateCols = null, ColumnEnums.Tables.dbo.Child.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return Child.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this Child o, ColumnEnums.Tables.dbo.Child.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.Child.Delete(t =>
                t.ChildID == o.ChildID
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.Child());
            var exp = new DAL.Expressions.Tables.dbo.Child();
            if(cols.Contains(0)) exp.And(t => t.TreeID == o.TreeID);
            if(cols.Contains(1)) exp.And(t => t.ChildID == o.ChildID);
            if(cols.Contains(2)) exp.And(t => t.Name == o.Name);
            if(cols.Contains(3)) exp.And(t => t.CreateTime == o.CreateTime);
            if(cols.Contains(4)) exp.And(t => t.Memo == o.Memo);
            return dbo.Child.Delete(exp);
		}

        #endregion

    }
    public static partial class ChildLog_Extensions
    {

        #region Insert

		public static int Insert(this ChildLog o, ColumnEnums.Tables.dbo.ChildLog.Handler insertCols = null, ColumnEnums.Tables.dbo.ChildLog.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return ChildLog.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this ChildLog o, Expressions.Tables.dbo.ChildLog.Handler eh = null, ColumnEnums.Tables.dbo.ChildLog.Handler updateCols = null, ColumnEnums.Tables.dbo.ChildLog.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return ChildLog.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this ChildLog o, ColumnEnums.Tables.dbo.ChildLog.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.ChildLog.Delete(t =>
                t.ChildLogID == o.ChildLogID
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.ChildLog());
            var exp = new DAL.Expressions.Tables.dbo.ChildLog();
            if(cols.Contains(0)) exp.And(t => t.ChildID == o.ChildID);
            if(cols.Contains(1)) exp.And(t => t.ChildLogID == o.ChildLogID);
            if(cols.Contains(2)) exp.And(t => t.CreateTime == o.CreateTime);
            if(cols.Contains(3)) exp.And(t => t.LogContent == o.LogContent);
            return dbo.ChildLog.Delete(exp);
		}

        #endregion

    }
    public static partial class DoublePK_Extensions
    {

        #region Insert

		public static int Insert(this DoublePK o, ColumnEnums.Tables.dbo.DoublePK.Handler insertCols = null, ColumnEnums.Tables.dbo.DoublePK.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return DoublePK.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this DoublePK o, Expressions.Tables.dbo.DoublePK.Handler eh = null, ColumnEnums.Tables.dbo.DoublePK.Handler updateCols = null, ColumnEnums.Tables.dbo.DoublePK.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return DoublePK.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this DoublePK o, ColumnEnums.Tables.dbo.DoublePK.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.DoublePK.Delete(t =>
                t.ID1 == o.ID1 &
                t.ID2 == o.ID2
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.DoublePK());
            var exp = new DAL.Expressions.Tables.dbo.DoublePK();
            if(cols.Contains(0)) exp.And(t => t.ID1 == o.ID1);
            if(cols.Contains(1)) exp.And(t => t.ID2 == o.ID2);
            return dbo.DoublePK.Delete(exp);
		}

        #endregion

    }
    public static partial class Orders_Extensions
    {

        #region Insert

		public static int Insert(this Orders o, ColumnEnums.Tables.dbo.Orders.Handler insertCols = null, ColumnEnums.Tables.dbo.Orders.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Orders.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this Orders o, Expressions.Tables.dbo.Orders.Handler eh = null, ColumnEnums.Tables.dbo.Orders.Handler updateCols = null, ColumnEnums.Tables.dbo.Orders.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return Orders.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this Orders o, ColumnEnums.Tables.dbo.Orders.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.Orders.Delete(t =>
                t.OrderID == o.OrderID
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.Orders());
            var exp = new DAL.Expressions.Tables.dbo.Orders();
            if(cols.Contains(0)) exp.And(t => t.OrderID == o.OrderID);
            if(cols.Contains(1)) exp.And(t => t.memberID == o.memberID);
            if(cols.Contains(2)) exp.And(t => t.orderDate == o.orderDate);
            return dbo.Orders.Delete(exp);
		}

        #endregion

    }
    public static partial class t1_Extensions
    {

        #region Insert

		public static int Insert(this t1 o, ColumnEnums.Tables.dbo.t1.Handler insertCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return t1.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this t1 o, Expressions.Tables.dbo.t1.Handler eh = null, ColumnEnums.Tables.dbo.t1.Handler updateCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return t1.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this t1 o, ColumnEnums.Tables.dbo.t1.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.t1.Delete(t =>
                t.ID == o.ID
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.t1());
            var exp = new DAL.Expressions.Tables.dbo.t1();
            if(cols.Contains(0)) exp.And(t => t.ID == o.ID);
            if(cols.Contains(1)) exp.And(t => t.Name == o.Name);
            if(cols.Contains(2)) exp.And(t => t.XML == o.XML);
            return dbo.t1.Delete(exp);
		}

        #endregion

    }
    public static partial class TA_Extensions
    {

        #region Insert

		public static int Insert(this TA o, ColumnEnums.Tables.dbo.TA.Handler insertCols = null, ColumnEnums.Tables.dbo.TA.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return TA.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this TA o, Expressions.Tables.dbo.TA.Handler eh = null, ColumnEnums.Tables.dbo.TA.Handler updateCols = null, ColumnEnums.Tables.dbo.TA.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return TA.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this TA o, ColumnEnums.Tables.dbo.TA.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.TA.Delete(t =>
                t.AID == o.AID &
                t.AData == o.AData
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.TA());
            var exp = new DAL.Expressions.Tables.dbo.TA();
            if(cols.Contains(0)) exp.And(t => t.AID == o.AID);
            if(cols.Contains(1)) exp.And(t => t.AData == o.AData);
            return dbo.TA.Delete(exp);
		}

        #endregion

    }
    public static partial class TB_Extensions
    {

        #region Insert

		public static int Insert(this TB o, ColumnEnums.Tables.dbo.TB.Handler insertCols = null, ColumnEnums.Tables.dbo.TB.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return TB.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this TB o, Expressions.Tables.dbo.TB.Handler eh = null, ColumnEnums.Tables.dbo.TB.Handler updateCols = null, ColumnEnums.Tables.dbo.TB.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return TB.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this TB o, ColumnEnums.Tables.dbo.TB.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.TB.Delete(t =>
                t.BID == o.BID &
                t.BData == o.BData
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.TB());
            var exp = new DAL.Expressions.Tables.dbo.TB();
            if(cols.Contains(0)) exp.And(t => t.BID == o.BID);
            if(cols.Contains(1)) exp.And(t => t.BData == o.BData);
            return dbo.TB.Delete(exp);
		}

        #endregion

    }
    public static partial class Tree_Extensions
    {

        #region Insert

		public static int Insert(this Tree o, ColumnEnums.Tables.dbo.Tree.Handler insertCols = null, ColumnEnums.Tables.dbo.Tree.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Tree.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this Tree o, Expressions.Tables.dbo.Tree.Handler eh = null, ColumnEnums.Tables.dbo.Tree.Handler updateCols = null, ColumnEnums.Tables.dbo.Tree.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return Tree.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this Tree o, ColumnEnums.Tables.dbo.Tree.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.Tree.Delete(t =>
                t.TreeID == o.TreeID
            );
            var cols = conditionCols(new DAL.ColumnEnums.Tables.dbo.Tree());
            var exp = new DAL.Expressions.Tables.dbo.Tree();
            if(cols.Contains(0)) exp.And(t => t.TreeID == o.TreeID);
            if(cols.Contains(1)) exp.And(t => t.TreePID == o.TreePID);
            if(cols.Contains(2)) exp.And(t => t.Name == o.Name);
            if(cols.Contains(3)) exp.And(t => t.Memo == o.Memo);
            return dbo.Tree.Delete(exp);
		}

        #endregion

    }
}