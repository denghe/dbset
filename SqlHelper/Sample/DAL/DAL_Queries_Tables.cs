using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.Tables.dbo {

    public partial class Child : Query<Child, Expressions.Tables.dbo.Child, Orientations.Tables.dbo.Child, ColumnEnums.Tables.dbo.Child> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"Child", columns);
        }
    }
    public partial class ChildLog : Query<ChildLog, Expressions.Tables.dbo.ChildLog, Orientations.Tables.dbo.ChildLog, ColumnEnums.Tables.dbo.ChildLog> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"ChildLog", columns);
        }
    }
    public partial class DoublePK : Query<DoublePK, Expressions.Tables.dbo.DoublePK, Orientations.Tables.dbo.DoublePK, ColumnEnums.Tables.dbo.DoublePK> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"DoublePK", columns);
        }
    }
    public partial class Orders : Query<Orders, Expressions.Tables.dbo.Orders, Orientations.Tables.dbo.Orders, ColumnEnums.Tables.dbo.Orders> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"Orders", columns);
        }
    }
    public partial class t1 : Query<t1, Expressions.Tables.dbo.t1, Orientations.Tables.dbo.t1, ColumnEnums.Tables.dbo.t1> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"t1", columns);
        }
    }
    public partial class TA : Query<TA, Expressions.Tables.dbo.TA, Orientations.Tables.dbo.TA, ColumnEnums.Tables.dbo.TA> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"TA", columns);
        }
    }
    public partial class TB : Query<TB, Expressions.Tables.dbo.TB, Orientations.Tables.dbo.TB, ColumnEnums.Tables.dbo.TB> {
        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"TB", columns);
        }
    }
    public partial class Tree : Query<Tree, Expressions.Tables.dbo.Tree, Orientations.Tables.dbo.Tree, ColumnEnums.Tables.dbo.Tree> {

        public Tree() { }
        public Tree(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public Tree(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            return base.ToSqlString(schema ?? @"dbo", name ?? @"Tree", columns);
        }
    }
}