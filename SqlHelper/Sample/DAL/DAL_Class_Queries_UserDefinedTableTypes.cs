using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.UserDefinedTableTypes.dbo
{

    public partial class FS : Query<FS, Expressions.UserDefinedTableTypes.dbo.FS, Orientations.UserDefinedTableTypes.dbo.FS, ColumnEnums.UserDefinedTableTypes.dbo.FS>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"FS", columns);
        }
    }
    public partial class G_INT : Query<G_INT, Expressions.UserDefinedTableTypes.dbo.G_INT, Orientations.UserDefinedTableTypes.dbo.G_INT, ColumnEnums.UserDefinedTableTypes.dbo.G_INT>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"G_INT", columns);
        }
    }
    public partial class G_INT_STR : Query<G_INT_STR, Expressions.UserDefinedTableTypes.dbo.G_INT_STR, Orientations.UserDefinedTableTypes.dbo.G_INT_STR, ColumnEnums.UserDefinedTableTypes.dbo.G_INT_STR>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"G_INT_STR", columns);
        }
    }
    public partial class MyType1 : Query<MyType1, Expressions.UserDefinedTableTypes.dbo.MyType1, Orientations.UserDefinedTableTypes.dbo.MyType1, ColumnEnums.UserDefinedTableTypes.dbo.MyType1>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"MyType1", columns);
        }
    }
    public partial class ParentChildOrg : Query<ParentChildOrg, Expressions.UserDefinedTableTypes.dbo.ParentChildOrg, Orientations.UserDefinedTableTypes.dbo.ParentChildOrg, ColumnEnums.UserDefinedTableTypes.dbo.ParentChildOrg>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"ParentChildOrg", columns);
        }
    }
}