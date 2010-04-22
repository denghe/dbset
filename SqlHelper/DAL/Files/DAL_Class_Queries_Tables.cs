using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.Tables.产品
{

    public partial class 产品 : Query<产品, Expressions.Tables.产品.产品, Orientations.Tables.产品.产品, ColumnEnums.Tables.产品.产品>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"产品", name ?? @"产品", columns);
        }
    }
}
namespace DAL.Queries.Tables.雇员
{

    public partial class 雇员 : Query<雇员, Expressions.Tables.雇员.雇员, Orientations.Tables.雇员.雇员, ColumnEnums.Tables.雇员.雇员>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"雇员", name ?? @"雇员", columns);
        }
    }
}
namespace DAL.Queries.Tables.客户
{

    public partial class 订单 : Query<订单, Expressions.Tables.客户.订单, Orientations.Tables.客户.订单, ColumnEnums.Tables.客户.订单>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"客户", name ?? @"订单", columns);
        }
    }
    public partial class 订单明细 : Query<订单明细, Expressions.Tables.客户.订单明细, Orientations.Tables.客户.订单明细, ColumnEnums.Tables.客户.订单明细>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"客户", name ?? @"订单明细", columns);
        }
    }
    public partial class 客户 : Query<客户, Expressions.Tables.客户.客户, Orientations.Tables.客户.客户, ColumnEnums.Tables.客户.客户>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"客户", name ?? @"客户", columns);
        }
    }
}
namespace DAL.Queries.Tables.系统
{

    public partial class 管理员 : Query<管理员, Expressions.Tables.系统.管理员, Orientations.Tables.系统.管理员, ColumnEnums.Tables.系统.管理员>
    {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null)
        {
            return base.ToSqlString(schema ?? @"系统", name ?? @"管理员", columns);
        }
    }
}