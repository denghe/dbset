﻿namespace SqlLib.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region base

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

        In,
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

    #endregion

    #region inherit & partial

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
            return this.ToSqlString();
        }

        public string ToSqlString(string schema = null, string name = null)
        {
            if (this.SqlExpression == null)
            {
                if (this.Logical == SqlLogicals.Not)
                {
                    var firstQuote = this.First.Logical != SqlLogicals.Not;
                    var s1 = firstQuote ? " ( " : " ";
                    var s2 = firstQuote ? " )" : "";
                    return GetSqlOperater(this.Logical) + s1 + this.First.ToSqlString(schema, name) + s2;
                }
                else
                {
                    var firstQuote = this.First.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var secondQuote = this.Second.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                    var s1 = firstQuote ? "( " : "";
                    var s2 = firstQuote ? " ) " : " ";
                    var s3 = secondQuote ? " ( " : " ";
                    var s4 = secondQuote ? " )" : "";
                    return s1 + this.First.ToSqlString(schema, name) + s2 + GetSqlOperater(this.Logical) + s3 + this.Second.ToSqlString(schema, name) + s4;
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

        protected void CheckExpression()
        {
            if (this.SqlExpression != null)
                throw new Exception("do not support column.operate(value).column.operate(value).....");
        }


        public SqlExpressionNode_Nullable_Boolean<T> New_SqlExpressionNode_Nullable_Boolean(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Boolean<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Boolean<T> New_SqlExpressionNode_Boolean(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Boolean<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Bytes<T> New_SqlExpressionNode_Nullable_Bytes(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Bytes<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Bytes<T> New_SqlExpressionNode_Bytes(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Bytes<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Int16<T> New_SqlExpressionNode_Nullable_Int16(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Int16<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Int16<T> New_SqlExpressionNode_Int16(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Int16<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Int32<T> New_SqlExpressionNode_Nullable_Int32(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Int32<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Int32<T> New_SqlExpressionNode_Int32(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Int32<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Int64<T> New_SqlExpressionNode_Nullable_Int64(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Int64<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Int64<T> New_SqlExpressionNode_Int64(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Int64<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_Decimal<T> New_SqlExpressionNode_Nullable_Decimal(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_Decimal<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_Decimal<T> New_SqlExpressionNode_Decimal(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Decimal<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_DateTime<T> New_SqlExpressionNode_Nullable_DateTime(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_DateTime<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_DateTime<T> New_SqlExpressionNode_DateTime(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_DateTime<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }

        public SqlExpressionNode_Nullable_String<T> New_SqlExpressionNode_Nullable_String(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_Nullable_String<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
        public SqlExpressionNode_String<T> New_SqlExpressionNode_String(string column)
        {
            CheckExpression();
            var L = new T();
            var e = new SqlExpressionNode_String<T> { Parent = L, ColumnName = column };
            L.SqlExpression = e;
            return e;
        }
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
                case SqlOperators.In: return "IN";
            }
            return "";
        }

        public override string ToString()
        {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null)
        {
            string sn, so, sv;
            sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name + "]."))
                + "[" + this.ColumnName + "]";

            if (this.Operate == SqlOperators.Equal && (this.Value == null || this.Value == DBNull.Value))
                so = "IS";
            else if (this.Operate == SqlOperators.NotEqual && (this.Value == null || this.Value == DBNull.Value))
                so = "IS NOT";
            else
                so = GetSqlOperater(this.Operate);
            sv = this.GetValueString();
            return sn + " " + so + " " + sv;
        }

        protected virtual string GetValueString()
        {
            return Value.ToString();
        }
    }

    public partial class SqlExpressionNode_Nullable<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return base.GetValueString();
        }

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

    #endregion

    #region inherit (data types)

    #region bool

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

        public T NotEqual(Boolean value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }
        // todo: more operate methods

    }

    public partial class SqlExpressionNode_Nullable_Boolean<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return ((bool?)this.Value).Value ? "1" : "0";
        }

        public T Equal(Boolean? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Boolean? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }
        // todo: more operate methods
    }

    #endregion

    #region bytes

    public partial class SqlExpressionNode_Bytes<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            return SqlUtils.ToHexString((byte[])this.Value);
        }

        public T Equal(byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_Bytes<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return SqlUtils.ToHexString((byte[])this.Value);
        }

        public T Equal(Byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region int16

    public partial class SqlExpressionNode_Int16<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(Int16 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16 value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16 value)
        {
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16 value)
        {
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16 value)
        {
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16 value)
        {
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_Int16<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        public T Equal(Int16? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region int32

    public partial class SqlExpressionNode_Int32<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(Int32 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int32 value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32 value)
        {
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32 value)
        {
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32 value)
        {
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32 value)
        {
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
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

        public T NotEqual(Int32? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region int64

    public partial class SqlExpressionNode_Int64<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(Int64 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64 value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64 value)
        {
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64 value)
        {
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64 value)
        {
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64 value)
        {
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_Int64<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        public T Equal(Int64? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region decimal

    public partial class SqlExpressionNode_Decimal<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(Decimal value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal value)
        {
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal value)
        {
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal value)
        {
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal value)
        {
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_Decimal<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        public T Equal(Decimal? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region datetime

    public partial class SqlExpressionNode_DateTime<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            return ((DateTime)this.Value).ToString("yyyy-MM-d HH:mm:ss.ffffzzz");
        }

        public T Equal(DateTime value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime value)
        {
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime value)
        {
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime value)
        {
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime value)
        {
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_DateTime<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return ((DateTime?)this.Value).Value.ToString("yyyy-MM-d HH:mm:ss.ffffzzz");
        }

        public T Equal(DateTime? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime? value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region string

    public partial class SqlExpressionNode_String<T> : SqlExpressionNode where T : SqlLogicalNode, new()
    {
        public T Equal(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class SqlExpressionNode_Nullable_String<T> : SqlExpressionNode_Nullable<T> where T : SqlLogicalNode, new()
    {
        public T Equal(String value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value)
        {
            this.Operate = SqlOperators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = SqlOperators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #endregion
}
