using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.UserDefinedTableTypes.dbo
{

    public partial class udt_INT : Query<udt_INT, Expressions.UserDefinedTableTypes.dbo.udt_INT, Orientations.UserDefinedTableTypes.dbo.udt_INT, ColumnEnums.UserDefinedTableTypes.dbo.udt_INT>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"udt_INT", columns);
        }
    }
    public partial class udt_INT_STRING : Query<udt_INT_STRING, Expressions.UserDefinedTableTypes.dbo.udt_INT_STRING, Orientations.UserDefinedTableTypes.dbo.udt_INT_STRING, ColumnEnums.UserDefinedTableTypes.dbo.udt_INT_STRING>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"udt_INT_STRING", columns);
        }
    }
    public partial class udt_test1 : Query<udt_test1, Expressions.UserDefinedTableTypes.dbo.udt_test1, Orientations.UserDefinedTableTypes.dbo.udt_test1, ColumnEnums.UserDefinedTableTypes.dbo.udt_test1>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"udt_test1", columns);
        }
    }
}