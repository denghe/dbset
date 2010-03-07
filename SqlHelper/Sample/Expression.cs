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
            //var rows = DAL.Tables.dbo.t1.Select(o =>
            //    (o.id.Equal(1)
            //    & o.name.Like("t2")
            //    | o.name.Equal("t3")
            //    & o.id.IsNull()).Not()
            //);

            //var exp = t1.New(o =>
            //    (o.id.Equal(1)
            //    & o.name.Like("t2")
            //    | o.name.Equal("t3")
            //    & o.id.IsNull()).Not()
            //);

            //var exp = t1.New(o =>
            //    (o.id.Equal(1) & o.id.Equal(2)) | o.id.Equal(3)
            //);

            var exp2 = t2.New(o => o.id.Equal(1));

            Console.Write(exp2.Expression.Operate.ToString());

            Console.ReadLine();
        }
    }
}


namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //// 生成物
    //public partial class t1
    //{
    //    public static List<t1> Select(Expressions.dbo.t1.ExpHandler exp)
    //    {
    //        return new List<t1>();
    //    }
    //}

}



namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //// 生成物
    //public partial class t1 : TableBase
    //{
    //    public t1()
    //    {
    //        _name = "dbo";
    //        _schema = "t1";
    //    }
    //    public delegate TableBase ExpHandler(t1 t1);
    //    public static TableBase New(ExpHandler eh) { return eh.Invoke(new t1()); }

    //    public ColumnBase_Int32<t1> id { get { return new ColumnBase_Int32<t1>(new t1(), "id"); } }
    //    public Column_String<t1> name { get { return new Column_String<t1>(new t1(), "name"); } }
    //    //...
    //}

    // 生成物
    public partial class t2 : LogicalNode
    {
        public t2()
            : base(null, SqlLogicals.And, null, null)
        {
        }
        public delegate t2 ExpHandler(t2 t2);
        public static t2 New(ExpHandler eh) { return eh.Invoke(new t2()); }

        public ExpressionNode_Nullable_Int32<t2> id
        {
            get
            {
                var exp = new ExpressionNode_Nullable_Int32<t2>(this, "id");
                this.Expression = exp;
                return exp;
            }
        }
        //...
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

        public LogicalNode And(ExpressionNode e)
        {
            return new LogicalNode(this, SqlLogicals.And, e.Parent, null);
        }
        public LogicalNode Or(ExpressionNode e)
        {
            return new LogicalNode(this, SqlLogicals.Or, e.Parent, null);
        }
        public LogicalNode Not()
        {
            return new LogicalNode(this, SqlLogicals.Not, null, null);
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
    }

    public partial class ExpressionNode_Nullable_Int32<T> : ExpressionNode<T> where T : LogicalNode
    {
        public ExpressionNode_Nullable_Int32(LogicalNode parent, string column)
            : base(parent, column)
        {
        }
        public T Equal(Int32 value)
        {
            this.Operate = SqlOperators.Equal;
            this.Value = value;
            return (T)this.Parent;
        }

        public override string ToString()
        {
            return this.Column + 
        }

        // todo: more operate methods
    }

    // todo: more ExpressionNode_ DataTypes, ExpressionNode_Nullable_ DataTypes class












    //public class TableBase
    //{
    //    protected string _name = null;
    //    protected string _schema = null;
    //    public ColumnBase _column = null;
    //    protected bool _isAnd = true;
    //    protected bool _isNot = false;
    //    protected List<TableBase> _childs = new List<TableBase>();

    //    public override string ToString() { return _childs.ToString(); }

    //    // 基础方法: AND , OR
    //    public TableBase And(TableBase t)
    //    {
    //        _isAnd = true;
    //        _childs.Add(t);
    //        return this;
    //    }
    //    public TableBase Or(TableBase t)
    //    {
    //        _isAnd = false;
    //        _childs.Add(t);
    //        return this;
    //    }
    //    public TableBase Not()
    //    {
    //        _isNot = true;
    //        return this;
    //    }

    //    // 运算符重载
    //    public static TableBase operator &(TableBase e1, TableBase e2)
    //    {
    //        return e1.And(e2);
    //    }
    //    public static TableBase operator |(TableBase e1, TableBase e2)
    //    {
    //        return e1.Or(e2);
    //    }
    //}

    //public class ColumnBase
    //{
    //    public TableBase Parent = null;
    //    public string Column = null;
    //    public SqlOperators Operate = 0;
    //    public object Value = null;
    //}

    //public class ColumnBase<T> : ColumnBase where T : TableBase, new()
    //{
    //    public ColumnBase(T t, string n)
    //    {
    //        Parent = t;
    //        Column = n;
    //    }

    //    public T IsNull()
    //    {
    //        Parent._column = this;
    //        Operate = SqlOperators.Equal;
    //        Value = null;
    //        return (T)Parent;
    //    }
    //    public T IsNotNull()
    //    {
    //        Parent._column = this;
    //        Operate = SqlOperators.NotEqual;
    //        Value = null;
    //        return (T)Parent;
    //    }
    //}

    //public class ColumnBase_Int32<T> : ColumnBase<T> where T : TableBase, new()
    //{
    //    public ColumnBase_Int32(T t, string s)
    //        : base(t, s)
    //    {
    //    }
    //    public T Equal(Int32 value)
    //    {
    //        Parent._column = this;
    //        Operate = SqlOperators.Equal;
    //        Value = value;
    //        return (T)Parent;
    //    }
    //}

    //public class Column_String<T> : ColumnBase<T> where T : TableBase, new()
    //{
    //    public Column_String(T t, string s)
    //        : base(t, s)
    //    {
    //    }
    //    public T Equal(String value)
    //    {
    //        Parent._column = this;
    //        Operate = SqlOperators.Equal;
    //        Value = value;
    //        return (T)Parent;
    //    }
    //    public T Like(string value)
    //    {
    //        Parent._column = this;
    //        Operate = SqlOperators.Like;
    //        Value = value;
    //        return (T)Parent;
    //    }
    //}


    /// <summary>
    /// 字段--值 SQL 运算符
    /// </summary>
    public enum SqlOperators : int
    {
        Custom = 0,
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
        And = 0,
        Or,
        Not
    }
}
