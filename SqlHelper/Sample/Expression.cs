namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var exp = DAL.Expressions.dbo.t2.New(o =>
                (o.id.Equal(1) | o.id.Equal(2)) & (o.id.Equal(null) | o.id.IsNull()).Not()
            );
            var rows = DAL.Tables.dbo.t2.Select(exp);

            Console.WriteLine(exp);

            Console.ReadLine();
        }
    }
}


namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class t2
    {
        // todo: columns properties here

        public static List<t2> Select(Expressions.dbo.t2.ExpHandler eh)
        {
            return Select(eh.Invoke(new Expressions.dbo.t2()));
        }
        public static List<t2> Select(Expressions.dbo.t2 exp)
        {
            var where = exp.ToString();
            var tsql = "SELECT * FROM t2" + (where.Length > 0 ? " WHERE " : "") + where;

            // todo: get data & return
            return new List<t2>();
        }
    }
}



namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class t2 : SqlLogicalNode<t2>
    {
        public SqlExpressionNode_Nullable_Int32<t2> id { get { return this.New_ExpressionNode_Nullable_Int32("id"); } }

        // todo: more columns here
    }
}








namespace DAL.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class SqlLogicalNode
    {
        public SqlLogicals Logical = SqlLogicals.And;
        public SqlLogicalNode First;
        public SqlLogicalNode Second;
        public SqlExpressionNode Expression;
    }

    public partial class SqlExpressionNode
    {
        public SqlLogicalNode Parent;
        public string Column;
        public SqlOperators Operate = SqlOperators.NotSet;
        public object Value;
    }



    partial class SqlLogicalNode
    {
        public override string ToString()
        {
            if (this.Expression == null)
            {
                if (this.Logical == SqlLogicals.Not)
                {
                    var firstQuote = this.First.Logical != SqlLogicals.Not;
                    var s1 = firstQuote ? " ( " : " ";
                    var s2 = firstQuote ? " )" : "";
                    return GetSqlOperater(this.Logical) + s1 + this.First.ToString() + s2;
                }
                else
                {
                    var firstQuote = this.First.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var secondQuote = this.Second.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var s1 = firstQuote ? "( " : "";
                    var s2 = firstQuote ? " ) " : " ";
                    var s3 = secondQuote ? " ( " : " ";
                    var s4 = secondQuote ? " )" : "";
                    return s1 + this.First.ToString() + s2 + GetSqlOperater(this.Logical) + s3 + this.Second.ToString() + s4;
                }
            }
            return this.Expression.ToString();
        }

        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(SqlLogicals op)
        {
            switch (op)
            {
                case SqlLogicals.And: return "AND";
                case SqlLogicals.Or: return "OR";
                case SqlLogicals.Not: return "NOT";
            }
            return "";
        }
    }

    public class SqlLogicalNode<T> : SqlLogicalNode where T : SqlLogicalNode, new()
    {
        public delegate T ExpHandler(T eh);
        public static T New(ExpHandler eh) { return eh.Invoke(new T()); }

        public T And(T L) { return new T { First = this, Logical = SqlLogicals.And, Second = L }; }
        public T Or(T L) { return new T { First = this, Logical = SqlLogicals.Or, Second = L }; }
        public T Not() { return new T { First = this, Logical = SqlLogicals.Not }; }

        public static T operator &(SqlLogicalNode<T> a, SqlLogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.And, Second = b }; }
        public static T operator |(SqlLogicalNode<T> a, SqlLogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.Or, Second = b }; }

        public SqlExpressionNode_Nullable_Int32<T> New_ExpressionNode_Nullable_Int32(string column)
        {
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Int32<T> { Parent = L, Column = "id" };
            L.Expression = e;
            return e;
        }
        public SqlExpressionNode_Int32<T> New_ExpressionNode_Int32(string column)
        {
            var L = new T();
            var e = new SqlExpressionNode_Int32<T> { Parent = L, Column = "id" };
            L.Expression = e;
            return e;
        }

        // todo: more new expression
    }

    partial class SqlExpressionNode
    {
        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(SqlOperators op)
        {
            switch (op)
            {
                case SqlOperators.Custom: return "";
                case SqlOperators.Equal: return "=";
                case SqlOperators.LessThan: return "<";
                case SqlOperators.LessEqual: return "<=";
                case SqlOperators.GreaterThan: return ">";
                case SqlOperators.GreaterEqual: return ">=";
                case SqlOperators.NotEqual: return "<>";
                case SqlOperators.Like:
                case SqlOperators.CustomLike: return "LIKE";
                case SqlOperators.NotLike:
                case SqlOperators.CustomNotLike: return "NOT LIKE";
                case SqlOperators.In: return "IN";
                case SqlOperators.NotIn: return "NOT IN";
            }
            return "";
        }
    }

    public partial class SqlExpressionNode_Nullable<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T IsNull()
        {
            this.Operate = SqlOperators.Equal;
            this.Value = null;
            return (T)this.Parent;
        }
        public T IsNotNull()
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = null;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Int32<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(Int32 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        // todo: more operate methods

        public override string ToString()
        {
            return this.Column + " " + GetSqlOperater(this.Operate) + " " + Value.ToString();
        }
    }

    public partial class SqlExpressionNode_Nullable_Int32<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        public T Equal(Int32? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        // todo: more operate methods


        public override string ToString()
        {
            if (this.Operate == SqlOperators.Equal && (this.Value == null || this.Value == DBNull.Value))
                return this.Column + " IS NULL";
            else if (this.Operate == SqlOperators.NotEqual && (this.Value == null || this.Value == DBNull.Value))
                return this.Column + " IS NOT NULL";
            return this.Column + " " + GetSqlOperater(this.Operate) + " " + (Value == null ? "NULL" : Value.ToString());
        }
    }

    // todo: more ExpressionNode_ DataTypes, ExpressionNode_Nullable_ DataTypes class



    /// <summary>
    /// 字段--值 SQL 运算符
    /// </summary>
    public enum SqlOperators : int
    {
        NotSet = 0,

        Custom,

        Equal,
        NotEqual,

        LessEqual,
        GreaterEqual,

        LessThan,
        GreaterThan,

        Like,
        CustomLike,

        NotLike,
        CustomNotLike,

        In,
        NotIn
    }

    /// <summary>
    /// SQL 逻辑运算符
    /// </summary>
    public enum SqlLogicals : int
    {
        NotSet = 0,

        And,
        Or,
        Not
    }
}
