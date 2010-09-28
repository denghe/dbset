using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.UserDefinedTableTypes.表类型
{

    public partial class G_INT : Query<G_INT, Expressions.UserDefinedTableTypes.表类型.G_INT, Orientations.UserDefinedTableTypes.表类型.G_INT, ColumnEnums.UserDefinedTableTypes.表类型.G_INT>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_INT", columns);
        }
    }
    public partial class G_INT_INT : Query<G_INT_INT, Expressions.UserDefinedTableTypes.表类型.G_INT_INT, Orientations.UserDefinedTableTypes.表类型.G_INT_INT, ColumnEnums.UserDefinedTableTypes.表类型.G_INT_INT>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_INT_INT", columns);
        }
    }
    public partial class G_INT_INT_BIT : Query<G_INT_INT_BIT, Expressions.UserDefinedTableTypes.表类型.G_INT_INT_BIT, Orientations.UserDefinedTableTypes.表类型.G_INT_INT_BIT, ColumnEnums.UserDefinedTableTypes.表类型.G_INT_INT_BIT>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_INT_INT_BIT", columns);
        }
    }
    public partial class G_INT_STRING : Query<G_INT_STRING, Expressions.UserDefinedTableTypes.表类型.G_INT_STRING, Orientations.UserDefinedTableTypes.表类型.G_INT_STRING, ColumnEnums.UserDefinedTableTypes.表类型.G_INT_STRING>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_INT_STRING", columns);
        }
    }
    public partial class G_INT_STRING_STRING : Query<G_INT_STRING_STRING, Expressions.UserDefinedTableTypes.表类型.G_INT_STRING_STRING, Orientations.UserDefinedTableTypes.表类型.G_INT_STRING_STRING, ColumnEnums.UserDefinedTableTypes.表类型.G_INT_STRING_STRING>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_INT_STRING_STRING", columns);
        }
    }
    public partial class G_STRING : Query<G_STRING, Expressions.UserDefinedTableTypes.表类型.G_STRING, Orientations.UserDefinedTableTypes.表类型.G_STRING, ColumnEnums.UserDefinedTableTypes.表类型.G_STRING>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_STRING", columns);
        }
    }
    public partial class G_STRING_DATETIME : Query<G_STRING_DATETIME, Expressions.UserDefinedTableTypes.表类型.G_STRING_DATETIME, Orientations.UserDefinedTableTypes.表类型.G_STRING_DATETIME, ColumnEnums.UserDefinedTableTypes.表类型.G_STRING_DATETIME>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"表类型", name ?? @"G_STRING_DATETIME", columns);
        }
    }
}