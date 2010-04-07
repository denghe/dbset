using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    public static partial class A_Extensions
    {

        #region Insert

		public static int Insert(this A o, ColumnEnums.Tables.dbo.A.Handler insertCols = null, ColumnEnums.Tables.dbo.A.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return A.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this A o, Expressions.Tables.dbo.A.Handler eh = null, ColumnEnums.Tables.dbo.A.Handler updateCols = null, ColumnEnums.Tables.dbo.A.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return A.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this A o, ColumnEnums.Tables.dbo.A.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.A.Delete(t =>
                t.AID == o.AID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.A());
            var exp = new DAL.Expressions.Tables.dbo.A();
            if(cols.Contains(0)) exp.And(t => t.AID == o.AID);
            return dbo.A.Delete(exp);
		}

        #endregion

    }
    public static partial class B_Extensions
    {

        #region Insert

		public static int Insert(this B o, ColumnEnums.Tables.dbo.B.Handler insertCols = null, ColumnEnums.Tables.dbo.B.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return B.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this B o, Expressions.Tables.dbo.B.Handler eh = null, ColumnEnums.Tables.dbo.B.Handler updateCols = null, ColumnEnums.Tables.dbo.B.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return B.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this B o, ColumnEnums.Tables.dbo.B.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.B.Delete(t =>
                t.BID == o.BID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.B());
            var exp = new DAL.Expressions.Tables.dbo.B();
            if(cols.Contains(0)) exp.And(t => t.BID == o.BID);
            if(cols.Contains(1)) exp.And(t => t.AID == o.AID);
            return dbo.B.Delete(exp);
		}

        #endregion

    }
    public static partial class Formula_890_Extensions
    {

        #region Insert

		public static int Insert(this Formula_890 o, ColumnEnums.Tables.dbo.Formula_890.Handler insertCols = null, ColumnEnums.Tables.dbo.Formula_890.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Formula_890.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this Formula_890 o, Expressions.Tables.dbo.Formula_890.Handler eh = null, ColumnEnums.Tables.dbo.Formula_890.Handler updateCols = null, ColumnEnums.Tables.dbo.Formula_890.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return Formula_890.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this Formula_890 o, ColumnEnums.Tables.dbo.Formula_890.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.Formula_890.Delete(t =>
                t.Name == o.Name
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.Formula_890());
            var exp = new DAL.Expressions.Tables.dbo.Formula_890();
            if(cols.Contains(0)) exp.And(t => t.Name == o.Name);
            if(cols.Contains(1)) exp.And(t => t.Expression == o.Expression);
            if(cols.Contains(2)) exp.And(t => t.Value == o.Value);
            if(cols.Contains(3)) exp.And(t => t.IsGenerator == o.IsGenerator);
            return dbo.Formula_890.Delete(exp);
		}

        #endregion

    }
    public static partial class FS_Extensions
    {

        #region Insert

		public static int Insert(this FS o, ColumnEnums.Tables.dbo.FS.Handler insertCols = null, ColumnEnums.Tables.dbo.FS.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return FS.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this FS o, Expressions.Tables.dbo.FS.Handler eh = null, ColumnEnums.Tables.dbo.FS.Handler updateCols = null, ColumnEnums.Tables.dbo.FS.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return FS.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this FS o, ColumnEnums.Tables.dbo.FS.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.FS.Delete(t =>
                t.ID == o.ID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.FS());
            var exp = new DAL.Expressions.Tables.dbo.FS();
            if(cols.Contains(0)) exp.And(t => t.ID == o.ID);
            if(cols.Contains(2)) exp.And(t => t.Stream == o.Stream);
            return dbo.FS.Delete(exp);
		}

        #endregion

    }
    public static partial class ParentChildOrg_Extensions
    {

        #region Insert

		public static int Insert(this ParentChildOrg o, ColumnEnums.Tables.dbo.ParentChildOrg.Handler insertCols = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return ParentChildOrg.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this ParentChildOrg o, Expressions.Tables.dbo.ParentChildOrg.Handler eh = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler updateCols = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return ParentChildOrg.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this ParentChildOrg o, ColumnEnums.Tables.dbo.ParentChildOrg.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.ParentChildOrg.Delete(t =>
                t.EmployeeID == o.EmployeeID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.ParentChildOrg());
            var exp = new DAL.Expressions.Tables.dbo.ParentChildOrg();
            if(cols.Contains(0)) exp.And(t => t.EmployeeID == o.EmployeeID);
            if(cols.Contains(1)) exp.And(t => t.ManagerId == o.ManagerId);
            if(cols.Contains(2)) exp.And(t => t.EmployeeName == o.EmployeeName);
            return dbo.ParentChildOrg.Delete(exp);
		}

        #endregion

    }
    public static partial class t_Extensions
    {

        #region Insert

		public static int Insert(this t o, ColumnEnums.Tables.dbo.t.Handler insertCols = null, ColumnEnums.Tables.dbo.t.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return t.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this t o, Expressions.Tables.dbo.t.Handler eh = null, ColumnEnums.Tables.dbo.t.Handler updateCols = null, ColumnEnums.Tables.dbo.t.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return t.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this t o, ColumnEnums.Tables.dbo.t.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.t.Delete(t =>
                t.a == o.a &
                t.b == o.b &
                t.c == o.c
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.t());
            var exp = new DAL.Expressions.Tables.dbo.t();
            if(cols.Contains(0)) exp.And(t => t.a == o.a);
            if(cols.Contains(1)) exp.And(t => t.b == o.b);
            if(cols.Contains(2)) exp.And(t => t.c == o.c);
            return dbo.t.Delete(exp);
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
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.t1());
            var exp = new DAL.Expressions.Tables.dbo.t1();
            if(cols.Contains(0)) exp.And(t => t.ID == o.ID);
            if(cols.Contains(1)) exp.And(t => t.PID == o.PID);
            return dbo.t1.Delete(exp);
		}

        #endregion

    }
    public static partial class t2_Extensions
    {

        #region Insert

		public static int Insert(this t2 o, ColumnEnums.Tables.dbo.t2.Handler insertCols = null, ColumnEnums.Tables.dbo.t2.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return t2.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this t2 o, Expressions.Tables.dbo.t2.Handler eh = null, ColumnEnums.Tables.dbo.t2.Handler updateCols = null, ColumnEnums.Tables.dbo.t2.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return t2.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this t2 o, ColumnEnums.Tables.dbo.t2.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.t2.Delete(t =>
                t.ID == o.ID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.t2());
            var exp = new DAL.Expressions.Tables.dbo.t2();
            if(cols.Contains(0)) exp.And(t => t.ID == o.ID);
            if(cols.Contains(1)) exp.And(t => t.Name == o.Name);
            if(cols.Contains(2)) exp.And(t => t.CreateTime == o.CreateTime);
            return dbo.t2.Delete(exp);
		}

        #endregion

    }
    public static partial class t3_Extensions
    {

        #region Insert

		public static int Insert(this t3 o, ColumnEnums.Tables.dbo.t3.Handler insertCols = null, ColumnEnums.Tables.dbo.t3.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return t3.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this t3 o, Expressions.Tables.dbo.t3.Handler eh = null, ColumnEnums.Tables.dbo.t3.Handler updateCols = null, ColumnEnums.Tables.dbo.t3.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return t3.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this t3 o, ColumnEnums.Tables.dbo.t3.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.t3.Delete(t =>
                t.c1 == o.c1 &
                t.c2 == o.c2 &
                t.c3 == o.c3 &
                t.c4 == o.c4
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.t3());
            var exp = new DAL.Expressions.Tables.dbo.t3();
            if(cols.Contains(0)) exp.And(t => t.c1 == o.c1);
            if(cols.Contains(1)) exp.And(t => t.c2 == o.c2);
            if(cols.Contains(2)) exp.And(t => t.c3 == o.c3);
            if(cols.Contains(3)) exp.And(t => t.c4 == o.c4);
            return dbo.t3.Delete(exp);
		}

        #endregion

    }
    public static partial class tree_Extensions
    {

        #region Insert

		public static int Insert(this tree o, ColumnEnums.Tables.dbo.tree.Handler insertCols = null, ColumnEnums.Tables.dbo.tree.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return tree.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this tree o, Expressions.Tables.dbo.tree.Handler eh = null, ColumnEnums.Tables.dbo.tree.Handler updateCols = null, ColumnEnums.Tables.dbo.tree.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return tree.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this tree o, ColumnEnums.Tables.dbo.tree.Handler conditionCols = null)
		{
            if(conditionCols == null) return dbo.tree.Delete(t =>
                t.Parent == o.Parent
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.dbo.tree());
            var exp = new DAL.Expressions.Tables.dbo.tree();
            if(cols.Contains(0)) exp.And(t => t.Parent == o.Parent);
            if(cols.Contains(1)) exp.And(t => t.Children == o.Children);
            return dbo.tree.Delete(exp);
		}

        #endregion

    }
}
namespace DAL.Database.Tables.MySchema
{

