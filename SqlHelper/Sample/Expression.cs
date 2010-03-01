using System;
using System.Collections.Generic;
using System.Text;

namespace NewDM
{
    class Program
    {
        static void Main(string[] args)
        {
            // 关联查询
            var exp1 = Exp.dbo.t1.id.Equals(1 | 2).name.Like("2") | Exp.dbo.t2.id.Equals(3).name.Like("真爽");

            // 单表快捷查询
            dbo.t1.Select(o => o.id.Equals(1).name.Like("t2") | o.name.Equals("t3"));

            // 表达式驱动来返回列表
            (Exp.dbo.t1.id.Equals(1 | 2).name.Like("2") | Exp.dbo.t2.id.Equals(3).name.Like("真爽")).List<dbo.t1>();

            Console.WriteLine(exp1);

            // 看下加的 IsNull
            Console.WriteLine(Exp.dbo.t1.id.IsNull().name.IsNotNull() | Exp.dbo.t2.name.IsNotNull());

            Console.ReadLine();
        }
    }

    public class Exp
    {
        private string _where;
        private string _name;
        private string _schema;

        public void zSetWhere(string where) { _where = where; }
        public string zGetName() { return _name; }
        public string zGetSchema() { return _schema; }
        public override string ToString() { return _where; }

        public Exp() { }
        public Exp(string where) { _where = where; }
        public Exp(string schema, string name)
        {
            this._name = name; this._schema = schema;
        }

        // TSQL 运算符转为方法
        public Exp And(Exp e)
        {
            return new Exp("(" + _where + ")" + " AND " + "(" + e._where + ")");
        }
        public Exp Or(Exp e)
        {
            return new Exp("(" + _where + ")" + " OR " + "(" + e._where + ")");
        }

        // 运算符重载
        public static Exp operator &(Exp e1, Exp e2)
        {
            return e1.And(e2);
        }
        public static Exp operator |(Exp e1, Exp e2)
        {
            return e1.Or(e2);
        }

        // 表达式驱动来返回列表
        public List<T> List<T>() where T : new()
        {
            List<T> _list = new List<T>();
            return _list;
        }

        public class dbo
        {
            // 类型快捷创建
            public static global::dbo.t1 t1 = new global::dbo.t1();
            public static global::dbo.t2 t2 = new global::dbo.t2();
        }

    }



    public class Column<T> where T : Exp, new()
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

    public class Column_Int32<T> : Column<T> where T : Exp, new()
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

    public class Column_String<T> : Column<T> where T : Exp, new()
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

namespace dbo
{
    using NewDM;

    public class t1 : Exp
    {
        public t1()
            : base("dbo", "t1")
        {
        }
        public delegate Exp ExpHandler(t1 t1);
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

    public class t2 : Exp
    {
        public t2()
            : base("dbo", "t2")
        {
        }
        public delegate Exp ExpHandler(t2 t2);
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
