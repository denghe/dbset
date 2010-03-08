namespace SqlLib.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class SqlLogicalNode
    {
        public SqlLogicals Logical = SqlLogicals.And;
        public SqlLogicalNode First;
        public SqlLogicalNode Second;
        public SqlExpressionNode SqlExpression;
    }

    public partial class SqlExpressionNode
    {
        public SqlLogicalNode Parent;
        public string ColumnName;
        public SqlOperators Operate = SqlOperators.NotSet;
        public object Value;
    }

    /// <summary>
    /// 字段--值 SQL 直接运算符
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


    partial class SqlLogicalNode
    {
        public void CopyTo(SqlLogicalNode o)
        {
            o.First = this.First;
            o.Second = this.Second;
            o.SqlExpression = this.SqlExpression;
            o.Logical = this.Logical;
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

        public override string ToString()
        {
            if (this.SqlExpression == null)
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
            return this.SqlExpression.ToString();
        }

        public string ToString(string schema, string name)
        {
            if (this.SqlExpression == null)
            {
                if (this.Logical == SqlLogicals.Not)
                {
                    var firstQuote = this.First.Logical != SqlLogicals.Not;
                    var s1 = firstQuote ? " ( " : " ";
                    var s2 = firstQuote ? " )" : "";
                    return GetSqlOperater(this.Logical) + s1 + this.First.ToString(schema, name) + s2;
                }
                else
                {
                    var firstQuote = this.First.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var secondQuote = this.Second.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var s1 = firstQuote ? "( " : "";
                    var s2 = firstQuote ? " ) " : " ";
                    var s3 = secondQuote ? " ( " : " ";
                    var s4 = secondQuote ? " )" : "";
                    return s1 + this.First.ToString(schema, name) + s2 + GetSqlOperater(this.Logical) + s3 + this.Second.ToString(schema, name) + s4;
                }
            }
            return this.SqlExpression.ToSqlString(schema, name);
        }

    }

    public class SqlLogicalNode<T> : SqlLogicalNode where T : SqlLogicalNode, new()
    {
        public delegate T ExpHandler(T eh);
        public static T New(ExpHandler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public T And(T L) { return new T { First = this, Logical = SqlLogicals.And, Second = L }; }
        public T Or(T L) { return new T { First = this, Logical = SqlLogicals.Or, Second = L }; }
        public T Not() { return new T { First = this, Logical = SqlLogicals.Not }; }

        public void And(ExpHandler eh)
        {
            if (this.First == null && this.SqlExpression == null)
            {
                New(eh).CopyTo(this);
            }
            else
            {
                var child = new T();
                this.CopyTo(child);

                this.First = eh.Invoke(new T());
                this.Logical = SqlLogicals.And;
                this.Second = child;
                this.SqlExpression = null;
            }
        }
        public void Or(ExpHandler eh)
        {
            if (this.First == null && this.SqlExpression == null)
            {
                New(eh).CopyTo(this);
            }
            else
            {
                var child = new T();
                this.CopyTo(child);

                this.First = eh.Invoke(new T());
                this.Logical = SqlLogicals.Or;
                this.Second = child;
                this.SqlExpression = null;
            }
        }


        public static T operator &(SqlLogicalNode<T> a, SqlLogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.And, Second = b }; }
        public static T operator |(SqlLogicalNode<T> a, SqlLogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.Or, Second = b }; }

        public SqlExpressionNode_Nullable_Int32<T> New_SqlExpressionNode_Nullable_Int32(string column)
        {
            if (this.SqlExpression != null) throw new Exception("do not support column.operate(value).column.operate(value).....");
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Int32<T> { Parent = L, ColumnName = "id" };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Int32<T> New_SqlExpressionNode_Int32(string column)
        {
            if (this.SqlExpression != null) throw new Exception("do not support column.operate(value).column.operate(value).....");
            var L = new T();
            var e = new SqlExpressionNode_Int32<T> { Parent = L, ColumnName = "id" };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Boolean<T> New_SqlExpressionNode_Nullable_Boolean(string column)
        {
            if (this.SqlExpression != null) throw new Exception("do not support column.operate(value).column.operate(value).....");
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Boolean<T> { Parent = L, ColumnName = "id" };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Boolean<T> New_SqlExpressionNode_Boolean(string column)
        {
            if (this.SqlExpression != null) throw new Exception("do not support column.operate(value).column.operate(value).....");
            var L = new T();
            var e = new SqlExpressionNode_Boolean<T> { Parent = L, ColumnName = "id" };
            L.SqlExpression = e;
            return e;
        }



        /*
            Unknown,
            Boolean,
            Bytes,
            Int16,
            Int32,
            Int64,
            Decimal,
            DateTime,
            String
        */


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

        public override string ToString()
        {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null)
        {
            // todo: switch type
            string sn, so, sv;
            sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name + "]."))
                + "[" + this.ColumnName + "]";

            if (this.Operate == SqlOperators.Equal && (this.Value == null || this.Value == DBNull.Value))
            {
                so = "IS";
                sv = "NULL";
            }
            else if (this.Operate == SqlOperators.NotEqual && (this.Value == null || this.Value == DBNull.Value))
            {
                so = "IS NOT";
                sv = "NULL";
            }
            else
            {
                so = GetSqlOperater(this.Operate);
                sv = this.GetValueString();
            }
            return sn + " " + so + " " + sv;
        }

        protected virtual string GetValueString()
        {
            return Value.ToString();
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
    }

    public partial class SqlExpressionNode_Boolean<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            return (bool)this.Value ? "1" : "0";
        }

        public T Equal(Boolean value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        // todo: more operate methods

    }

    public partial class SqlExpressionNode_Nullable_Boolean<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            return ((bool?)this.Value).Value ? "1" : "0";
        }

        public T Equal(Boolean? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        // todo: more operate methods
    }

    // todo: more ExpressionNode_ DataTypes, ExpressionNode_Nullable_ DataTypes class


}