    public static partial class FS_Extensions
    {

        #region Insert

		public static int Insert(this FS o, ColumnEnums.Tables.MySchema.FS.Handler insertCols = null, ColumnEnums.Tables.MySchema.FS.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return FS.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this FS o, Expressions.Tables.MySchema.FS.Handler eh = null, ColumnEnums.Tables.MySchema.FS.Handler updateCols = null, ColumnEnums.Tables.MySchema.FS.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return FS.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this FS o, ColumnEnums.Tables.MySchema.FS.Handler conditionCols = null)
		{
            if(conditionCols == null) return MySchema.FS.Delete(t =>
                t.ID == o.ID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.MySchema.FS());
            var exp = new DAL.Expressions.Tables.MySchema.FS();
            if(cols.Contains(0)) exp.And(t => t.dbo_FSID == o.dbo_FSID);
            if(cols.Contains(1)) exp.And(t => t.asdf == o.asdf);
            if(cols.Contains(2)) exp.And(t => t.ID == o.ID);
            return MySchema.FS.Delete(exp);
		}

        #endregion

    }
}
namespace DAL.Database.Tables.Schema1
{

    public static partial class T1_Extensions
    {

        #region Insert

		public static int Insert(this T1 o, ColumnEnums.Tables.Schema1.T1.Handler insertCols = null, ColumnEnums.Tables.Schema1.T1.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return T1.Insert(o, insertCols, fillCols, isFillAfterInsert);
		}
        #endregion

        #region Update

		public static int Update(this T1 o, Expressions.Tables.Schema1.T1.Handler eh = null, ColumnEnums.Tables.Schema1.T1.Handler updateCols = null, ColumnEnums.Tables.Schema1.T1.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
            return T1.Update(o, eh, updateCols, fillCols, isFillAfterUpdate);
		}
        #endregion

        #region Delete

		public static int Delete(this T1 o, ColumnEnums.Tables.Schema1.T1.Handler conditionCols = null)
		{
            if(conditionCols == null) return Schema1.T1.Delete(t =>
                t.ID == o.ID
            );
            var cols = conditionCols.Invoke(new DAL.ColumnEnums.Tables.Schema1.T1());
            var exp = new DAL.Expressions.Tables.Schema1.T1();
            if(cols.Contains(0)) exp.And(t => t.ID == o.ID);
            if(cols.Contains(1)) exp.And(t => t.PID == o.PID);
            return Schema1.T1.Delete(exp);
		}

        #endregion

    }
}