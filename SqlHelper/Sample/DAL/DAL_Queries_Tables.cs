using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.Tables.dbo
{

    public partial class Formula_890 : Query<Formula_890, Expressions.Tables.dbo.Formula_890, Orientations.Tables.dbo.Formula_890, ColumnEnums.Tables.dbo.Formula_890>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"Formula_890", columns);
        }
    }
    public partial class FS : Query<FS, Expressions.Tables.dbo.FS, Orientations.Tables.dbo.FS, ColumnEnums.Tables.dbo.FS>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"FS", columns);
        }
    }
    public partial class ParentChildOrg : Query<ParentChildOrg, Expressions.Tables.dbo.ParentChildOrg, Orientations.Tables.dbo.ParentChildOrg, ColumnEnums.Tables.dbo.ParentChildOrg>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"ParentChildOrg", columns);
        }
    }
    public partial class t : Query<t, Expressions.Tables.dbo.t, Orientations.Tables.dbo.t, ColumnEnums.Tables.dbo.t>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"t", columns);
        }
    }
    public partial class t1 : Query<t1, Expressions.Tables.dbo.t1, Orientations.Tables.dbo.t1, ColumnEnums.Tables.dbo.t1>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"t1", columns);
        }
    }
    public partial class t2 : Query<t2, Expressions.Tables.dbo.t2, Orientations.Tables.dbo.t2, ColumnEnums.Tables.dbo.t2>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"t2", columns);
        }
    }
    public partial class t3 : Query<t3, Expressions.Tables.dbo.t3, Orientations.Tables.dbo.t3, ColumnEnums.Tables.dbo.t3>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"t3", columns);
        }
    }
    public partial class tree : Query<tree, Expressions.Tables.dbo.tree, Orientations.Tables.dbo.tree, ColumnEnums.Tables.dbo.tree>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"tree", columns);
        }
    }
}
namespace DAL.Queries.Tables.MySchema
{

    public partial class FS : Query<FS, Expressions.Tables.MySchema.FS, Orientations.Tables.MySchema.FS, ColumnEnums.Tables.MySchema.FS>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"MySchema", name ?? @"FS", columns);
        }
    }
}
namespace DAL.Queries.Tables.Schema1
{

    public partial class T1 : Query<T1, Expressions.Tables.Schema1.T1, Orientations.Tables.Schema1.T1, ColumnEnums.Tables.Schema1.T1>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"Schema1", name ?? @"T1", columns);
        }
    }
}