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
            // 单表快捷查询
            t1.Select(o => o.id.Equals(1).name.Like("t2") | o.name.Equals("t3") & o.id.IsNull());

            Console.ReadLine();
        }
    }
}

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class __ExpBase
    {
        private string _where;
        private string _name;
        private string _schema;

        public void zSetWhere(string where) { _where = where; }
        public string zGetName() { return _name; }
        public string zGetSchema() { return _schema; }
        public override string ToString() { return _where; }

        public __ExpBase() { }
        public __ExpBase(string where) { _where = where; }
        public __ExpBase(string schema, string name)
        {
            this._name = name; this._schema = schema;
        }

        // TSQL 运算符转为方法
        public __ExpBase And(__ExpBase e)
        {
            return new __ExpBase("(" + _where + ")" + " AND " + "(" + e._where + ")");
        }
        public __ExpBase Or(__ExpBase e)
        {
            return new __ExpBase("(" + _where + ")" + " OR " + "(" + e._where + ")");
        }

        // 运算符重载
        public static __ExpBase operator &(__ExpBase e1, __ExpBase e2)
        {
            return e1.And(e2);
        }
        public static __ExpBase operator |(__ExpBase e1, __ExpBase e2)
        {
            return e1.Or(e2);
        }

        // 表达式驱动来返回列表
        public List<T> List<T>() where T : new()
        {
            List<T> _list = new List<T>();
            return _list;
        }

        // 类型快捷创建
        public class dbo
        {
            public static DAL.Expressions.dbo.t1 t1 = new DAL.Expressions.dbo.t1();
            public static DAL.Expressions.dbo.t2 t2 = new DAL.Expressions.dbo.t2();
        }

    }



    public class Column<T> where T : __ExpBase, new()
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
            t.zSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zGetSchema() + "].[" + _exp.zGetName() + "].[" + this._field + "] IS NULL");
            return t;
        }
        public T IsNotNull()
        {
            var t = new T();
            t.zSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zGetSchema() + "].[" + _exp.zGetName() + "].[" + this._field + "] IS NOT NULL");
            return t;
        }
    }

    public class Column_Int32<T> : Column<T> where T : __ExpBase, new()
    {
        public Column_Int32(T exp, string s)
            : base(exp, s)
        {
        }
        public T Equals(Int32 value)
        {
            var t = new T();
            t.zSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zGetSchema() + "].[" + _exp.zGetName() + "].[" + this._field + "] = '" + value + "'");
            return t;
        }
    }

    public class Column_String<T> : Column<T> where T : __ExpBase, new()
    {
        public Column_String(T exp, string s)
            : base(exp, s)
        {
        }
        public T Equals(String value)
        {
            var t = new T();
            t.zSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zGetSchema() + "].[" + _exp.zGetName() + "].[" + this._field + "] = '" + value + "'");
            return t;
        }
        public T Like(string value)
        {
            var t = new T();
            t.zSetWhere((string.IsNullOrEmpty(_exp.ToString()) ? "" : (_exp.ToString() + " AND ")) + "[" + _exp.zGetSchema() + "].[" + _exp.zGetName() + "].[" + this._field + "] LIKE '%" + value + "%'");
            return t;
        }
    }
}

namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DAL;

    public partial class t1 : __ExpBase
    {
        public t1()
            : base("dbo", "t1")
        {
        }
        public delegate __ExpBase ExpHandler(t1 t1);
        public Column_Int32<t1> id
        {
            get { return new Column_Int32<t1>(this, "id"); }
        }
        public Column_String<t1> name
        {
            get { return new Column_String<t1>(this, "name"); }
        }
        public static List<t1> Select(ExpHandler exp)
        {
            return new List<t1>();
        }
    }

    public partial class t2 : __ExpBase
    {
        public t2()
            : base("dbo", "t2")
        {
        }
        public delegate __ExpBase ExpHandler(t2 t2);
        public Column_Int32<t2> id
        {
            get { return new Column_Int32<t2>(this, "id"); }
        }
        public Column_String<t2> name
        {
            get { return new Column_String<t2>(this, "name"); }
        }
        public static List<t2> Select(ExpHandler exp)
        {
            return new List<t2>();
        }
    }
}
