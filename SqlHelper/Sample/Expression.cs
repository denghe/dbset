namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DAL.Expressions.dbo;

    class Program
    {
        static void Main(string[] args)
        {
            var rows = DAL.Tables.dbo.t2.Select(o =>
                (o.id.Equal(1)
                & o.id.Equal(2)
                | o.id.Equal(3)
                & o.id.Equal(4)).Not()
            );

            var exp1 = t2.New(o => o.id.Equal(1).id.Equal(2).id.Equal(3));

            Console.WriteLine(exp1);

            var exp2 = t2.New(o => (o.id.Equal(1) | o.id.Equal(2)) & (o.id.Equal(3) | o.id.Equal(4)));

            Console.WriteLine(exp2);

            Console.ReadLine();
        }
    }
}


namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // 生成物
    public partial class t2
    {
        public static List<t2> Select(Expressions.dbo.t2.ExpHandler exp)
        {
            return new List<t2>();
        }
    }

}



namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // 生成物
    public partial class t2 : LogicalNode
    {
        public t2()
            : base(null, SqlLogicals.And, null, null)
        {
        }
        public t2(t2 first, SqlLogicals operate, t2 second)
            : base(first, operate, second, null)
        {
        }
        public delegate t2 ExpHandler(t2 t2);
        public static t2 New(ExpHandler eh) { return eh.Invoke(new t2()); }

        public t2 And(t2 L) { return new t2(this, SqlLogicals.And, L); }
        public t2 Or(t2 L) { return new t2(this, SqlLogicals.Or, L); }
        public t2 Not() { return new t2(this, SqlLogicals.Not, null); }
        public static t2 operator &(t2 a, t2 b) { return a.And(b); }
        public static t2 operator |(t2 a, t2 b) { return a.Or(b); }


        public ExpressionNode_Nullable_Int32<t2> id
        {
            get
            {
                var L = new t2();
                var e = new ExpressionNode_Nullable_Int32<t2>(L, "id");
                L.Expression = e;

                return e;
            }
        }
        // todo: more columns
    }
}


namespace DAL.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class LogicalNode
    {
        public SqlLogicals Logical;
        public LogicalNode First;
        public LogicalNode Second;
        public ExpressionNode Expression;
    }

    public partial class ExpressionNode
    {
        public LogicalNode Parent = null;
        public string Column = null;
        public SqlOperators Operate = 0;
        public object Value = null;
    }



    partial class LogicalNode
    {
        public LogicalNode(LogicalNode first, SqlLogicals logical, LogicalNode second, ExpressionNode exp)
        {
            this.First = first;
            this.Logical = logical;
            this.Second = second;
            this.Expression = exp;
        }

        //public LogicalNode And(LogicalNode L)
        //{
        //    return new LogicalNode(this, SqlLogicals.And, L, null);
        //}
        //public LogicalNode Or(LogicalNode L)
        //{
        //    return new LogicalNode(this, SqlLogicals.Or, L, null);
        //}
        //public LogicalNode Not()
        //{
        //    return new LogicalNode(this, SqlLogicals.Not, null, null);
        //}

        public override string ToString()
        {
            if (this.Expression == null)
            {
                var firstQuote = this.First.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                var secondQuote = this.Second.Logical == SqlLogicals.Or && this.Logical == SqlLogicals.And;
                var s1 = firstQuote ? "( " : "";
                var s2 = firstQuote ? " ) " : " ";
                var s3 = secondQuote ? " ( " : " ";
                var s4 = secondQuote ? " )" : "";
                return s1 + this.First.ToString() + s2 + this.Logical.ToString() + s3 + this.Second.ToString() + s4;
            }
            return this.Expression.ToString();
        }
    }

    partial class ExpressionNode
    {
        public ExpressionNode(LogicalNode parent, string column, SqlOperators operate, object value)
        {
            this.Parent = parent;
            this.Column = column;
            this.Operate = operate;
            this.Value = value;
        }
    }

    public partial class ExpressionNode_Nullable<T> : ExpressionNode where T : LogicalNode
    {
        public ExpressionNode_Nullable(LogicalNode parent, string column)
            : base(parent, column, SqlOperators.Custom, null)
        {
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

    public partial class ExpressionNode<T> : ExpressionNode where T : LogicalNode
    {
        public ExpressionNode(LogicalNode parent, string column)
            : base(parent, column, SqlOperators.Custom, null)
        {
        }
    }

    public partial class ExpressionNode_Int32<T> : ExpressionNode<T> where T : LogicalNode
    {
        public ExpressionNode_Int32(LogicalNode parent, string column)
            : base(parent, column)
        {
        }
        public T Equal(Int32 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        // todo: more operate methods

        public override string ToString()
        {
            return this.Column + " " + this.Operate.ToString() + " " + Value.ToString();
        }
    }

    public partial class ExpressionNode_Nullable_Int32<T> : ExpressionNode<T> where T : LogicalNode
    {
        public ExpressionNode_Nullable_Int32(LogicalNode parent, string column)
            : base(parent, column)
        {
        }
        public T Equal(Int32? value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;

            return (T)this.Parent;
        }

        // todo: more operate methods


        public override string ToString()
        {
            return this.Column + " " + this.Operate.ToString() + " " + (Value == null ? "[Null]" : Value.ToString());
        }
    }

    // todo: more ExpressionNode_ DataTypes, ExpressionNode_Nullable_ DataTypes class


    /// <summary>
    /// 字段--值 SQL 运算符
    /// </summary>
    public enum SqlOperators : int
    {
        Null = 0,

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
        Null = 0,
        And,
        Or,
        Not
    }
}
