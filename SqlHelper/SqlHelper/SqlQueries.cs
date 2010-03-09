namespace SqlLib.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Query<T, W, O>
        where T : Query<T, W, O>, new()
        where W : SqlLib.Expressions.LogicalNode<W>, new()
        where O : SqlLib.Orientations.LogicalNode<O>, new()
    {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public W Expression { get; set; }
        public O Orientation { get; set; }

        public override string ToString()
        {
            return this.ToSqlString();
        }
        public virtual string ToSqlString(string schema = null, string name = null, bool isSimpleMode = true)
        {
            string ssn = "", stn = "", sw = "", so = "", st = "";
            if (!string.IsNullOrEmpty(schema)) ssn = "[" + schema + "].";
            if (!string.IsNullOrEmpty(name)) stn = "[" + name + "]";
            sw = isSimpleMode ? this.Expression.ToSqlString("", "") : this.Expression.ToSqlString(schema, name);
            so = isSimpleMode ? this.Orientation.ToSqlString("", "") : this.Orientation.ToSqlString(schema, name);

            // todo: 分页处理

            if (this.PageIndex == 0 && this.PageSize > 0) st = "TOP (" + this.PageSize + ") ";

            return "SELECT " + st + @"* FROM " + ssn + stn + (sw.Length > 0 ? " WHERE " : "") + sw + (so.Length > 0 ? " ORDER BY " : "") + so;
        }

        public T Where(SqlLib.Expressions.LogicalNode<W>.Handler h)
        {
            this.Expression = h.Invoke(new W());
            return (T)this;
        }
        public T OrderBy(SqlLib.Orientations.LogicalNode<O>.Handler h)
        {
            this.Orientation = h.Invoke(new O());
            return (T)this;
        }

    }
}
