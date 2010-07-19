namespace SqlLib.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    #region base

    public partial class LogicalNode
    {
        public Logicals Logical__ = Logicals.And;
        public LogicalNode First__;
        public LogicalNode Second__;
        public ExpNode Exp__;
    }

    public partial class ExpNode
    {
        public LogicalNode Parent;
        public string ColumnName;
        public Operators Operate = Operators.NotSet;
        public object Value;
        public object Value2;
    }

    /// <summary>
    /// 字段--值 SQL 直接运算符
    /// </summary>
    public enum Operators : int
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

        In,

        Between,
    }

    /// <summary>
    /// SQL 逻辑运算符
    /// </summary>
    public enum Logicals : int
    {
        NotSet = 0,

        And,
        Or,
        Not
    }

    #endregion

    #region inherit & partial

    partial class LogicalNode
    {
        public void CopyTo(LogicalNode o)
        {
            o.First__ = this.First__;
            o.Second__ = this.Second__;
            o.Exp__ = this.Exp__;
            o.Logical__ = this.Logical__;
        }

        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(Logicals op)
        {
            switch (op)
            {
                case Logicals.And: return "AND";
                case Logicals.Or: return "OR";
                case Logicals.Not: return "NOT";
            }
            return "";
        }

        public override string ToString()
        {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null)
        {
            schema = SqlUtils.EscapeSqlObjectName(schema);
            name = SqlUtils.EscapeSqlObjectName(name);
            if (this.Exp__ == null)
            {
                if (this.First__ == null) return "";
                if (this.Logical__ == Logicals.Not)
                {
                    var firstQuote = this.First__.Logical__ != Logicals.Not;
                    var s1 = firstQuote ? " ( " : " ";
                    var s2 = firstQuote ? " )" : "";
                    return GetSqlOperater(this.Logical__) + s1 + this.First__.ToSqlString(schema, name) + s2;
                }
                else
                {
                    var firstQuote = this.First__.Logical__ == Logicals.Or && this.Logical__ == Logicals.And;
                    var secondQuote = this.Second__.Logical__ == Logicals.Or && this.Logical__ == Logicals.And;
                    var s1 = firstQuote ? "( " : "";
                    var s2 = firstQuote ? " ) " : " ";
                    var s3 = secondQuote ? " ( " : " ";
                    var s4 = secondQuote ? " )" : "";
                    return s1 + this.First__.ToSqlString(schema, name) + s2 + GetSqlOperater(this.Logical__) + s3 + this.Second__.ToSqlString(schema, name) + s4;
                }
            }
            return this.Exp__.ToSqlString(schema, name);
        }


        public virtual byte[] GetBytes()
        {
            var buff = new List<byte[]>();
            buff.Add(new byte[] { (byte)(int)this.Logical__ });
            if (this.First__ == null) buff.Add(new byte[] { 0 });
            else
            {
                buff.Add(new byte[] { 1 });
                buff.Add(this.First__.GetBytes());
            }
            if (this.Second__ == null) buff.Add(new byte[] { 0 });
            else
            {
                buff.Add(new byte[] { 1 });
                buff.Add(this.Second__.GetBytes());
            }
            if (this.Exp__ == null) buff.Add(new byte[] { 0 });
            else
            {
                buff.Add(new byte[] { 1 });
                buff.Add(new byte[] { this.Exp__.TypeNumber__ });
                buff.Add(this.Exp__.GetBytes());
            }
            return buff.Combine();
        }

        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Logical__ = (Logicals)(int)buffer.ToByte(ref startIndex);
            if (buffer.ToByte(ref startIndex) == 0)
            {
                this.First__ = null;
            }
            else
            {
                this.First__ = new LogicalNode();
                this.First__.Fill(buffer, ref startIndex);
            }
            if (buffer.ToByte(ref startIndex) == 0)
            {
                this.Second__ = null;
            }
            else
            {
                this.Second__ = new LogicalNode();
                this.Second__.Fill(buffer, ref startIndex);
            }
            if (buffer.ToByte(ref startIndex) == 0)
            {
                this.Exp__ = null;
            }
            else
            {
                var typeNumber = (int)buffer.ToByte(ref startIndex);
                switch (typeNumber)
                {
                    case 1: this.Exp__ = new ExpNode_Boolean<LogicalNode>(); break;
                    case 2: this.Exp__ = new ExpNode_Nullable_Boolean<LogicalNode>(); break;
                    case 3: this.Exp__ = new ExpNode_Byte<LogicalNode>(); break;
                    case 4: this.Exp__ = new ExpNode_Nullable_Byte<LogicalNode>(); break;
                    case 5: this.Exp__ = new ExpNode_Bytes<LogicalNode>(); break;
                    case 6: this.Exp__ = new ExpNode_Nullable_Bytes<LogicalNode>(); break;
                    case 7: this.Exp__ = new ExpNode_Decimal<LogicalNode>(); break;
                    case 8: this.Exp__ = new ExpNode_Nullable_Decimal<LogicalNode>(); break;
                    case 9: this.Exp__ = new ExpNode_DateTime<LogicalNode>(); break;
                    case 10: this.Exp__ = new ExpNode_Nullable_DateTime<LogicalNode>(); break;
                    case 11: this.Exp__ = new ExpNode_Double<LogicalNode>(); break;
                    case 12: this.Exp__ = new ExpNode_Nullable_Double<LogicalNode>(); break;
                    case 13: this.Exp__ = new ExpNode_Float<LogicalNode>(); break;
                    case 14: this.Exp__ = new ExpNode_Nullable_Float<LogicalNode>(); break;
                    case 15: this.Exp__ = new ExpNode_Guid<LogicalNode>(); break;
                    case 16: this.Exp__ = new ExpNode_Nullable_Guid<LogicalNode>(); break;
                    case 17: this.Exp__ = new ExpNode_Int16<LogicalNode>(); break;
                    case 18: this.Exp__ = new ExpNode_Nullable_Int16<LogicalNode>(); break;
                    case 19: this.Exp__ = new ExpNode_Int32<LogicalNode>(); break;
                    case 20: this.Exp__ = new ExpNode_Nullable_Int32<LogicalNode>(); break;
                    case 21: this.Exp__ = new ExpNode_Int64<LogicalNode>(); break;
                    case 22: this.Exp__ = new ExpNode_Nullable_Int64<LogicalNode>(); break;
                    case 23: this.Exp__ = new ExpNode_Object<LogicalNode>(); break;
                    case 24: this.Exp__ = new ExpNode_Nullable_Object<LogicalNode>(); break;
                    case 25: this.Exp__ = new ExpNode_String<LogicalNode>(); break;
                    case 26: this.Exp__ = new ExpNode_Nullable_String<LogicalNode>(); break;
                    case 27: this.Exp__ = new ExpNode_DateTime2<LogicalNode>(); break;
                    case 28: this.Exp__ = new ExpNode_Nullable_DateTime2<LogicalNode>(); break;
                }
                this.Exp__.Fill(buffer, ref startIndex, this);
            }
        }
    }

    public partial class LogicalNode<T> : LogicalNode where T : LogicalNode, new()
    {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh(new T()); }
        public static T New() { return new T(); }

        public T And(T L) { return new T { First__ = this, Logical__ = Logicals.And, Second__ = L }; }
        public T Or(T L) { return new T { First__ = this, Logical__ = Logicals.Or, Second__ = L }; }
        public T Not() { return new T { First__ = this, Logical__ = Logicals.Not }; }

        public void And(Handler eh)
        {
            if (this.First__ == null && this.Exp__ == null)
            {
                New(eh).CopyTo(this);
            }
            else
            {
                var child = new T();
                this.CopyTo(child);

                this.First__ = eh(new T());
                this.Logical__ = Logicals.And;
                this.Second__ = child;
                this.Exp__ = null;
            }
        }
        public void Or(Handler eh)
        {
            if (this.First__ == null && this.Exp__ == null)
            {
                New(eh).CopyTo(this);
            }
            else
            {
                var child = new T();
                this.CopyTo(child);

                this.First__ = eh(new T());
                this.Logical__ = Logicals.Or;
                this.Second__ = child;
                this.Exp__ = null;
            }
        }

        public static T operator &(LogicalNode<T> a, LogicalNode<T> b) { return new T { First__ = a, Logical__ = Logicals.And, Second__ = b }; }
        public static T operator |(LogicalNode<T> a, LogicalNode<T> b) { return new T { First__ = a, Logical__ = Logicals.Or, Second__ = b }; }

        protected void Check()
        {
            if (this.Exp__ != null)
                throw new Exception("do not support column.operate(value).column.operate(value).....");
        }

        #region New_Type Methods

        protected ExpNode_Nullable_Boolean<T> New_Nullable_Boolean(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Boolean<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Boolean<T> New_Boolean(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Boolean<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Byte<T> New_Nullable_Byte(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Byte<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Byte<T> New_Byte(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Byte<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Bytes<T> New_Nullable_Bytes(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Bytes<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Bytes<T> New_Bytes(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Bytes<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Int16<T> New_Nullable_Int16(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int16<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Int16<T> New_Int16(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Int16<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Int32<T> New_Nullable_Int32(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int32<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Int32<T> New_Int32(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Int32<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Int64<T> New_Nullable_Int64(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Int64<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Int64<T> New_Int64(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Int64<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Decimal<T> New_Nullable_Decimal(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Decimal<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Decimal<T> New_Decimal(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Decimal<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Double<T> New_Nullable_Double(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Double<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Double<T> New_Double(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Double<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_DateTime<T> New_Nullable_DateTime(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_DateTime<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_DateTime<T> New_DateTime(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_DateTime<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_DateTime2<T> New_Nullable_DateTime2(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_DateTime2<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_DateTime2<T> New_DateTime2(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_DateTime2<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Float<T> New_Nullable_Float(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Float<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Float<T> New_Float(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Float<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_String<T> New_Nullable_String(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_String<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_String<T> New_String(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_String<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Guid<T> New_Nullable_Guid(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Guid<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Guid<T> New_Guid(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Guid<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        protected ExpNode_Nullable_Object<T> New_Nullable_Object(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Nullable_Object<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }
        protected ExpNode_Object<T> New_Object(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode_Object<T> { Parent = L, ColumnName = column };
            L.Exp__ = e;
            return e;
        }

        #endregion
    }

    partial class ExpNode
    {
        public byte TypeNumber__;

        /// <summary>
        /// 获取运算符的 SQL 写法
        /// </summary>
        public static string GetSqlOperater(Operators op)
        {
            switch (op)
            {
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

        public override string ToString()
        {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null)
        {
            string sn, so;
            sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema.Replace("]", "]]") + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name.Replace("]", "]]") + "]."))
                + "[" + this.ColumnName.Replace("]", "]]") + "]";

            if (this.Operate == Operators.Equal && (this.Value == null || this.Value == DBNull.Value))
                so = "{0} IS {1}";
            else if (this.Operate == Operators.NotEqual && (this.Value == null || this.Value == DBNull.Value))
                so = "{0} IS NOT {1}";
            else so = GetSqlOperater(this.Operate);

            if (this.Operate == Operators.Between)
                return string.Format(so, sn, GetValueString(), GetValue2String());
            return string.Format(so, sn, GetValueString());
        }

        public virtual byte[] GetBytes()
        {
            var buff = new List<byte[]>();
            // skip parent
            buff.Add(ColumnName.GetBytes());
            buff.Add(new byte[] { (byte)(int)Operate });
            if (Value == null || Value == DBNull.Value)
            {
                buff.Add(new byte[] { (byte)0 });
            }
            else
            {
                buff.Add(new byte[] { (byte)1 });
                buff.Add(Value.GetBytes());
            }
            if (Value2 == null || Value2 == DBNull.Value)
            {
                buff.Add(new byte[] { (byte)0 });
            }
            else
            {
                buff.Add(new byte[] { (byte)1 });
                buff.Add(Value2.GetBytes());
            }
            return buff.Combine();
        }

        public virtual void Fill(byte[] buffer, ref int startIndex, LogicalNode parent)
        {
            this.Parent = parent;
            this.ColumnName = buffer.ToString(ref startIndex);
            this.Operate = (Operators)(int)buffer.ToByte(ref startIndex);

            if (buffer.ToByte(ref startIndex) == 0)
                Value = null;
            else
                this.Value = buffer.ToObject(ref startIndex);

            if (buffer.ToByte(ref startIndex) == 0)
                Value2 = null;
            else
                this.Value2 = buffer.ToObject(ref startIndex);
        }

        protected virtual string GetValueString()
        {
            return Value.ToString();
        }

        protected virtual string GetValue2String()
        {
            return Value2.ToString();
        }
    }

    public partial class ExpNode_Nullable<T> : ExpNode where T : LogicalNode, new()
    {
        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return Value.ToString();
        }

        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return Value2.ToString();
        }

        public T IsNull()
        {
            this.Operate = Operators.Equal;
            this.Value = null;
            return (T)this.Parent;
        }
        public T IsNotNull()
        {
            this.Operate = Operators.NotEqual;
            this.Value = null;
            return (T)this.Parent;
        }
    }

    #endregion

    #region inherit (data types)

    #region Boolean

    public partial class ExpNode_Boolean<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Boolean()
        {
            this.TypeNumber__ = 1;
        }

        protected override string GetValueString()
        {
            return (bool)this.Value ? "1" : "0";
        }

        protected override string GetValue2String()
        {
            return (bool)this.Value2 ? "1" : "0";
        }

        public T Equal(Boolean value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Boolean value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Boolean<T> a, Boolean b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Boolean<T> a, Boolean b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Boolean<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Boolean()
        {
            this.TypeNumber__ = 2;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return ((bool?)this.Value).Value ? "1" : "0";
        }
        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return ((bool?)this.Value2).Value ? "1" : "0";
        }

        public T Equal(Boolean? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Boolean? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Boolean<T> a, Boolean? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Boolean<T> a, Boolean? b) { return a.NotEqual(b); }

    }

    #endregion

    #region Byte

    public partial class ExpNode_Byte<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Byte()
        {
            this.TypeNumber__ = 3;
        }

        public T Equal(Byte value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Byte value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Byte value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Byte value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Byte value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Byte value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Byte value, Byte value2)
        {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Byte<T> a, Byte b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Byte<T> a, Byte b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Byte<T> a, Byte b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Byte<T> a, Byte b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Byte<T> a, Byte b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Byte<T> a, Byte b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Byte<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {
        public ExpNode_Nullable_Byte()
        {
            this.TypeNumber__ = 4;
        }

        public T Equal(Byte? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Byte? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Byte? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Byte? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Byte? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Byte? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Byte? value, Byte? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Byte<T> a, Byte? b) { return a.NotEqual(b); }
    }

    #endregion

    #region Bytes

    public partial class ExpNode_Bytes<T> : ExpNode where T : LogicalNode, new()
    {
        public ExpNode_Bytes()
        {
            this.TypeNumber__ = 5;
        }

        protected override string GetValueString()
        {
            return SqlUtils.ToHexString((byte[])this.Value);
        }
        protected override string GetValue2String()
        {
            return SqlUtils.ToHexString((byte[])this.Value2);
        }

        public T Equal(byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Bytes<T> a, byte[] b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Bytes<T> a, byte[] b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Bytes<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Bytes()
        {
            this.TypeNumber__ = 6;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return SqlUtils.ToHexString((byte[])this.Value);
        }
        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return SqlUtils.ToHexString((byte[])this.Value2);
        }

        public T Equal(Byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Byte[] value)
        {
            if (value == null) value = new byte[] { };
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Bytes<T> a, byte[] b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Bytes<T> a, byte[] b) { return a.NotEqual(b); }
    }

    #endregion

    #region Decimal

    public partial class ExpNode_Decimal<T> : ExpNode where T : LogicalNode, new()
    {
        public ExpNode_Decimal()
        {
            this.TypeNumber__ = 7;
        }

        public T Equal(Decimal value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Decimal value, Decimal value2)
        {
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

    public partial class ExpNode_Nullable_Decimal<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Decimal()
        {
            this.TypeNumber__ = 8;
        }

        public T Equal(Decimal? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Decimal? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Decimal? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Decimal? value, Decimal? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
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

    #region DateTime

    public partial class ExpNode_DateTime<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_DateTime()
        {
            this.TypeNumber__ = 9;
        }

        protected override string GetValueString()
        {
            return "'" + ((DateTime)this.Value).ToString("yyyy-MM-d HH:mm:ss.fff") + "'";
        }

        protected override string GetValue2String()
        {
            return "'" + ((DateTime)this.Value2).ToString("yyyy-MM-d HH:mm:ss.fff") + "'";
        }

        public T Equal(DateTime value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime value, DateTime value2)
        {
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

    public partial class ExpNode_Nullable_DateTime<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_DateTime()
        {
            this.TypeNumber__ = 10;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value).Value.ToString("yyyy-MM-d HH:mm:ss.fff") + "'";
        }

        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value2).Value.ToString("yyyy-MM-d HH:mm:ss.fff") + "'";
        }

        public T Equal(DateTime? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime? value, DateTime? value2)
        {
            if (value == null) value = new DateTime();
            if (value2 == null) value2 = new DateTime();
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

    #region Double

    public partial class ExpNode_Double<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Double()
        {
            this.TypeNumber__ = 11;
        }

        public T Equal(Double value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Double value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Double value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Double value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Double value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Double value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Double value, Double value2)
        {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Double<T> a, Double b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Double<T> a, Double b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Double<T> a, Double b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Double<T> a, Double b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Double<T> a, Double b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Double<T> a, Double b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Double<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Double()
        {
            this.TypeNumber__ = 12;
        }

        public T Equal(Double? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Double? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Double? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Double? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Double? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Double? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Double? value, Double? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Double<T> a, Double? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Double<T> a, Double? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Double<T> a, Double? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Double<T> a, Double? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Double<T> a, Double? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Double<T> a, Double? b) { return a.NotEqual(b); }
    }

    #endregion

    #region Float

    public partial class ExpNode_Float<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Float()
        {
            this.TypeNumber__ = 13;
        }

        public T Equal(float value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(float value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(float value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(float value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(float value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(float value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(float value, float value2)
        {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Float<T> a, float b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Float<T> a, float b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Float<T> a, float b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Float<T> a, float b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Float<T> a, float b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Float<T> a, float b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Float<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Float()
        {
            this.TypeNumber__ = 14;
        }

        public T Equal(float? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(float? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(float? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(float? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(float? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(float? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(float? value, float? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_Float<T> a, float? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_Float<T> a, float? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_Float<T> a, float? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_Float<T> a, float? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_Float<T> a, float? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Float<T> a, float? b) { return a.NotEqual(b); }
    }

    #endregion

    #region Guid

    public partial class ExpNode_Guid<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Guid()
        {
            this.TypeNumber__ = 15;
        }

        protected override string GetValueString()
        {
            return "'" + ((Guid)this.Value).ToString() + "'";
        }

        protected override string GetValue2String()
        {
            return "'" + ((Guid)this.Value2).ToString() + "'";
        }

        public T Equal(Guid value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Guid value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Guid<T> a, Guid b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Guid<T> a, Guid b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_Guid<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Guid()
        {
            this.TypeNumber__ = 16;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((Guid?)this.Value).ToString() + "'";
        }

        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((Guid?)this.Value2).ToString() + "'";
        }


        public T Equal(Guid? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Guid? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator ==(ExpNode_Nullable_Guid<T> a, Guid? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_Guid<T> a, Guid? b) { return a.NotEqual(b); }
    }

    #endregion

    #region Int16

    public partial class ExpNode_Int16<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Int16()
        {
            this.TypeNumber__ = 17;
        }

        public T Equal(Int16 value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16 value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16 value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16 value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16 value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16 value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int16 value, Int16 value2)
        {
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

    public partial class ExpNode_Nullable_Int16<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Int16()
        {
            this.TypeNumber__ = 18;
        }

        public T Equal(Int16? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int16? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int16? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int16? value, Int16? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
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

    #region Int32

    public partial class ExpNode_Int32<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Int32()
        {
            this.TypeNumber__ = 19;
        }

        public T Equal(Int32 value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int32 value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32 value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32 value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32 value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32 value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int32 value, Int32 value2)
        {
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

    public partial class ExpNode_Nullable_Int32<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Int32()
        {
            this.TypeNumber__ = 20;
        }

        public T Equal(Int32? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int32? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int32? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int32? value, Int32? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
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

    #region Int64

    public partial class ExpNode_Int64<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Int64()
        {
            this.TypeNumber__ = 21;
        }

        public T Equal(Int64 value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64 value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64 value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64 value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64 value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64 value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int64 value, Int64 value2)
        {
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

    public partial class ExpNode_Nullable_Int64<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Int64()
        {
            this.TypeNumber__ = 22;
        }

        public T Equal(Int64? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(Int64? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(Int64? value)
        {
            if (value == null) value = 0;
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(Int64? value, Int64? value2)
        {
            if (value == null) value = 0;
            if (value2 == null) value2 = 0;
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

    #region Object

    public partial class ExpNode_Object<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_Object()
        {
            this.TypeNumber__ = 23;
        }

        protected override string GetValueString()
        {
            // todo: check type & + ''
            return "'" + this.Value.ToString() + "'";
        }

        protected override string GetValue2String()
        {
            // todo: check type & + ''
            return "'" + this.Value2.ToString() + "'";
        }

        public T Action(Operators operate, Object value)
        {
            this.Operate = operate;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    public partial class ExpNode_Nullable_Object<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_Object()
        {
            this.TypeNumber__ = 24;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            // todo: check type & + ''
            return "'" + this.Value.ToString() + "'";
        }

        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            // todo: check type & + ''
            return "'" + this.Value2.ToString() + "'";
        }

        public T Action(Operators operate, Object value)
        {
            this.Operate = operate;
            this.Value = value;
            return (T)this.Parent;
        }
    }

    #endregion

    #region String

    public partial class ExpNode_String<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_String()
        {
            this.TypeNumber__ = 25;
        }

        protected override String GetValueString()
        {
            return "'" + ((String)this.Value).Replace("'", "''") + "'";
        }

        protected override String GetValue2String()
        {
            return "'" + ((String)this.Value2).Replace("'", "''") + "'";
        }

        public T Equal(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Like(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.Like;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_String<T> a, String b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_String<T> a, String b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_String<T> a, String b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_String<T> a, String b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_String<T> a, String b) { return a.Equal(b); }
        public static T operator !=(ExpNode_String<T> a, String b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_String<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_String()
        {
            this.TypeNumber__ = 26;
        }

        protected override String GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((String)this.Value).Replace("'", "''") + "'";
        }

        protected override String GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((String)this.Value2).Replace("'", "''") + "'";
        }

        public T Equal(String value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(String value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Like(String value)
        {
            if (value == null) value = "";
            this.Operate = Operators.Like;
            this.Value = value;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_String<T> a, String b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_String<T> a, String b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_String<T> a, String b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_String<T> a, String b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_String<T> a, String b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_String<T> a, String b) { return a.NotEqual(b); }
    }

    #endregion

    #region DateTime2

    public partial class ExpNode_DateTime2<T> : ExpNode where T : LogicalNode, new()
    {

        public ExpNode_DateTime2()
        {
            this.TypeNumber__ = 27;
        }

        protected override string GetValueString()
        {
            return "'" + ((DateTime)this.Value).ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        protected override string GetValue2String()
        {
            return "'" + ((DateTime)this.Value2).ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        public T Equal(DateTime value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime value)
        {
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime value)
        {
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime value)
        {
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime value)
        {
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime value, DateTime value2)
        {
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_DateTime2<T> a, DateTime b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_DateTime2<T> a, DateTime b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_DateTime2<T> a, DateTime b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_DateTime2<T> a, DateTime b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_DateTime2<T> a, DateTime b) { return a.Equal(b); }
        public static T operator !=(ExpNode_DateTime2<T> a, DateTime b) { return a.NotEqual(b); }
    }

    public partial class ExpNode_Nullable_DateTime2<T> : ExpNode_Nullable<T> where T : LogicalNode, new()
    {

        public ExpNode_Nullable_DateTime2()
        {
            this.TypeNumber__ = 28;
        }

        protected override string GetValueString()
        {
            if (this.Value == null || this.Value == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value).Value.ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        protected override string GetValue2String()
        {
            if (this.Value2 == null || this.Value2 == DBNull.Value) return "NULL";
            return "'" + ((DateTime?)this.Value2).Value.ToString("yyyy-MM-d HH:mm:ss.fffffff") + "'";
        }

        public T Equal(DateTime? value)
        {
            this.Operate = Operators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public T NotEqual(DateTime? value)
        {
            this.Operate = Operators.NotEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.GreaterThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessThan(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.LessThan;
            this.Value = value;
            return (T)this.Parent;
        }

        public T GreaterEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.GreaterEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T LessEqual(DateTime? value)
        {
            if (value == null) value = new DateTime();
            this.Operate = Operators.LessEqual;
            this.Value = value;
            return (T)this.Parent;
        }

        public T Between(DateTime? value, DateTime? value2)
        {
            if (value == null) value = new DateTime();
            if (value2 == null) value2 = new DateTime();
            this.Operate = Operators.Between;
            this.Value = value;
            this.Value2 = value2;
            return (T)this.Parent;
        }

        public static T operator >(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.GreaterThan(b); }
        public static T operator <(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.LessThan(b); }

        public static T operator >=(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.GreaterEqual(b); }
        public static T operator <=(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.LessEqual(b); }

        public static T operator ==(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.Equal(b); }
        public static T operator !=(ExpNode_Nullable_DateTime2<T> a, DateTime? b) { return a.NotEqual(b); }
    }

    #endregion

    #endregion
}
