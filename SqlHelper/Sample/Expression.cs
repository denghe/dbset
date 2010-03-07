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
    public partial class t2 : LogicalNode<t2>
    {
        public ExpressionNode_Nullable_Int32<t2> id { get { return this.New_ExpressionNode_Nullable_Int32<t2>("id"); } }
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
        public SqlLogicals Logical = SqlLogicals.And;
        public LogicalNode First;
        public LogicalNode Second;
        public ExpressionNode Expression;
    }

    public partial class ExpressionNode
    {
        public LogicalNode Parent = null;
        public string Column = null;
        public SqlOperators Operate = SqlOperators.NotSet;
        public object Value = null;
    }



    partial class LogicalNode
    {
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

    public class LogicalNode<T> : LogicalNode where T : LogicalNode, new()
    {
        public delegate T ExpHandler(T eh);
        public static T New(ExpHandler eh) { return eh.Invoke(new T()); }

        public T And(T L) { return new T { First = this, Logical = SqlLogicals.And, Second = L }; }
        public T Or(T L) { return new T { First = this, Logical = SqlLogicals.Or, Second = L }; }
        public T Not() { return new T { First = this, Logical = SqlLogicals.Not }; }

        public static T operator &(LogicalNode<T> a, LogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.And, Second = b }; }
        public static T operator |(LogicalNode<T> a, LogicalNode<T> b) { return new T { First = a, Logical = SqlLogicals.Or, Second = b }; }

        public ExpressionNode_Nullable_Int32<T> New_ExpressionNode_Nullable_Int32(string column)
        {
            var L = new T();
            var e = new ExpressionNode_Nullable_Int32<T> { Parent = L, Column = "id" };
            L.Expression = e;
            return e;
        }

        // todo: more new expression
    }

    public partial class ExpressionNode_Nullable<T> : ExpressionNode where T : LogicalNode, new()
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

    public partial class ExpressionNode_Int32<T> : ExpressionNode where T : LogicalNode, new()
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
            return this.Column + " " + this.Operate.ToString() + " " + Value.ToString();
        }
    }

    public partial class ExpressionNode_Nullable_Int32<T> : ExpressionNode where T : LogicalNode, new()
    {
        public T Equal(Int32? value)
        {
            if (this.Operate == SqlOperators.NotSet)
            {
                this.Operate = SqlOperators.Equal;
                this.Value = value;
                return (T)this.Parent;
            }
            var t = new T { First = this.Parent };
            t.Second = new T { Expression = new ExpressionNode_Nullable_Int32<T> { Parent = t } };
            return t;
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
