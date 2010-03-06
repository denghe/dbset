namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //using DAL.Expressions.dbo;

    class Program
    {
        static void Main(string[] args)
        {
            // 单表快捷查询
            DAL.Tables.dbo.t1.Select(o => o.id.Equals(1).name.Like("t2") | o.name.Equals("t3") & o.id.IsNull());

            var exp = DAL.Expressions.dbo.t1.New(o => o.id.Equals(1).name.Like("t2") | o.name.Equals("t3") & o.id.IsNull());

            Console.Write(exp.ToString());

            Console.ReadLine();
        }
    }
}

namespace DAL.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExpressionsBase
    {
        private string _where;
        private string _name;
        private string _schema;

        public void zzzSetWhere(string where) { _where = where; }
        public string zzzGetName() { return _name; }
        public string zzzGetSchema() { return _schema; }
        public override string ToString() { return _where; }

        public ExpressionsBase() { }
        public ExpressionsBase(string where) { _where = where; }
        public ExpressionsBase(string schema, string name)
        {
            this._name = name; this._schema = schema;
        }

        // TSQL 运算符转为方法
        public ExpressionsBase And(ExpressionsBase e)
        {
            return new ExpressionsBase("(" + _where + ")" + " AND " + "(" + e._where + ")");
        }
        public ExpressionsBase Or(ExpressionsBase e)
        {
            return new ExpressionsBase("(" + _where + ")" + " OR " + "(" + e._where + ")");
        }

        // 运算符重载
        public static ExpressionsBase operator &(ExpressionsBase e1, ExpressionsBase e2)
        {
            return e1.And(e2);
        }
        public static ExpressionsBase operator |(ExpressionsBase e1, ExpressionsBase e2)
        {
            return e1.Or(e2);
        }
    }



    public class Column<T> where T : ExpressionsBase, new()
    {
        protected string _field;
        protected T _exp;
        public Column(T exp, string f)
        {
            _exp = exp;
            _field = f;
        }

        public T IsNull()
        {
            var t = new T();
            t.zzzSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zzzGetSchema() + "].[" + _exp.zzzGetName() + "].[" + this._field + "] IS NULL");
            return t;
        }
        public T IsNotNull()
        {
            var t = new T();
            t.zzzSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zzzGetSchema() + "].[" + _exp.zzzGetName() + "].[" + this._field + "] IS NOT NULL");
            return t;
        }
    }

    public class Column_Int32<T> : Column<T> where T : ExpressionsBase, new()
    {
        public Column_Int32(T exp, string s)
            : base(exp, s)
        {
        }
        public T Equals(Int32 value)
        {
            var t = new T();
            t.zzzSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zzzGetSchema() + "].[" + _exp.zzzGetName() + "].[" + this._field + "] = '" + value + "'");
            return t;
        }
    }

    public class Column_String<T> : Column<T> where T : ExpressionsBase, new()
    {
        public Column_String(T exp, string s)
            : base(exp, s)
        {
        }
        public T Equals(String value)
        {
            var t = new T();
            t.zzzSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zzzGetSchema() + "].[" + _exp.zzzGetName() + "].[" + this._field + "] = '" + value + "'");
            return t;
        }
        public T Like(string value)
        {
            var t = new T();
            t.zzzSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zzzGetSchema() + "].[" + _exp.zzzGetName() + "].[" + this._field + "] LIKE '%" + value + "%'");
            return t;
        }
    }
}

namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class t1 : ExpressionsBase
    {
        public t1()
            : base("dbo", "t1")
        {
        }
        public Column_Int32<t1> id
        {
            get { return new Column_Int32<t1>(this, "id"); }
        }
        public Column_String<t1> name
        {
            get { return new Column_String<t1>(this, "name"); }
        }

        public delegate ExpressionsBase ExpHandler(t1 t1);
        public static ExpressionsBase New(ExpHandler eh)
        {
            return eh.Invoke(new t1());
        }
    }

    public partial class t2 : ExpressionsBase
    {
        public t2()
            : base("dbo", "t2")
        {
        }
        public Column_Int32<t2> id
        {
            get { return new Column_Int32<t2>(this, "id"); }
        }
        public Column_String<t2> name
        {
            get { return new Column_String<t2>(this, "name"); }
        }

        public delegate ExpressionsBase ExpHandler(t2 t2);
        public static t2 New(ExpHandler eh)
        {
            return (t2)eh.Invoke(new t2());
        }
    }
}

namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class t1
    {
        public static List<t1> Select(Expressions.dbo.t1.ExpHandler exp)
        {
            return new List<t1>();
        }
    }

    public partial class t2
    {
        public static List<t2> Select(Expressions.dbo.t2.ExpHandler exp)
        {
            return new List<t2>();
        }
    }
}
