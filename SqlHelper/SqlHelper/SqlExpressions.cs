namespace SqlLib.Expressions {
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region base

    public partial class LogicalNode {
        public Logicals Logical = Logicals.And;
        public LogicalNode First;
        public LogicalNode Second;
        public ExpNode Expression;
    }

    public partial class ExpNode {
        public LogicalNode Parent;
        public string ColumnName;
        public Operators Operate = Operators.NotSet;
        public object Value;
        public object Value2;
    }

    /// <summary>
    /// 字段--值 SQL 直接运算符
    /// </summary>
    public enum Operators : int {
        NotSet = 0,

        Custom,

        Equal,
        NotEqual,

        LessEqual,
        GreaterEqual,

        LessThan,
        GreaterThan,

        Like,

        In,

        Between,
    }

    /// <summary>
    /// SQL 逻辑运算符
    /// </summary>
    public enum Logicals : int {
        NotSet = 0,

        And,
        Or,
        Not
    }

    #endregion

    #region inherit & partial

    partial class LogicalNode {
        public void CopyTo(LogicalNode o) {
            o.First = this.First;
            o.Second = this.Second;
            o.Expression = this.Expression;
            o.Logical = this.Logical;
        }

        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(Logicals op) {
            switch(op) {
                case Logicals.And: return "AND";
                case Logicals.Or: return "OR";
                case Logicals.Not: return "NOT";
            }
            return "";
        }

        public override string ToString() {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null) {
            schema = SqlUtils.EscapeSqlObjectName(schema);
            name = SqlUtils.EscapeSqlObjectName(name);
            if(this.Expression == null) {
                if(this.First == null) return "";
                if(this.Logical == Logicals.Not) {
                    var firstQuote = this.First.Logical != Logicals.Not;
                    var s1 = firstQuote ? " ( " : " ";
                    var s2 = firstQuote ? " )" : "";
                    return GetSqlOperater(this.Logical) + s1 + this.First.ToSqlString(schema, name) + s2;
                } else {
                    var firstQuote = this.First.Logical == Logicals.Or && this.Logical == Logicals.And;
                    var secondQuote = this.Second.Logical == Logicals.Or && this.Logical == Logicals.And;
                    var s1 = firstQuote ? "( " : "";
                    var s2 = firstQuote ? " ) " : " ";
                    var s3 = secondQuote ? " ( " : " ";
                    var s4 = secondQuote ? " )" : "";
                    return s1 + this.First.ToSqlString(schema, name) + s2 + GetSqlOperater(this.Logical) + s3 + this.Second.ToSqlString(schema, name) + s4;
                }
            }
            return this.Expression.ToSqlString(schema, name);
        }

    }

    public class LogicalNode<T> : LogicalNode where T : LogicalNode, new() {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public T And(T L) { return new T { First = this, Logical = Logicals.And, Second = L }; }
        public T Or(T L) { return new T { First = this, Logical = Logicals.Or, Second = L }; }
        public T Not() { return new T { First = this, Logical = Logicals.Not }; }

        public void And(Handler eh) {
            if(this.First == null && this.Expression == null) {
                New(eh).CopyTo(this);
            } else {
                var child = new T();
                this.CopyTo(child);

                this.First = eh.Invoke(new T());
                this.Logical = Logicals.And;
                this.Second = child;
                this.Expression = null;
            }
        }
        public void Or(Handler eh) {
            if(this.First == null && this.Expression == null) {
                New(eh).CopyTo(this);
            } else {
                var child = new T();
                this.CopyTo(child);

                this.First = eh.Invoke(new T());
                this.Logical = Logicals.Or;
                this.Second = child;
                this.Expression = null;
            }
        }

        public static T operator &(LogicalNode<T> a, LogicalNode<T> b) { return new T { First = a, Logical = Logicals.And, Second = b }; }
        public static T operator |(LogicalNode<T> a, LogicalNode<T> b) { return new T { First = a, Logical = Logicals.Or, Second = b }; }

        protected void Check() {
            if(this.Expression != null)
                throw new Exception("do not support column.operate(value).column.operate(value).....");
        }


        protected ExpNode_Nullable_Boolean<T> New_Nullable_Boolean(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Boolean<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Boolean<T> New_Boolean(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Boolean<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Bytes<T> New_Nullable_Bytes(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Bytes<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Bytes<T> New_Bytes(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Bytes<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Int16<T> New_Nullable_Int16(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int16<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Int16<T> New_Int16(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Int16<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Int32<T> New_Nullable_Int32(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int32<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Int32<T> New_Int32(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Int32<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Int64<T> New_Nullable_Int64(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int64<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Int64<T> New_Int64(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Int64<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Decimal<T> New_Nullable_Decimal(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Decimal<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Decimal<T> New_Decimal(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Decimal<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_DateTime<T> New_Nullable_DateTime(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_DateTime<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_DateTime<T> New_DateTime(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_DateTime<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_String<T> New_Nullable_String(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_String<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_String<T> New_String(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_String<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

        protected ExpNode_Nullable_Guid<T> New_Nullable_Guid(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Guid<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }
        protected ExpNode_Guid<T> New_Guid(string column) {
            Check();
            var L = new T();
            var e = new ExpNode_Guid<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

    }

    partial class ExpNode {
        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(Operators op) {
            switch(op) {
                case Operators.Custom: return "{0} {1}";
                case Operators.Equal: return "{0} = {1}";
                case Operators.LessThan: return "{0} < {1}";
                case Operators.LessEqual: return "{0} <= {1}";
                case Operators.GreaterThan: return "{0} > {1}";
                case Operators.GreaterEqual: return "{0} >= {1}";
                case Operators.NotEqual: return "{0} <> {1}";
                case Operators.Like: return "{0} LIKE {1}";
                case Operators.In: return "{0} IN ({1})";
                case Operators.Between: return "{0} BETWEEN {1} AND {2}";
            }
            return "";
        }

        public override string ToString() {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null) {
            string sn, so;
            sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema.Replace("]", "]]") + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name.Replace("]", "]]") + "]."))
                + "[" + this.ColumnName.Replace("]", "]]") + "]";

            if(this.Operate == Operators.Equal && (this.Value == null || this.Value == DBNull.Value))
                so = "{0} IS {1}";
            else if(this.Operate == Operators.NotEqual && (this.Value == null || this.Value == DBNull.Value))
                so = "{0} IS NOT {1}";
            else so = GetSqlOperater(this.Operate);

            if(this.Operate == Operators.Between)
                return string.Format(so, sn, GetValueString(), GetValue2String());
            return string.Format(so, sn, GetValueString());
        }

        protected virtual string GetValueString() {
            return Value.ToString();
        }

        protected virtual string GetValue2String() {
            return Value2.ToString();
        }
    }

    public partial class ExpNode_Nullable<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return Value.ToString();
        }

        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return Value2.ToString();
        }

        public T IsNull() {
            this.Operate = Operators.Equal;
            this.Value = null;
            return (T)this.Parent;
        }
        public T IsNotNull() {
            this.Operate = Operators.NotEqual;
            this.Value = null;
            return (T)this.Parent;
        }
    }

    #endregion

    #region inherit (data types)

    #region bool

    public partial class ExpNode_Boolean<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            return (bool)this.Value ? "1" : "0";
        }

        protected override string GetValue2String() {
            return (bool)this.Value2 ? "1" : "0";
        }

        public T Equal(Boolean value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Boolean value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Boolean<T> a, Boolean b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Boolean<T> a, Boolean b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Boolean<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return ((bool?)this.Value).Value ? "1" : "0";
        }
        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return ((bool?)this.Value2).Value ? "1" : "0";
        }

        public T Equal(Boolean? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Boolean? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Boolean<T> a, Boolean? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Boolean<T> a, Boolean? b) { return a.NotEqual(b); }

    }

    #endregion

    #region bytes

    public partial class ExpNode_Bytes<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            return SqlUtils.ToHexString((byte[])this.Value);
        }
        protected override string GetValue2String() {
            return SqlUtils.ToHexString((byte[])this.Value2);
        }

        public T Equal(byte[] value) {
            if(value == null) value = new byte[] { };
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(byte[] value) {
            if(value == null) value = new byte[] { };
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Bytes<T> a, byte[] b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Bytes<T> a, byte[] b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Bytes<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return SqlUtils.ToHexString((byte[])this.Value);
        }
        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return SqlUtils.ToHexString((byte[])this.Value2);
        }

        public T Equal(Byte[] value) {
            if(value == null) value = new byte[] { };
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Byte[] value) {
            if(value == null) value = new byte[] { };
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Bytes<T> a, byte[] b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Bytes<T> a, byte[] b) { return a.NotEqual(b); }
    }

    #endregion

    #region int16

    public partial class ExpNode_Int16<T> : ExpNode where T : LogicalNode, new() {
        public T Equal(Int16 value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16 value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16 value) {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16 value) {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16 value) {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16 value) {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int16 value, Int16 value2) {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Int16<T> a, Int16 b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Int16<T> a, Int16 b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Int16<T> a, Int16 b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Int16<T> a, Int16 b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Int16<T> a, Int16 b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Int16<T> a, Int16 b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Int16<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        public T Equal(Int16? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int16? value, Int16? value2) {
            if(value == null) value = 0;
            if(value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Int16<T> a, Int16? b) { return a.NotEqual(b); }
    }

    #endregion

    #region int32

    public partial class ExpNode_Int32<T> : ExpNode where T : LogicalNode, new() {
        public T Equal(Int32 value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int32 value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32 value) {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32 value) {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32 value) {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32 value) {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int32 value, Int32 value2) {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Int32<T> a, Int32 b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Int32<T> a, Int32 b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Int32<T> a, Int32 b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Int32<T> a, Int32 b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Int32<T> a, Int32 b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Int32<T> a, Int32 b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Int32<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        public T Equal(Int32? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int32? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int32? value, Int32? value2) {
            if(value == null) value = 0;
            if(value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Int32<T> a, Int32? b) { return a.NotEqual(b); }
    }

    #endregion

    #region int64

    public partial class ExpNode_Int64<T> : ExpNode where T : LogicalNode, new() {
        public T Equal(Int64 value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64 value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64 value) {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64 value) {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64 value) {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64 value) {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int64 value, Int64 value2) {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Int64<T> a, Int64 b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Int64<T> a, Int64 b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Int64<T> a, Int64 b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Int64<T> a, Int64 b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Int64<T> a, Int64 b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Int64<T> a, Int64 b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Int64<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        public T Equal(Int64? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int64? value, Int64? value2) {
            if(value == null) value = 0;
            if(value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Int64<T> a, Int64? b) { return a.NotEqual(b); }
    }

    #endregion

    #region decimal

    public partial class ExpNode_Decimal<T> : ExpNode where T : LogicalNode, new() {
        public T Equal(Decimal value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal value) {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal value) {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal value) {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal value) {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Decimal value, Decimal value2) {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Decimal<T> a, Decimal b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Decimal<T> a, Decimal b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Decimal<T> a, Decimal b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Decimal<T> a, Decimal b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Decimal<T> a, Decimal b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Decimal<T> a, Decimal b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Decimal<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        public T Equal(Decimal? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal? value) {
            if(value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal? value) {
            if(value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Decimal? value, Decimal? value2) {
            if(value == null) value = 0;
            if(value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Decimal<T> a, Decimal? b) { return a.NotEqual(b); }
    }

    #endregion

    #region datetime

    public partial class ExpNode_DateTime<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            return "'" + ((DateTime)this.Value).ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        protected override string GetValue2String() {
            return "'" + ((DateTime)this.Value2).ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        public T Equal(DateTime value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime value) {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime value) {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime value) {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime value) {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime value, DateTime value2) {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_DateTime<T> a, DateTime b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_DateTime<T> a, DateTime b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_DateTime<T> a, DateTime b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_DateTime<T> a, DateTime b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_DateTime<T> a, DateTime b) { return a.Equal(b); }
        public static T operator !=(ExpNode_DateTime<T> a, DateTime b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_DateTime<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value).Value.ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value2).Value.ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        public T Equal(DateTime? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime? value) {
            if(value == null) value = new DateTime();
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime? value) {
            if(value == null) value = new DateTime();
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime? value) {
            if(value == null) value = new DateTime();
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime? value) {
            if(value == null) value = new DateTime();
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime? value, DateTime? value2) {
            if(value == null) value = new DateTime();
            if(value2 == null) value2 = new DateTime();
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_DateTime<T> a, DateTime? b) { return a.NotEqual(b); }
    }

    #endregion

    #region string

    public partial class ExpNode_String<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            return "'" + ((string)this.Value).Replace("'", "''") + "'";
        }

        protected override string GetValue2String() {
            return "'" + ((string)this.Value2).Replace("'", "''") + "'";
        }

        public T Equal(String value) {
            if(value == null) value = "";
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value) {
            if(value == null) value = "";
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value) {
            if(value == null) value = "";
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value) {
            if(value == null) value = "";
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value) {
            if(value == null) value = "";
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value) {
            if(value == null) value = "";
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Like(String value) {
            if(value == null) value = "";
            this.Operate = Operators.Like;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_String<T> a, string b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_String<T> a, string b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_String<T> a, string b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_String<T> a, string b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_String<T> a, string b) { return a.Equal(b); }
        public static T operator !=(ExpNode_String<T> a, string b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_String<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((string)this.Value).Replace("'", "''") + "'";
        }

        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((string)this.Value2).Replace("'", "''") + "'";
        }

        public T Equal(String value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value) {
            if(value == null) value = "";
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value) {
            if(value == null) value = "";
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value) {
            if(value == null) value = "";
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value) {
            if(value == null) value = "";
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Like(String value) {
            if(value == null) value = "";
            this.Operate = Operators.Like;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_String<T> a, string b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_String<T> a, string b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_String<T> a, string b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_String<T> a, string b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_String<T> a, string b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_String<T> a, string b) { return a.NotEqual(b); }
    }

    #endregion

    #region guid

    public partial class ExpNode_Guid<T> : ExpNode where T : LogicalNode, new() {
        protected override string GetValueString() {
            return "'" + ((Guid)this.Value).ToString() + "'";
        }

        protected override string GetValue2String() {
            return "'" + ((Guid)this.Value2).ToString() + "'";
        }

        public T Equal(Guid value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Guid value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Guid<T> a, Guid b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Guid<T> a, Guid b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Guid<T> : ExpNode_Nullable<T> where T : LogicalNode, new() {
        protected override string GetValueString() {
            if(this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((Guid?)this.Value).ToString() + "'";
        }

        protected override string GetValue2String() {
            if(this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((Guid?)this.Value2).ToString() + "'";
        }


        public T Equal(Guid? value) {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Guid? value) {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Guid<T> a, Guid? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Guid<T> a, Guid? b) { return a.NotEqual(b); }
    }

    #endregion

    #endregion
}
