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

            var exp = t1.New(o =>
                (o.id.Equal(1) & o.id.Equal(2)) | o.id.Equal(3) 
            );

            Console.Write(exp.ToString());

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
    public partial class t1
    {
        public static List<t1> Select(Expressions.dbo.t1.ExpHandler exp)
        {
            return new List<t1>();
        }
    }

}



namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // 生成物
    public partial class t1 : TableBase
    {
        public t1()
        {
            _name = "dbo";
            _schema = "t1";
        }
        public delegate TableBase ExpHandler(t1 t1);
        public static TableBase New(ExpHandler eh) { return eh.Invoke(new t1()); }

        public ColumnBase_Int32<t1> id { get { return new ColumnBase_Int32<t1>(new t1(), "id"); } }
        public Column_String<t1> name { get { return new Column_String<t1>(new t1(), "name"); } }
        //...
    }


}


namespace DAL.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TableBase
    {
        protected string _name = null;
        protected string _schema = null;
        public ColumnBase _column = null;
        protected bool _isAnd = true;
        protected bool _isNot = false;
        protected List<TableBase> _childs = new List<TableBase>();

        public override string ToString() { return _childs.ToString(); }

        // 基础方法: AND , OR
        public TableBase And(TableBase t)
        {
            _isAnd = true;
            _childs.Add(t);
            return this;
        }
        public TableBase Or(TableBase t)
        {
            _isAnd = false;
            _childs.Add(t);
            return this;
        }
        public TableBase Not()
        {
            _isNot = true;
            return this;
        }

        // 运算符重载
        public static TableBase operator &(TableBase e1, TableBase e2)
        {
            return e1.And(e2);
        }
        public static TableBase operator |(TableBase e1, TableBase e2)
        {
            return e1.Or(e2);
        }
    }

    public class ColumnBase
    {
        public TableBase Parent = null;
        public string Column = null;
        public SqlOperators Operate = 0;
        public object Value = null;
    }

    public class ColumnBase<T> : ColumnBase where T : TableBase, new()
    {
        public ColumnBase(T t, string n)
        {
            Parent = t;
            Column = n;
        }

        public T IsNull()
        {
            Parent._column = this;
            Operate = SqlOperators.Equal;
            Value = null;
            return (T)Parent;
        }
        public T IsNotNull()
        {
            Parent._column = this;
            Operate = SqlOperators.NotEqual;
            Value = null;
            return (T)Parent;
        }
    }

    public class ColumnBase_Int32<T> : ColumnBase<T> where T : TableBase, new()
    {
        public ColumnBase_Int32(T t, string s)
            : base(t, s)
        {
        }
        public T Equal(Int32 value)
        {
            Parent._column = this;
            Operate = SqlOperators.Equal;
            Value = value;
            return (T)Parent;
        }
    }

    public class Column_String<T> : ColumnBase<T> where T : TableBase, new()
    {
        public Column_String(T t, string s)
            : base(t, s)
        {
        }
        public T Equal(String value)
        {
            Parent._column = this;
            Operate = SqlOperators.Equal;
            Value = value;
            return (T)Parent;
        }
        public T Like(string value)
        {
            Parent._column = this;
            Operate = SqlOperators.Like;
            Value = value;
            return (T)Parent;
        }
    }


    /// <summary>
    /// 表达式运算符
    /// </summary>
    public enum SqlOperators : int
    {
        Custom = 0,
        Equal,
        LessThan,
        LessEqual,
        GreaterThan,
        GreaterEqual,
        NotEqual,
        Like,
        CustomLike,
        NotLike,
        CustomNotLike,
        In,
        NotIn
    }
}
